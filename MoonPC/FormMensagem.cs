using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoonPC{
    public partial class FormMensagem : Form {
        public FormMensagem() {
            InitializeComponent();
        }

        public string msgmTitle{ get; set; }
        public string msgmMensagem { get; set; }

        private void FormMensagem_Load(object sender, EventArgs e) {

            //lblTitle.Text = msgmTitle;
            lblMessage.Text = msgmMensagem;
            
            // Recupera o tamanho da tela.
            int screenSizeWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenSizeHeight = Screen.PrimaryScreen.Bounds.Height;

            this.Location = new Point((screenSizeWidth - 400), (screenSizeHeight - 250));

            int x = (panel.Size.Width - lblMessage.Width) / 2;
            int y = 20;
            //int y = (panel.Size.Height - lblMessage.Height) / 2;

            lblMessage.Location = new Point(x, y);

        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Hide();
        }
    }
}
