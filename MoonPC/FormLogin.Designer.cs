namespace MoonPC
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.txtActivationCode = new System.Windows.Forms.TextBox();
            this.lblActivationCode = new System.Windows.Forms.Label();
            this.btnActivation = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivationCode.Location = new System.Drawing.Point(12, 100);
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new System.Drawing.Size(376, 32);
            this.txtActivationCode.TabIndex = 0;
            this.txtActivationCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblActivationCode
            // 
            this.lblActivationCode.AutoSize = true;
            this.lblActivationCode.Location = new System.Drawing.Point(121, 78);
            this.lblActivationCode.Name = "lblActivationCode";
            this.lblActivationCode.Size = new System.Drawing.Size(158, 13);
            this.lblActivationCode.TabIndex = 2;
            this.lblActivationCode.Text = "Insira o seu código de ativação:";
            this.lblActivationCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnActivation
            // 
            this.btnActivation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnActivation.FlatAppearance.BorderSize = 0;
            this.btnActivation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivation.Location = new System.Drawing.Point(125, 144);
            this.btnActivation.Name = "btnActivation";
            this.btnActivation.Size = new System.Drawing.Size(150, 40);
            this.btnActivation.TabIndex = 3;
            this.btnActivation.Text = "Iniciar ativação";
            this.btnActivation.UseVisualStyleBackColor = false;
            this.btnActivation.Click += new System.EventHandler(this.btnActivation_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(160)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 60);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(90, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Processo de ativação";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 196);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnActivation);
            this.Controls.Add(this.lblActivationCode);
            this.Controls.Add(this.txtActivationCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivationCode;
        private System.Windows.Forms.Label lblActivationCode;
        private System.Windows.Forms.Button btnActivation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}