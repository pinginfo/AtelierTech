namespace RobotMoveWForm
{
    partial class frmConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxCameras = new System.Windows.Forms.ComboBox();
            this.cbxBluetoothDevices = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.prbConnection = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(319, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect to Lego Mindstrom Ev3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select a camera feed :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bluetooth devices";
            // 
            // cbxCameras
            // 
            this.cbxCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCameras.FormattingEnabled = true;
            this.cbxCameras.Location = new System.Drawing.Point(40, 81);
            this.cbxCameras.Name = "cbxCameras";
            this.cbxCameras.Size = new System.Drawing.Size(348, 21);
            this.cbxCameras.TabIndex = 3;
            this.cbxCameras.SelectedIndexChanged += new System.EventHandler(this.cbxCameras_SelectedIndexChanged);
            // 
            // cbxBluetoothDevices
            // 
            this.cbxBluetoothDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBluetoothDevices.FormattingEnabled = true;
            this.cbxBluetoothDevices.Location = new System.Drawing.Point(40, 138);
            this.cbxBluetoothDevices.Name = "cbxBluetoothDevices";
            this.cbxBluetoothDevices.Size = new System.Drawing.Size(183, 21);
            this.cbxBluetoothDevices.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(229, 136);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(159, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect to device";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(40, 216);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(348, 68);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Launch Robot";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // prbConnection
            // 
            this.prbConnection.Location = new System.Drawing.Point(40, 176);
            this.prbConnection.Name = "prbConnection";
            this.prbConnection.Size = new System.Drawing.Size(348, 23);
            this.prbConnection.TabIndex = 7;
            // 
            // frmConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 288);
            this.Controls.Add(this.prbConnection);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cbxBluetoothDevices);
            this.Controls.Add(this.cbxCameras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmConnection";
            this.Text = "frmConnection";
            this.Load += new System.EventHandler(this.frmConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxCameras;
        private System.Windows.Forms.ComboBox cbxBluetoothDevices;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar prbConnection;
    }
}