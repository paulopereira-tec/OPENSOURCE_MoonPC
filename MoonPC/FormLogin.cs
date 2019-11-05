using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoonPC {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
        }

        ClassApplication classApplication = new ClassApplication();

        public string toServer { get; set; }

        private void btnActivation_Click(object sender, EventArgs e) {
            
            // Recupera o código de ativação
            string actCode = txtActivationCode.Text;

            // Muda o conteúdo do texto e bloqueia o campo e o botão
            txtActivationCode.Text = "Aguarde. Ativando sistema.";
            txtActivationCode.Enabled = false;
            btnActivation.Enabled = false;

            classApplication.actVal = actCode;

            if ( classApplication.WriteActivation() ) {
                string[] response = classApplication.SendDataToServerAsync(toServer);

                if (response[0] == "false") {
                    MessageBox.Show("Erro na ativação. Mensagem retornada:\n" + response[1], "Erro na ativação", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtActivationCode.Text = "";
                    txtActivationCode.Enabled = true;
                    btnActivation.Enabled = true;
                    txtActivationCode.Focus();

                } else {
                    if (MessageBox.Show("Produto ativado. O programa será reiniciado", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) {
                        Application.Restart();
                    };  
                };
            } else {
                MessageBox.Show("Houve um erro ao tentar registrar o produto. Mensagem retornada:\n" + classApplication.actVal, "Erro no registro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtActivationCode.Text = "";
                txtActivationCode.Enabled = true;
                btnActivation.Enabled = true;
                txtActivationCode.Focus();
            }
            
        }
    }
}
