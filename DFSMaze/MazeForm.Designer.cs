namespace DFSMaze
{
    partial class MazeForm
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
            this.runButton = new System.Windows.Forms.Button();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xEnterTextBox = new System.Windows.Forms.TextBox();
            this.yEnterTextBox = new System.Windows.Forms.TextBox();
            this.yExitTextBox = new System.Windows.Forms.TextBox();
            this.xExitTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.timeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(1497, 824);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(1497, 680);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(75, 20);
            this.nTextBox.TabIndex = 1;
            this.nTextBox.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1555, 662);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "n";
            // 
            // xEnterTextBox
            // 
            this.xEnterTextBox.Location = new System.Drawing.Point(1497, 737);
            this.xEnterTextBox.Name = "xEnterTextBox";
            this.xEnterTextBox.Size = new System.Drawing.Size(25, 20);
            this.xEnterTextBox.TabIndex = 3;
            this.xEnterTextBox.Text = "0";
            // 
            // yEnterTextBox
            // 
            this.yEnterTextBox.Location = new System.Drawing.Point(1547, 737);
            this.yEnterTextBox.Name = "yEnterTextBox";
            this.yEnterTextBox.Size = new System.Drawing.Size(25, 20);
            this.yEnterTextBox.TabIndex = 4;
            this.yEnterTextBox.Text = "0";
            // 
            // yExitTextBox
            // 
            this.yExitTextBox.Location = new System.Drawing.Point(1547, 788);
            this.yExitTextBox.Name = "yExitTextBox";
            this.yExitTextBox.Size = new System.Drawing.Size(25, 20);
            this.yExitTextBox.TabIndex = 6;
            this.yExitTextBox.Text = "3";
            // 
            // xExitTextBox
            // 
            this.xExitTextBox.Location = new System.Drawing.Point(1497, 788);
            this.xExitTextBox.Name = "xExitTextBox";
            this.xExitTextBox.Size = new System.Drawing.Size(25, 20);
            this.xExitTextBox.TabIndex = 5;
            this.xExitTextBox.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1538, 703);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Enter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1509, 719);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1559, 719);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1558, 771);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1507, 771);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "x";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1543, 758);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Exit";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1491, 847);
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(1494, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 15);
            this.timeLabel.TabIndex = 14;
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1618, 859);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yExitTextBox);
            this.Controls.Add(this.xExitTextBox);
            this.Controls.Add(this.yEnterTextBox);
            this.Controls.Add(this.xEnterTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nTextBox);
            this.Controls.Add(this.runButton);
            this.Name = "MazeForm";
            this.Text = "MazeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xEnterTextBox;
        private System.Windows.Forms.TextBox yEnterTextBox;
        private System.Windows.Forms.TextBox yExitTextBox;
        private System.Windows.Forms.TextBox xExitTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label timeLabel;
    }
}

