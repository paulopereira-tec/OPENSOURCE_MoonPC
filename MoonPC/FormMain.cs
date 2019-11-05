using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MoonPC {

    public partial class FormMain : Form {
        // Diretório raiz da aplicação
        private string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        private string currentDirectory = Environment.CurrentDirectory;
        

        private string strServer = "https://www.padmin.ga/";

        private ClassMachine machine = new ClassMachine();
        private ClassApplication application = new ClassApplication();
        private ClassActions actions = new ClassActions();
        private ClassLogs logs = new ClassLogs();

        public FormMain() {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            application.CreateMoonPCAppDataFolder();
            logs.Create("MoonPC Iniciado", "SUCCESS");

            // Seta aplicação para ser inicializada junto com o Windows
            application.SetStartup();

            string toPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            
            // Produto ativado.
            // Recupera o tamanho da tela.
            int screenSizeWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenSizeHeight = Screen.PrimaryScreen.Bounds.Height;

            // Atualiza a altura do aplicativo
            this.Height = 118;

            // Atualiza a posição do aplicativo
            this.Location = new Point(screenSizeWidth - 180, 0);


            /* A partir daqui verifica a ativação. */
            bool actRead = application.ReadActivation();
            string actVal = application.actVal;

            if (!actRead) {
                // Produto ainda não ativado.
                FormLogin formLogin = new FormLogin();
                formLogin.toServer = strServer;
                formLogin.Show();
            } else {
                // Seta aplicação para ser inicializada junto com o Windows.
                application.SetStartup();

                // Altera os valores das labels
                lblComputerName.Text = machine.getMachineName();
                lblWorkgroupName.Text = machine.getWorkgroupName();
                lblSystemName.Text = machine.getSystemName();
                lblAntivirus.Text = machine.getAntivirusName();
                lblMemorySize.Text = machine.getMemoryUsed() + " de " + machine.getMemoryTotal() + "GB";

                string checkConnection = machine.checkConnection();
                if (checkConnection != "") {
                    lblConnectionStatus.Text = "IP: " + checkConnection;
                    lblConnectionStatus.ForeColor = System.Drawing.Color.White;
                };

                timer.Start();
            };
        }

        private void btnExpand_Click(object sender, EventArgs e) {
            btnExpand.Visible = false;
            pnInfoPC.Visible = true;

            while (this.Height < 395) {
                this.Height++;
                Application.DoEvents();
            };
        }

        private void btnContract_Click(object sender, EventArgs e) {
            while (this.Height > 118) {
                this.Height--;
                Application.DoEvents();
            };

            btnExpand.Visible = true;
            pnInfoPC.Visible = false;
        }

        // Desligamento do PC
        private void btnShutdown_Click(object sender, EventArgs e) {
            actions.ShutdownPC();
        }

        private void btnWeb_Click(object sender, EventArgs e) {
            ProcessStartInfo sInfo = new ProcessStartInfo(strServer);
            Process.Start(sInfo);
        }

        private void btnRestart_Click(object sender, EventArgs e) {
            actions.RestartPC();
        }

        private void btnClearMemory_Click(object sender, EventArgs e) {
            actions.OptimizeMemory();
        }

        private void timer_Tick(object sender, EventArgs e) {
            string[] response = application.SendDataToServerAsync(strServer + "api/moonpc/");


            if (response[0] == "true") {
                this.BackColor = Color.FromArgb(99, 160, 128);

                string responseType = response[1];

                switch (responseType) {
                    case "shutdown": {
                            notifyIcon.ShowBalloonTip(1000, "Mensagem", "Seu computador será desligado em menos de um minuto.", ToolTipIcon.Info);

                            actions.ShutdownPC();
                        }; break;
                    case "restart": {
                            notifyIcon.ShowBalloonTip(1000, "Mensagem", "Seu computador será reiniciado em menos de um minuto.", ToolTipIcon.Info);
                            actions.RestartPC();
                        }; break;
                    case "logoff": {
                            notifyIcon.ShowBalloonTip(1000, "Mensagem", "Seu computador será bloqueado em menos de um minuto.", ToolTipIcon.Info);

                            actions.LogoffPC();
                        }; break;
                    case "print": {
                            // See https://screenshotmonitor.com/blog/capturing-screenshots-in-net-and-mono/
                            string toPath = Directory.GetCurrentDirectory();

                            application.ReadActivation();

                            if (actions.PrintScreen()) {
                                actions.UploadPrintScreen(strServer + "api/moonpc/upload_printscreen/?act_code=" + application.actVal);
                                notifyIcon.ShowBalloonTip(1000, "Mensagem", "O administrador do sistema tirou uma foto da sua tela. A foto será salva em: " + toPath, ToolTipIcon.Info);
                            }

                        }; break;
                    case "message": {
                            notifyIcon.ShowBalloonTip(1000, "Mensagem", response[2], ToolTipIcon.Info);

                            FormMensagem frmMsgm = new FormMensagem();

                            logs.Create("Uma mensagem foi recebida pelo administrador do sistema.", "SUCCESS");

                            frmMsgm.msgmMensagem = response[2];
                            frmMsgm.Show();

                        }; break;
                    case "open_url": {
                            notifyIcon.ShowBalloonTip(1000, "Mensagem", "Abrindo navegador de internet.", ToolTipIcon.Info);
                            
                            ProcessStartInfo sInfo = new ProcessStartInfo(response[2]);
                            Process.Start(sInfo);
                        }; break;
                    case "opmemory": {
                            notifyIcon.ShowBalloonTip(1000, "Mensagem", "Otimização de memória iniciada.", ToolTipIcon.Info);

                            actions.OptimizeMemory();
                        }; break;
                    default:; break;
                }
            } else {
                this.BackColor = Color.Maroon;
            };

            //lblCustomerName.Text = response[0];
            timer.Interval = (1000 * 60);
        }

        private void cmenuReactivate_Click(object sender, EventArgs e) {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
        }

        private void cmenuExit_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deseja realmente fechar o Monitoramento?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ) {

                // Seta aplicação para ser inicializada junto com o Windows
                application.SetStartup();

                Application.Exit();
            }
        }
    }
}
