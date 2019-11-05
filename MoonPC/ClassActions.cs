using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MoonPC{

    class ClassActions {
        ClassApplication classApp = new ClassApplication();
        ClassLogs logs = new ClassLogs();

        public bool ShutdownPC() {
            try {
                var psi = new ProcessStartInfo("shutdown", "/s /f /t 10");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                logs.Create("O computador foi desligado pelo MoonPC", "SUCCESS");

                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");
                
                return false;
            }
        }

        public bool RestartPC() {
            try {
                var psi = new ProcessStartInfo("shutdown", "/r /f /t 10");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                logs.Create("O computador foi reiniciado pelo MoonPC", "SUCCESS");

                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            }
        }

        public bool LogoffPC() {
            try {
                var psi = new ProcessStartInfo("shutdown", "/l /f /t 10");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
                logs.Create("O computador foi bloqueado pelo MoonPC", "SUCCESS");

                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            }
        }

        public bool OptimizeMemory() {
            try {
                string currentDirectory = Directory.GetCurrentDirectory();
                string batFile = currentDirectory + "\\clear-memory.bat";

                var psi = new ProcessStartInfo("cmd.exe", "/c " + batFile);
                psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                Process.Start(psi);
                logs.Create("A memória do computador foi otimizada pelo MoonPC", "SUCCESS");

                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            }
        }

        public bool PrintScreen() {
            /*
                string currentDirectory = Directory.GetCurrentDirectory();
                string commands = "savescreenshot " + currentDirectory + "\\printscreen.png";
                var psi = new ProcessStartInfo(currentDirectory + "\\nircmd.exe", commands);
                psi.CreateNoWindow = false;
                psi.UseShellExecute = false;
                Process.Start(psi);
            */

            try {
                Bitmap printscreen = new Bitmap
                (Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
                printscreen.Save(classApp.appDataFolder + "printscreen.png", ImageFormat.Png);
                
                if (File.Exists(classApp.appDataFolder + "printscreen.png")) {
                    logs.Create("Foi tirada a uma foto da tela do PC pelo administrador.", "SUCCESS");

                    return true;
                } else {
                    logs.Create("Arquivo \"printscreen.png\" não encontrado.", "ERROR");

                    return false;
                };

            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            }
        }

        public bool UploadPrintScreen(string serverSend) {
            try {  
                // Create a http request to the server endpoint that will pick up the
                // file and file description.
                HttpWebRequest requestToServerEndpoint =
                (HttpWebRequest)WebRequest.Create(serverSend);

                string boundaryString = "----SomeRandomText";
                string fileUrl = classApp.appDataFolder + "printscreen.png";

                // Set the http request header \\
                requestToServerEndpoint.Method = WebRequestMethods.Http.Post;
                requestToServerEndpoint.ContentType = "multipart/form-data; boundary=" + boundaryString;
                requestToServerEndpoint.KeepAlive = true;
                requestToServerEndpoint.Credentials = System.Net.CredentialCache.DefaultCredentials;

                // Use a MemoryStream to form the post data request,
                // so that we can get the content-length attribute.
                MemoryStream postDataStream = new MemoryStream();
                StreamWriter postDataWriter = new StreamWriter(postDataStream);

                // Include value from the myFileDescription text area in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
                "myFileDescription",
                "A sample file description");

                // Include the file in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data;"
                + "name=\"{0}\";"
                + "filename=\"{1}\""
                + "\r\nContent-Type: {2}\r\n\r\n",
                "fileName",
                Path.GetFileName(fileUrl),
                Path.GetExtension(fileUrl));
                postDataWriter.Flush();

                // Read the file
                FileStream fileStream = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0) {
                    postDataStream.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();

                postDataWriter.Write("\r\n--" + boundaryString + "--\r\n");
                postDataWriter.Flush();

                // Set the http request body content length
                requestToServerEndpoint.ContentLength = postDataStream.Length;

                // Dump the post data from the memory stream to the request stream
                using (Stream s = requestToServerEndpoint.GetRequestStream()) {
                    postDataStream.WriteTo(s);
                }
                postDataStream.Close();

                // Grab the response from the server. WebException will be thrown
                // when a HTTP OK status is not returned
                WebResponse response = requestToServerEndpoint.GetResponse();
                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                string replyFromServer = responseReader.ReadToEnd();

                logs.Create("A foto deste computador, soliciada pelo administrador, foi enviada para o MoonPC", "SUCCESS");

                return true;
            } catch (Exception error) {
                logs.Create(error.Message, "ERROR");

                return false;
            }
        }
        
    }
}
