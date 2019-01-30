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
            this.btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
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
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(149, 378);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(48, 39);
            this.btn.TabIndex = 2;
            this.btn.Tag = "0";
            this.btn.Text = "-45°";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 39);
            this.button2.TabIndex = 3;
            this.button2.Tag = "1";
            this.button2.Text = "↑";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.MoveRob);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(257, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 39);
            this.button3.TabIndex = 4;
            this.button3.Tag = "2";
            this.button3.Text = "45°";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(149, 423);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 39);
            this.button4.TabIndex = 5;
            this.button4.Tag = "3";
            this.button4.Text = "<-";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(203, 423);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(48, 39);
            this.button5.TabIndex = 6;
            this.button5.Tag = "4";
            this.button5.Text = "Stop";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(257, 423);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(48, 39);
            this.button6.TabIndex = 7;
            this.button6.Tag = "5";
            this.button6.Text = "->";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(149, 468);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(48, 39);
            this.button7.TabIndex = 8;
            this.button7.Tag = "6";
            this.button7.Text = "-135°";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(203, 468);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(48, 39);
            this.button8.TabIndex = 9;
            this.button8.Tag = "7";
            this.button8.Text = "↓";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(257, 468);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(48, 39);
            this.button9.TabIndex = 10;
            this.button9.Tag = "8";
            this.button9.Text = "135°";
            this.button9.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn);
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
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.PictureBox imgProcessed;
    }
}