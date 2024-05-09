namespace MaddogSimGUI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonCalibration = new System.Windows.Forms.Button();
            this.buttonADCInputs = new System.Windows.Forms.Button();
            this.buttonWelcome = new System.Windows.Forms.Button();
            this.panelBarraTitulo2 = new System.Windows.Forms.Panel();
            this.buttonSimConnect = new System.Windows.Forms.Button();
            this.buttonSimDisconnect = new System.Windows.Forms.Button();
            this.buttonRspbConnect = new System.Windows.Forms.Button();
            this.buttonRspbDisconnect = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxNumPort = new System.Windows.Forms.TextBox();
            this.panelLog = new System.Windows.Forms.Panel();
            this.labelLatency = new System.Windows.Forms.Label();
            this.labelIPServer = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.panelBarraTitulo = new System.Windows.Forms.Panel();
            this.btnRes = new System.Windows.Forms.PictureBox();
            this.btnMini = new System.Windows.Forms.PictureBox();
            this.btnMaxi = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.panelContenedor.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelBarraTitulo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLog.SuspendLayout();
            this.panelBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMini)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaxi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panelContenedor
            // 
            this.panelContenedor.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelContenedor.Controls.Add(this.panelFormularios);
            this.panelContenedor.Controls.Add(this.panelMenu);
            this.panelContenedor.Controls.Add(this.panelBarraTitulo2);
            this.panelContenedor.Controls.Add(this.panelBarraTitulo);
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 0);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1416, 817);
            this.panelContenedor.TabIndex = 0;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.Color.White;
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.panelFormularios.Location = new System.Drawing.Point(253, 200);
            this.panelFormularios.Margin = new System.Windows.Forms.Padding(4);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(1163, 617);
            this.panelFormularios.TabIndex = 2;
            this.panelFormularios.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFormularios_Paint);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panelMenu.Controls.Add(this.buttonCalibration);
            this.panelMenu.Controls.Add(this.buttonADCInputs);
            this.panelMenu.Controls.Add(this.buttonWelcome);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 200);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(253, 617);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // buttonCalibration
            // 
            this.buttonCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCalibration.FlatAppearance.BorderSize = 0;
            this.buttonCalibration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalibration.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalibration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.buttonCalibration.Location = new System.Drawing.Point(0, 128);
            this.buttonCalibration.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalibration.Name = "buttonCalibration";
            this.buttonCalibration.Size = new System.Drawing.Size(253, 64);
            this.buttonCalibration.TabIndex = 2;
            this.buttonCalibration.Text = "Calibration";
            this.buttonCalibration.UseVisualStyleBackColor = true;
            this.buttonCalibration.Click += new System.EventHandler(this.buttonCalibration_Click);
            // 
            // buttonADCInputs
            // 
            this.buttonADCInputs.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonADCInputs.FlatAppearance.BorderSize = 0;
            this.buttonADCInputs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.buttonADCInputs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonADCInputs.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonADCInputs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.buttonADCInputs.Location = new System.Drawing.Point(0, 64);
            this.buttonADCInputs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonADCInputs.Name = "buttonADCInputs";
            this.buttonADCInputs.Size = new System.Drawing.Size(253, 64);
            this.buttonADCInputs.TabIndex = 1;
            this.buttonADCInputs.Text = "ADC Inputs";
            this.buttonADCInputs.UseVisualStyleBackColor = true;
            this.buttonADCInputs.Click += new System.EventHandler(this.buttonADCInputs_Click);
            // 
            // buttonWelcome
            // 
            this.buttonWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonWelcome.FlatAppearance.BorderSize = 0;
            this.buttonWelcome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.buttonWelcome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.buttonWelcome.Location = new System.Drawing.Point(0, 0);
            this.buttonWelcome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWelcome.Name = "buttonWelcome";
            this.buttonWelcome.Size = new System.Drawing.Size(253, 64);
            this.buttonWelcome.TabIndex = 0;
            this.buttonWelcome.Text = "Welcome";
            this.buttonWelcome.UseVisualStyleBackColor = true;
            this.buttonWelcome.Click += new System.EventHandler(this.buttonWelcome_Click);
            // 
            // panelBarraTitulo2
            // 
            this.panelBarraTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(58)))), ((int)(((byte)(57)))));
            this.panelBarraTitulo2.Controls.Add(this.buttonSimConnect);
            this.panelBarraTitulo2.Controls.Add(this.buttonSimDisconnect);
            this.panelBarraTitulo2.Controls.Add(this.buttonRspbConnect);
            this.panelBarraTitulo2.Controls.Add(this.buttonRspbDisconnect);
            this.panelBarraTitulo2.Controls.Add(this.pictureBox1);
            this.panelBarraTitulo2.Controls.Add(this.textBoxNumPort);
            this.panelBarraTitulo2.Controls.Add(this.panelLog);
            this.panelBarraTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraTitulo2.Location = new System.Drawing.Point(0, 39);
            this.panelBarraTitulo2.Margin = new System.Windows.Forms.Padding(4);
            this.panelBarraTitulo2.Name = "panelBarraTitulo2";
            this.panelBarraTitulo2.Size = new System.Drawing.Size(1416, 161);
            this.panelBarraTitulo2.TabIndex = 0;
            this.panelBarraTitulo2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBarraTitulo2_Paint);
            // 
            // buttonSimConnect
            // 
            this.buttonSimConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(168)))), ((int)(((byte)(219)))));
            this.buttonSimConnect.FlatAppearance.BorderSize = 0;
            this.buttonSimConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimConnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSimConnect.Image")));
            this.buttonSimConnect.Location = new System.Drawing.Point(1311, 28);
            this.buttonSimConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSimConnect.Name = "buttonSimConnect";
            this.buttonSimConnect.Size = new System.Drawing.Size(85, 79);
            this.buttonSimConnect.TabIndex = 0;
            this.buttonSimConnect.UseVisualStyleBackColor = false;
            this.buttonSimConnect.Click += new System.EventHandler(this.buttonSimConnect_Click);
            // 
            // buttonSimDisconnect
            // 
            this.buttonSimDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.buttonSimDisconnect.FlatAppearance.BorderSize = 0;
            this.buttonSimDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSimDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonSimDisconnect.Image")));
            this.buttonSimDisconnect.Location = new System.Drawing.Point(1311, 28);
            this.buttonSimDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSimDisconnect.Name = "buttonSimDisconnect";
            this.buttonSimDisconnect.Size = new System.Drawing.Size(85, 79);
            this.buttonSimDisconnect.TabIndex = 0;
            this.buttonSimDisconnect.UseVisualStyleBackColor = false;
            this.buttonSimDisconnect.Click += new System.EventHandler(this.buttonSimDisconnect_Click);
            // 
            // buttonRspbConnect
            // 
            this.buttonRspbConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(168)))), ((int)(((byte)(219)))));
            this.buttonRspbConnect.FlatAppearance.BorderSize = 0;
            this.buttonRspbConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRspbConnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonRspbConnect.Image")));
            this.buttonRspbConnect.Location = new System.Drawing.Point(1207, 28);
            this.buttonRspbConnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRspbConnect.Name = "buttonRspbConnect";
            this.buttonRspbConnect.Size = new System.Drawing.Size(85, 79);
            this.buttonRspbConnect.TabIndex = 0;
            this.buttonRspbConnect.UseVisualStyleBackColor = false;
            this.buttonRspbConnect.Click += new System.EventHandler(this.buttonRspbConnect_Click);
            // 
            // buttonRspbDisconnect
            // 
            this.buttonRspbDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.buttonRspbDisconnect.FlatAppearance.BorderSize = 0;
            this.buttonRspbDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRspbDisconnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonRspbDisconnect.Image")));
            this.buttonRspbDisconnect.Location = new System.Drawing.Point(1207, 28);
            this.buttonRspbDisconnect.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRspbDisconnect.Name = "buttonRspbDisconnect";
            this.buttonRspbDisconnect.Size = new System.Drawing.Size(85, 79);
            this.buttonRspbDisconnect.TabIndex = 3;
            this.buttonRspbDisconnect.UseVisualStyleBackColor = false;
            this.buttonRspbDisconnect.Click += new System.EventHandler(this.buttonRspbDisconnect_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 132);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxNumPort
            // 
            this.textBoxNumPort.Location = new System.Drawing.Point(1053, 28);
            this.textBoxNumPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNumPort.Name = "textBoxNumPort";
            this.textBoxNumPort.Size = new System.Drawing.Size(132, 22);
            this.textBoxNumPort.TabIndex = 1;
            this.textBoxNumPort.Text = "50000";
            this.textBoxNumPort.TextChanged += new System.EventHandler(this.textBoxNumPort_TextChanged);
            // 
            // panelLog
            // 
            this.panelLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.panelLog.Controls.Add(this.labelLatency);
            this.panelLog.Controls.Add(this.labelIPServer);
            this.panelLog.Controls.Add(this.labelIP);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLog.Location = new System.Drawing.Point(0, 131);
            this.panelLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(1416, 30);
            this.panelLog.TabIndex = 0;
            // 
            // labelLatency
            // 
            this.labelLatency.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelLatency.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLatency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.labelLatency.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelLatency.Location = new System.Drawing.Point(1065, 0);
            this.labelLatency.Name = "labelLatency";
            this.labelLatency.Size = new System.Drawing.Size(113, 30);
            this.labelLatency.TabIndex = 4;
            this.labelLatency.Text = "--ms";
            this.labelLatency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIPServer
            // 
            this.labelIPServer.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelIPServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelIPServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIPServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.labelIPServer.Location = new System.Drawing.Point(1178, 0);
            this.labelIPServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelIPServer.Name = "labelIPServer";
            this.labelIPServer.Size = new System.Drawing.Size(93, 30);
            this.labelIPServer.TabIndex = 0;
            this.labelIPServer.Text = "IP server:";
            this.labelIPServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelIP
            // 
            this.labelIP.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelIP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.labelIP.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelIP.Location = new System.Drawing.Point(1271, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(145, 30);
            this.labelIP.TabIndex = 3;
            this.labelIP.Text = "xxx.xxx.xxx.xxx";
            this.labelIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelIP.Click += new System.EventHandler(this.labelIP_Click);
            // 
            // panelBarraTitulo
            // 
            this.panelBarraTitulo.BackColor = System.Drawing.Color.Black;
            this.panelBarraTitulo.Controls.Add(this.btnRes);
            this.panelBarraTitulo.Controls.Add(this.btnMini);
            this.panelBarraTitulo.Controls.Add(this.btnMaxi);
            this.panelBarraTitulo.Controls.Add(this.btnClose);
            this.panelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelBarraTitulo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelBarraTitulo.Name = "panelBarraTitulo";
            this.panelBarraTitulo.Size = new System.Drawing.Size(1416, 39);
            this.panelBarraTitulo.TabIndex = 1;
            this.panelBarraTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelBarraTitulo_MouseMove);
            // 
            // btnRes
            // 
            this.btnRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRes.Image = ((System.Drawing.Image)(resources.GetObject("btnRes.Image")));
            this.btnRes.Location = new System.Drawing.Point(1336, -1);
            this.btnRes.Margin = new System.Windows.Forms.Padding(4);
            this.btnRes.Name = "btnRes";
            this.btnRes.Size = new System.Drawing.Size(40, 39);
            this.btnRes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnRes.TabIndex = 0;
            this.btnRes.TabStop = false;
            this.btnRes.Visible = false;
            this.btnRes.Click += new System.EventHandler(this.btnRes_Click);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMini.Image = ((System.Drawing.Image)(resources.GetObject("btnMini.Image")));
            this.btnMini.Location = new System.Drawing.Point(1303, -1);
            this.btnMini.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(40, 39);
            this.btnMini.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMini.TabIndex = 0;
            this.btnMini.TabStop = false;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // btnMaxi
            // 
            this.btnMaxi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaxi.Image = ((System.Drawing.Image)(resources.GetObject("btnMaxi.Image")));
            this.btnMaxi.Location = new System.Drawing.Point(1336, 0);
            this.btnMaxi.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaxi.Name = "btnMaxi";
            this.btnMaxi.Size = new System.Drawing.Size(40, 39);
            this.btnMaxi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaxi.TabIndex = 0;
            this.btnMaxi.TabStop = false;
            this.btnMaxi.Click += new System.EventHandler(this.btnMaxi_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1376, -1);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 39);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 817);
            this.Controls.Add(this.panelContenedor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(651, 650);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelContenedor.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelBarraTitulo2.ResumeLayout(false);
            this.panelBarraTitulo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLog.ResumeLayout(false);
            this.panelBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMini)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaxi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.Panel panelBarraTitulo;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelBarraTitulo2;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox btnMaxi;
        private System.Windows.Forms.PictureBox btnRes;
        private System.Windows.Forms.PictureBox btnMini;
        private System.Windows.Forms.Button buttonADCInputs;
        private System.Windows.Forms.Button buttonWelcome;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.TextBox textBoxNumPort;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Button buttonRspbConnect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSimConnect;
        private System.Windows.Forms.Button buttonCalibration;
        private System.Windows.Forms.Button buttonRspbDisconnect;
        private System.Windows.Forms.Button buttonSimDisconnect;
        private System.Windows.Forms.Label labelIPServer;
        private System.Windows.Forms.Label labelLatency;
    }
}

