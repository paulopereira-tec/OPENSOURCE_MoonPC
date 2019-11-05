using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using Microsoft.VisualBasic.Devices;
using System.IO;

namespace MoonPC{
    class ClassMachine {

        ClassLogs logs = new ClassLogs();

        public string getMachineName() {
            // See https://msdn.microsoft.com/pt-br/library/system.environment(v=vs.110).aspx
            string machineName = Environment.MachineName;
            return machineName;
        }

        public string getWorkgroupName() {
            // See: https://niravdaraniya.blogspot.com/2013/03/how-to-get-workgroup-name-of-computer.html
            string workgroup = "Não encontrado.";

            // Getting information about worke group of computer
            ManagementObjectSearcher mosComputer = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem");
            foreach (ManagementObject moComputer in mosComputer.Get()) {
                if (moComputer["Workgroup"] != null) {
                    workgroup = moComputer["Workgroup"].ToString();
                };
            };

            return workgroup;
        }

        public string getLoggedUser() {
            // See https://msdn.microsoft.com/pt-br/library/system.environment(v=vs.110).aspx
            string userName = Environment.UserName;
            return userName;
        }

        public string getSystemName() {
            // See https://stackoverflow.com/questions/6331826/get-os-version-friendly-name-in-c-sharp
            string systemName = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get()) {
                systemName = os["Caption"].ToString();
                break;
            }
            return systemName.Replace("Microsoft ", ""); ;
        }
        
        public string getHardDriveInfo( string what ) {
            // See https://social.msdn.microsoft.com/Forums/en-US/4669867d-15cf-445d-a549-f705079ce74a/get-total-size-of-hard-drive-in-c?forum=csharplanguage
            string response = "";
            long size = 0;

            if (what == "total") {
                foreach (DriveInfo drive in DriveInfo.GetDrives()) {
                    if (drive.IsReady) {
                        //response += ";" + drive.Name + ": " + drive.TotalSize;
                        size += drive.TotalSize;
                    }
                }
            } else {
                foreach (DriveInfo drive in DriveInfo.GetDrives()) {
                    if (drive.IsReady) {
                        //response += ";" + drive.Name + ": " + drive.TotalSize;
                        size += drive.TotalFreeSpace;
                    }
                }
            };

            

            response = size.ToString();
            return response;
        }

        public string getProcessorName() {
            string processor = "";

            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
            foreach (ManagementObject mo in mos.Get()) {
                processor  = mo["Name"].ToString();
            }

            return processor;
        }

        public string getAntivirusName() {
            string antivirus = "Não detectado.";

            /* Até o Windows Vista '\root\SecurityCenter'
            var searcher = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter", "SELECT * FROM AntivirusProduct");
                var searcherInstance = searcher.Get();
                foreach (var instance in searcherInstance) {
                antivirus = instance["displayName"].ToString();
                };
            */
            // Depois do Windows Vista and above '\root\SecurityCenter2'
            var searcher = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "SELECT * FROM AntivirusProduct");
            var searcherInstance = searcher.Get();
            foreach (var instance in searcherInstance) {
                antivirus = instance["displayName"].ToString();
            }

            return antivirus;
        }

        public string getMemoryTotal() {
            var ci = new ComputerInfo();
            double memory = ci.TotalPhysicalMemory;
            memory = Math.Round(((memory / 1024) / 1024) / 1024);

            return memory.ToString();
        }

        public string getMemoryUsed() {
            // See: https://social.msdn.microsoft.com/Forums/vstudio/en-US/0f23efb5-7a29-43ea-b25f-aa7a82a8bb94/how-to-get-total-installed-ram-of-a-system?forum=csharpgeneral

            double memoryUsed = 0.0;

            ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
            ManagementObjectCollection results = searcher.Get();

            double memoryTotal;

            foreach (ManagementObject result in results) {
                memoryTotal = Convert.ToDouble(result["TotalVisibleMemorySize"]);
                memoryUsed = Math.Round((memoryTotal / (1024 * 1024)), 2);
            };

            return memoryUsed.ToString();
        }

        public string checkConnection() {
            string externalip;

            try {
                // See https://stackoverflow.com/questions/3253701/get-public-external-ip-address
                externalip = new WebClient().DownloadString("https://ipinfo.io/ip");

                logs.Create("Computador conectado a internet. IP: " + externalip, "SUCCESS");


            } catch ( Exception error) {
                logs.Create(error.Message, "ERROR");
                
                externalip = error.Message;
            }
            return externalip;
        }

        public string GetMACAddress() {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
            string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
            return mac;
        }
    }
}
