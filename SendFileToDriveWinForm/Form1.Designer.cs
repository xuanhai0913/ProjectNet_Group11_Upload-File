namespace SendFileToDriveWinForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sendFileBut = new System.Windows.Forms.Button();
            this.linkLabel = new System.Windows.Forms.Label();
            this.linkBox = new System.Windows.Forms.TextBox();
            this.chooseFileLabel = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.chooseFileBut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendFileBut
            // 
            this.sendFileBut.BackColor = System.Drawing.Color.Gainsboro;
            this.sendFileBut.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.sendFileBut.FlatAppearance.BorderSize = 0;
            this.sendFileBut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendFileBut.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendFileBut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sendFileBut.Location = new System.Drawing.Point(73, 169);
            this.sendFileBut.Margin = new System.Windows.Forms.Padding(2);
            this.sendFileBut.Name = "sendFileBut";
            this.sendFileBut.Size = new System.Drawing.Size(255, 41);
            this.sendFileBut.TabIndex = 0;
            this.sendFileBut.Text = "Gửi tệp lên";
            this.sendFileBut.UseVisualStyleBackColor = false;
            this.sendFileBut.Click += new System.EventHandler(this.sendFileBut_Click);
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.ForeColor = System.Drawing.Color.White;
            this.linkLabel.Location = new System.Drawing.Point(34, 29);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(203, 19);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.Text = "Liên kết thư mục trên Drive";
            // 
            // linkBox
            // 
            this.linkBox.AccessibleDescription = "";
            this.linkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkBox.ForeColor = System.Drawing.Color.DarkRed;
            this.linkBox.Location = new System.Drawing.Point(38, 52);
            this.linkBox.Margin = new System.Windows.Forms.Padding(2);
            this.linkBox.Multiline = true;
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(320, 30);
            this.linkBox.TabIndex = 3;
            this.linkBox.WordWrap = false;
            // 
            // chooseFileLabel
            // 
            this.chooseFileLabel.AutoSize = true;
            this.chooseFileLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFileLabel.ForeColor = System.Drawing.Color.White;
            this.chooseFileLabel.Location = new System.Drawing.Point(34, 98);
            this.chooseFileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.chooseFileLabel.Name = "chooseFileLabel";
            this.chooseFileLabel.Size = new System.Drawing.Size(144, 19);
            this.chooseFileLabel.TabIndex = 4;
            this.chooseFileLabel.Text = "Đường dẫn của tệp";
            // 
            // fileBox
            // 
            this.fileBox.AccessibleDescription = "";
            this.fileBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileBox.ForeColor = System.Drawing.Color.DarkRed;
            this.fileBox.Location = new System.Drawing.Point(38, 120);
            this.fileBox.Margin = new System.Windows.Forms.Padding(2);
            this.fileBox.Multiline = true;
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(279, 30);
            this.fileBox.TabIndex = 5;
            this.fileBox.WordWrap = false;
            // 
            // chooseFileBut
            // 
            this.chooseFileBut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFileBut.Location = new System.Drawing.Point(320, 120);
            this.chooseFileBut.Margin = new System.Windows.Forms.Padding(2);
            this.chooseFileBut.Name = "chooseFileBut";
            this.chooseFileBut.Size = new System.Drawing.Size(36, 29);
            this.chooseFileBut.TabIndex = 6;
            this.chooseFileBut.Text = "...";
            this.chooseFileBut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chooseFileBut.UseVisualStyleBackColor = true;
            this.chooseFileBut.Click += new System.EventHandler(this.chooseFileBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(400, 241);
            this.Controls.Add(this.chooseFileBut);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.chooseFileLabel);
            this.Controls.Add(this.linkBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.sendFileBut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envio de arquivo para o Drive";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendFileBut;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.TextBox linkBox;
        private System.Windows.Forms.Label chooseFileLabel;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.Button chooseFileBut;
    }
}

