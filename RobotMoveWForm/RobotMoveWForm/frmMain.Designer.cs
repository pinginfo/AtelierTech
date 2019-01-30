namespace RobotMoveWForm
{
    partial class frmMain
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
            this.imgBase = new System.Windows.Forms.PictureBox();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.imgProcessed = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProcessed)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(135, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rob\'Move";
            // 
            // imgBase
            // 
            this.imgBase.Location = new System.Drawing.Point(364, 25);
            this.imgBase.Name = "imgBase";
            this.imgBase.Size = new System.Drawing.Size(655, 489);
            this.imgBase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBase.TabIndex = 1;
            this.imgBase.TabStop = false;
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(149, 378);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(48, 39);
            this.btn0.TabIndex = 2;
            this.btn0.Tag = "0";
            this.btn0.Text = "-45°";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(203, 378);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(48, 39);
            this.btn1.TabIndex = 3;
            this.btn1.Tag = "1";
            this.btn1.Text = "↑";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(257, 378);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(48, 39);
            this.btn2.TabIndex = 4;
            this.btn2.Tag = "2";
            this.btn2.Text = "45°";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(149, 423);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(48, 39);
            this.btn3.TabIndex = 5;
            this.btn3.Tag = "3";
            this.btn3.Text = "<-";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(203, 423);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(48, 39);
            this.btn4.TabIndex = 6;
            this.btn4.Tag = "4";
            this.btn4.Text = "Stop";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(257, 423);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(48, 39);
            this.btn5.TabIndex = 7;
            this.btn5.Tag = "5";
            this.btn5.Text = "->";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(149, 468);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(48, 39);
            this.btn6.TabIndex = 8;
            this.btn6.Tag = "6";
            this.btn6.Text = "-135°";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(203, 468);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(48, 39);
            this.btn7.TabIndex = 9;
            this.btn7.Tag = "7";
            this.btn7.Text = "↓";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.MoveRob);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(257, 468);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(48, 39);
            this.btn8.TabIndex = 10;
            this.btn8.Tag = "8";
            this.btn8.Text = "135°";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.MoveRob);
            // 
            // imgProcessed
            // 
            this.imgProcessed.Location = new System.Drawing.Point(24, 423);
            this.imgProcessed.Name = "imgProcessed";
            this.imgProcessed.Size = new System.Drawing.Size(100, 50);
            this.imgProcessed.TabIndex = 11;
            this.imgProcessed.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 526);
            this.Controls.Add(this.imgProcessed);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.imgBase);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Rob\'Move";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgProcessed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgBase;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.PictureBox imgProcessed;
    }
}