namespace MoonPC
{
    partial class FormMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnWeb = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuReactivate = new System.Windows.Forms.ToolStripMenuItem();
            this.pnInfoPC = new System.Windows.Forms.Panel();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnClearMemory = new System.Windows.Forms.Button();
            this.lblMemorySize = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblAntivirus = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSystemName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblWorkgroupName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblComputerName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnContract = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnButtons.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.pnInfoPC.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Name = "lblTitle";
            // 
            // pnButtons
            // 
            this.pnButtons.BackColor = System.Drawing.Color.White;
            this.pnButtons.Controls.Add(this.btnHelp);
            this.pnButtons.Controls.Add(this.btnWeb);
            this.pnButtons.Controls.Add(this.btnRestart);
            this.pnButtons.Controls.Add(this.btnShutdown);
            resources.ApplyResources(this.pnButtons, "pnButtons");
            this.pnButtons.Name = "pnButtons";
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.White;
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = false;
            // 
            // btnWeb
            // 
            this.btnWeb.BackColor = System.Drawing.Color.White;
            this.btnWeb.FlatAppearance.BorderSize = 0;
            this.btnWeb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWeb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.btnWeb, "btnWeb");
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.UseVisualStyleBackColor = false;
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.White;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnRestart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.btnRestart, "btnRestart");
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.BackColor = System.Drawing.Color.White;
            this.btnShutdown.FlatAppearance.BorderSize = 0;
            this.btnShutdown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnShutdown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            resources.ApplyResources(this.btnShutdown, "btnShutdown");
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.UseVisualStyleBackColor = false;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // btnExpand
            // 
            this.btnExpand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExpand.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnExpand, "btnExpand");
            this.btnExpand.ForeColor = System.Drawing.Color.White;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.UseVisualStyleBackColor = false;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.ContextMenuStrip = this.contextMenu;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuExit,
            this.cmenuReactivate});
            this.contextMenu.Name = "contextMenu";
            resources.ApplyResources(this.contextMenu, "contextMenu");
            // 
            // cmenuExit
            // 
            this.cmenuExit.Name = "cmenuExit";
            resources.ApplyResources(this.cmenuExit, "cmenuExit");
            this.cmenuExit.Click += new System.EventHandler(this.cmenuExit_Click);
            // 
            // cmenuReactivate
            // 
            this.cmenuReactivate.Name = "cmenuReactivate";
            resources.ApplyResources(this.cmenuReactivate, "cmenuReactivate");
            this.cmenuReactivate.Click += new System.EventHandler(this.cmenuReactivate_Click);
            // 
            // pnInfoPC
            // 
            this.pnInfoPC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(108)))), ((int)(((byte)(139)))));
            this.pnInfoPC.Controls.Add(this.lblConnectionStatus);
            this.pnInfoPC.Controls.Add(this.label15);
            this.pnInfoPC.Controls.Add(this.btnClearMemory);
            this.pnInfoPC.Controls.Add(this.lblMemorySize);
            this.pnInfoPC.Controls.Add(this.label17);
            this.pnInfoPC.Controls.Add(this.lblAntivirus);
            this.pnInfoPC.Controls.Add(this.label11);
            this.pnInfoPC.Controls.Add(this.lblSystemName);
            this.pnInfoPC.Controls.Add(this.label13);
            this.pnInfoPC.Controls.Add(this.lblWorkgroupName);
            this.pnInfoPC.Controls.Add(this.label7);
            this.pnInfoPC.Controls.Add(this.lblComputerName);
            this.pnInfoPC.Controls.Add(this.label10);
            resources.ApplyResources(this.pnInfoPC, "pnInfoPC");
            this.pnInfoPC.Name = "pnInfoPC";
            // 
            // lblConnectionStatus
            // 
            resources.ApplyResources(this.lblConnectionStatus, "lblConnectionStatus");
            this.lblConnectionStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Name = "label15";
            // 
            // btnClearMemory
            // 
            this.btnClearMemory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(84)))), ((int)(((byte)(112)))));
            this.btnClearMemory.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnClearMemory, "btnClearMemory");
            this.btnClearMemory.ForeColor = System.Drawing.Color.White;
            this.btnClearMemory.Name = "btnClearMemory";
            this.btnClearMemory.UseVisualStyleBackColor = false;
            this.btnClearMemory.Click += new System.EventHandler(this.btnClearMemory_Click);
            // 
            // lblMemorySize
            // 
            resources.ApplyResources(this.lblMemorySize, "lblMemorySize");
            this.lblMemorySize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblMemorySize.ForeColor = System.Drawing.Color.White;
            this.lblMemorySize.Name = "lblMemorySize";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Name = "label17";
            // 
            // lblAntivirus
            // 
            resources.ApplyResources(this.lblAntivirus, "lblAntivirus");
            this.lblAntivirus.ForeColor = System.Drawing.Color.White;
            this.lblAntivirus.Name = "lblAntivirus";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Name = "label11";
            // 
            // lblSystemName
            // 
            resources.ApplyResources(this.lblSystemName, "lblSystemName");
            this.lblSystemName.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Name = "lblSystemName";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Name = "label13";
            // 
            // lblWorkgroupName
            // 
            resources.ApplyResources(this.lblWorkgroupName, "lblWorkgroupName");
            this.lblWorkgroupName.ForeColor = System.Drawing.Color.White;
            this.lblWorkgroupName.Name = "lblWorkgroupName";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Name = "label7";
            // 
            // lblComputerName
            // 
            resources.ApplyResources(this.lblComputerName, "lblComputerName");
            this.lblComputerName.ForeColor = System.Drawing.Color.White;
            this.lblComputerName.Name = "lblComputerName";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Name = "label10";
            // 
            // btnContract
            // 
            this.btnContract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContract.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnContract, "btnContract");
            this.btnContract.ForeColor = System.Drawing.Color.White;
            this.btnContract.Name = "btnContract";
            this.btnContract.UseVisualStyleBackColor = false;
            this.btnContract.Click += new System.EventHandler(this.btnContract_Click);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(160)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.btnContract);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnButtons);
            this.Controls.Add(this.pnInfoPC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.pnButtons.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.pnInfoPC.ResumeLayout(false);
            this.pnInfoPC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnButtons;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Panel pnInfoPC;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnClearMemory;
        private System.Windows.Forms.Label lblMemorySize;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblAntivirus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSystemName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblWorkgroupName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblComputerName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnContract;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnWeb;
        private System.Windows.Forms.Button btnRestart;
        public System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmenuExit;
        private System.Windows.Forms.ToolStripMenuItem cmenuReactivate;
    }
}

