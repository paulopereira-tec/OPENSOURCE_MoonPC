using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MoonPC{
    class ClassLogs {

        string currentDirectory = Directory.GetCurrentDirectory();

        public string appDataFolder {
            get {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\MoonPC\\";
            }
        }

        public bool Create(string log, string type) {
            try {
                // Cria o nome do arquivo com ano, mês, dia, hora minuto e segundo

                string nomeArquivo = appDataFolder + "log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";

                // Cria um novo arquivo e devolve um StreamWriter para ele

                StreamWriter writer = new StreamWriter(nomeArquivo, true);

                // Agora é só sair escrevendo

                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss") + " - " + type + ": " + log + ";");

                // Não esqueça de fechar o arquivo ao terminar

                writer.Close();

                return true;

            } catch ( Exception err ) {
                string erro = err.Message;
                Console.WriteLine(erro);
                return false;
            }
        }

    }
}
