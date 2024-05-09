namespace MaddogSimGUI
{
    partial class FormCalibration
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
            this.panelCalibration = new System.Windows.Forms.Panel();
            this.buttonOtherSystemsCalibration = new System.Windows.Forms.Button();
            this.buttonSecondaryFlightControlCalibration = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPrimaryFlightControlCalibration = new System.Windows.Forms.Button();
            this.panelCalibration.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCalibration
            // 
            this.panelCalibration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(86)))));
            this.panelCalibration.Controls.Add(this.buttonOtherSystemsCalibration);
            this.panelCalibration.Controls.Add(this.buttonSecondaryFlightControlCalibration);
            this.panelCalibration.Controls.Add(this.label3);
            this.panelCalibration.Controls.Add(this.label2);
            this.panelCalibration.Controls.Add(this.label1);
            this.panelCalibration.Controls.Add(this.buttonPrimaryFlightControlCalibration);
            this.panelCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCalibration.Location = new System.Drawing.Point(0, 0);
            this.panelCalibration.Name = "panelCalibration";
            this.panelCalibration.Size = new System.Drawing.Size(1163, 617);
            this.panelCalibration.TabIndex = 0;
            this.panelCalibration.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCalibration_Paint);
            // 
            // buttonOtherSystemsCalibration
            // 
            this.buttonOtherSystemsCalibration.Location = new System.Drawing.Point(502, 449);
            this.buttonOtherSystemsCalibration.Name = "buttonOtherSystemsCalibration";
            this.buttonOtherSystemsCalibration.Size = new System.Drawing.Size(133, 56);
            this.buttonOtherSystemsCalibration.TabIndex = 9;
            this.buttonOtherSystemsCalibration.UseVisualStyleBackColor = true;
            this.buttonOtherSystemsCalibration.Click += new System.EventHandler(this.buttonOtherSystemsCalibration_Click);
            // 
            // buttonSecondaryFlightControlCalibration
            // 
            this.buttonSecondaryFlightControlCalibration.Location = new System.Drawing.Point(502, 282);
            this.buttonSecondaryFlightControlCalibration.Name = "buttonSecondaryFlightControlCalibration";
            this.buttonSecondaryFlightControlCalibration.Size = new System.Drawing.Size(133, 56);
            this.buttonSecondaryFlightControlCalibration.TabIndex = 8;
            this.buttonSecondaryFlightControlCalibration.UseVisualStyleBackColor = true;
            this.buttonSecondaryFlightControlCalibration.Click += new System.EventHandler(this.buttonSecondaryFlightControlCalibration_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label3.Location = new System.Drawing.Point(384, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 41);
            this.label3.TabIndex = 6;
            this.label3.Text = "Other Systems Calibration";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label2.Location = new System.Drawing.Point(319, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(548, 41);
            this.label2.TabIndex = 5;
            this.label2.Text = "Secondary Flight Controls Calibration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(151)))), ((int)(((byte)(151)))));
            this.label1.Location = new System.Drawing.Point(335, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(512, 41);
            this.label1.TabIndex = 4;
            this.label1.Text = "Primary Flight Controls Calibration";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonPrimaryFlightControlCalibration
            // 
            this.buttonPrimaryFlightControlCalibration.Location = new System.Drawing.Point(502, 95);
            this.buttonPrimaryFlightControlCalibration.Name = "buttonPrimaryFlightControlCalibration";
            this.buttonPrimaryFlightControlCalibration.Size = new System.Drawing.Size(133, 56);
            this.buttonPrimaryFlightControlCalibration.TabIndex = 0;
            this.buttonPrimaryFlightControlCalibration.UseVisualStyleBackColor = true;
            this.buttonPrimaryFlightControlCalibration.Click += new System.EventHandler(this.buttonPrimaryFlightControlCalibration_Click);
            // 
            // FormCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 617);
            this.Controls.Add(this.panelCalibration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCalibration";
            this.Text = "FormCalibration";
            this.Load += new System.EventHandler(this.FormCalibration_Load);
            this.panelCalibration.ResumeLayout(false);
            this.panelCalibration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCalibration;
        private System.Windows.Forms.Button buttonPrimaryFlightControlCalibration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOtherSystemsCalibration;
        private System.Windows.Forms.Button buttonSecondaryFlightControlCalibration;
    }
}