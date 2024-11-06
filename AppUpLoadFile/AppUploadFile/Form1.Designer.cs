using System.Windows.Forms;

namespace UploadFilesToDrive
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtFolderId;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnCancelUpload;
        private System.Windows.Forms.Button btnRemoveFile;
        private System.Windows.Forms.Button btnDownloadedFiles;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblFolderName;
        private System.Windows.Forms.Label lblFiles;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtFolderId = new System.Windows.Forms.TextBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnCancelUpload = new System.Windows.Forms.Button();
            this.btnRemoveFile = new System.Windows.Forms.Button();
            this.btnDownloadedFiles = new System.Windows.Forms.Button();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblFolderName = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.btnListFilesInFolder = new System.Windows.Forms.Button();
            this.bntRemoveAll = new System.Windows.Forms.Button();
            this.lstFolders = new System.Windows.Forms.ListBox();
            this.btnGetFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFolderId
            // 
            this.txtFolderId.Location = new System.Drawing.Point(100, 17);
            this.txtFolderId.Name = "txtFolderId";
            this.txtFolderId.Size = new System.Drawing.Size(240, 20);
            this.txtFolderId.TabIndex = 1;
            // 
            // btnAddFile
            // 
            this.btnAddFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddFile.Location = new System.Drawing.Point(482, 48);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(168, 23);
            this.btnAddFile.TabIndex = 2;
            this.btnAddFile.Text = "Thêm tệp upload";
            this.btnAddFile.UseVisualStyleBackColor = false;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.Location = new System.Drawing.Point(482, 82);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(168, 23);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnCancelUpload
            // 
            this.btnCancelUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancelUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelUpload.Location = new System.Drawing.Point(482, 116);
            this.btnCancelUpload.Name = "btnCancelUpload";
            this.btnCancelUpload.Size = new System.Drawing.Size(168, 23);
            this.btnCancelUpload.TabIndex = 6;
            this.btnCancelUpload.Text = "Hủy Upload";
            this.btnCancelUpload.UseVisualStyleBackColor = false;
            this.btnCancelUpload.Click += new System.EventHandler(this.btnCancelUpload_Click);
            // 
            // btnRemoveFile
            // 
            this.btnRemoveFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRemoveFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveFile.Location = new System.Drawing.Point(482, 152);
            this.btnRemoveFile.Name = "btnRemoveFile";
            this.btnRemoveFile.Size = new System.Drawing.Size(76, 23);
            this.btnRemoveFile.TabIndex = 7;
            this.btnRemoveFile.Text = "Xóa file";
            this.btnRemoveFile.UseVisualStyleBackColor = false;
            this.btnRemoveFile.Click += new System.EventHandler(this.btnRemoveFile_Click);
            // 
            // btnDownloadedFiles
            // 
            this.btnDownloadedFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDownloadedFiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadedFiles.Location = new System.Drawing.Point(482, 220);
            this.btnDownloadedFiles.Name = "btnDownloadedFiles";
            this.btnDownloadedFiles.Size = new System.Drawing.Size(168, 23);
            this.btnDownloadedFiles.TabIndex = 8;
            this.btnDownloadedFiles.Text = "Download file từ thư mục drive";
            this.btnDownloadedFiles.UseVisualStyleBackColor = false;
            this.btnDownloadedFiles.Click += new System.EventHandler(this.btnDownloadFiles_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.Location = new System.Drawing.Point(101, 49);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(367, 199);
            this.lstFiles.TabIndex = 3;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(27, 262);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(623, 103);
            this.txtResult.TabIndex = 10;
            // 
            // lblFolderName
            // 
            this.lblFolderName.AutoSize = true;
            this.lblFolderName.Location = new System.Drawing.Point(12, 20);
            this.lblFolderName.Name = "lblFolderName";
            this.lblFolderName.Size = new System.Drawing.Size(75, 13);
            this.lblFolderName.TabIndex = 0;
            this.lblFolderName.Text = "Tên Thư Mục:";
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(12, 50);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(86, 13);
            this.lblFiles.TabIndex = 4;
            this.lblFiles.Text = "Danh Sách Tệp:";
            // 
            // btnListFilesInFolder
            // 
            this.btnListFilesInFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnListFilesInFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListFilesInFolder.Location = new System.Drawing.Point(482, 186);
            this.btnListFilesInFolder.Name = "btnListFilesInFolder";
            this.btnListFilesInFolder.Size = new System.Drawing.Size(168, 23);
            this.btnListFilesInFolder.TabIndex = 11;
            this.btnListFilesInFolder.Text = "Danh sách file từ thư mục drive";
            this.btnListFilesInFolder.UseVisualStyleBackColor = false;
            this.btnListFilesInFolder.Click += new System.EventHandler(this.btnListFilesInFolder_Click);
            // 
            // bntRemoveAll
            // 
            this.bntRemoveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bntRemoveAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntRemoveAll.Location = new System.Drawing.Point(574, 152);
            this.bntRemoveAll.Name = "bntRemoveAll";
            this.bntRemoveAll.Size = new System.Drawing.Size(76, 23);
            this.bntRemoveAll.TabIndex = 12;
            this.bntRemoveAll.Text = "Xóa tất cả";
            this.bntRemoveAll.UseVisualStyleBackColor = false;
            this.bntRemoveAll.Click += new System.EventHandler(this.bntRemoveAll_Click);
            // 
            // lstFolders
            // 
            this.lstFolders.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstFolders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstFolders.FormattingEnabled = true;
            this.lstFolders.Location = new System.Drawing.Point(343, 37);
            this.lstFolders.Name = "lstFolders";
            this.lstFolders.Size = new System.Drawing.Size(125, 69);
            this.lstFolders.TabIndex = 13;
            this.lstFolders.Visible = false;
            this.lstFolders.SelectedIndexChanged += new System.EventHandler(this.lstFolders_SelectedIndexChanged_1);
            // 
            // btnGetFolder
            // 
            this.btnGetFolder.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnGetFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetFolder.Location = new System.Drawing.Point(343, 16);
            this.btnGetFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btnGetFolder.Name = "btnGetFolder";
            this.btnGetFolder.Size = new System.Drawing.Size(125, 22);
            this.btnGetFolder.TabIndex = 14;
            this.btnGetFolder.Text = "Chọn thư mục";
            this.btnGetFolder.UseVisualStyleBackColor = false;
            this.btnGetFolder.Click += new System.EventHandler(this.btnGetFolder_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(675, 376);
            this.Controls.Add(this.btnGetFolder);
            this.Controls.Add(this.lstFolders);
            this.Controls.Add(this.bntRemoveAll);
            this.Controls.Add(this.btnListFilesInFolder);
            this.Controls.Add(this.lblFolderName);
            this.Controls.Add(this.txtFolderId);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnCancelUpload);
            this.Controls.Add(this.btnRemoveFile);
            this.Controls.Add(this.btnDownloadedFiles);
            this.Controls.Add(this.txtResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Upload Files to Google Drive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnListFilesInFolder;
        private System.Windows.Forms.Button bntRemoveAll;
        private System.Windows.Forms.ListBox lstFolders;
        private System.Windows.Forms.Button btnGetFolder;
    }
}
