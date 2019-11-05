using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Microsoft.Win32;

namespace MoonPC{
    class ClassApplication {

        ClassLogs logs = new ClassLogs();
        private ClassMachine classMachine = new ClassMachine();

        // cria pasta do MoonPC no diretório AppData
        public string appDataFolder {
            get {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MoonPC\\";
            }
        }

        public void CreateMoonPCAppDataFolder() {
            if ( !Directory.Exists(appDataFolder) ) {
                Directory.CreateDirectory(appDataFolder);
            }
        }

        // envia os dados para o servidor
        public string[] SendDataToServerAsync(string server) {

            ReadActivation();
            
            //string server = "http://dev.padmin.ga/api/moonpc/";

            string toServer = "mac_address=" + classMachine.GetMACAddress() +
                              "&pc_name=" + classMachine.getMachineName() +
                              "&processor=" + classMachine.getProcessorName() +
                              "&workgroup=" + classMachine.getWorkgroupName() +
                              "&so=" + classMachine.getSystemName() +
                              "&antivirus=" + classMachine.getAntivirusName() +
                              "&memory_total=" + classMachine.getMemoryTotal() +
                              "&memory_used=" + classMachine.getMemoryUsed() +
                              "&connection_ip=" + classMachine.checkConnection() +
                              "&hd_size_total=" + classMachine.getHardDriveInfo("total") +
                              "&hd_size_free=" + classMachine.getHardDriveInfo("free") +
                              "&logged_user=" + classMachine.getLoggedUser() +
                              "&moonpc_version=1.0.5" +
                              "&activation_code=" + this.actVal;

            var request = (HttpWebRequest)WebRequest.Create(server);

            //var postData = "thing1=hello";
            var data = Encoding.ASCII.GetBytes(toServer);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            string[] responseSplited;

            try {
                using (var stream = request.GetRequestStream()) {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                responseString = HttpUtility.UrlDecode(responseString);
                responseSplited = responseString.Split(new[] { ";" }, StringSplitOptions.None);


                logs.Create("Os dados desse computador foram enviados ao MoonPC", "SUCCESS");


            } catch (Exception error) {
                responseSplited = new string[] { "false", "Erro na conexão." };
                
                logs.Create(error.Message, "ERROR");

                string err = error.Message;
            }

            return responseSplited;
        }
        
        /**** A partir daqui, procede-se com a ativação do software ****/
        private string actPath = @"SOFTWARE\NWInfo\";
        private string actKey = "ActCodeMoonPC";
        public string actVal{ get; set; }

        public bool WriteActivation() {
            try {
                RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(actPath);
                registryKey.SetValue(actKey, actVal);
                registryKey.Close();
                logs.Create("O MoonPC foi (re)ativado neste computador.", "SUCCESS");


                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            };
        }

        public bool ReadActivation() {
            try {
                RegistryKey regedit = Registry.CurrentUser.OpenSubKey(actPath, true);
                actVal = regedit.GetValue(actKey).ToString();
                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            }
        }

        public void SetStartup() {
            try {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                rk.SetValue("MoonPC", Directory.GetCurrentDirectory() + "\\MoonPC.exe");


                logs.Create("O MoonPC está sendo iniciado junto com o sistema.", "SUCCESS");

            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");
            }
            
            
        }
    }
}
