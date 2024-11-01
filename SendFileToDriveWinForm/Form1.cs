using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendFileToDriveWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Bất kỳ logic khởi tạo nào có thể được đặt ở đây.
        }

        private void chooseFileBut_Click(object sender, EventArgs e)
        {
            // Mở một hộp thoại để chọn tệp
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = @"C:\temp\";
                ofd.Filter = "Tất cả các tệp (*.*)|*.*";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileBox.Text = ofd.FileName;
                }
            }
        }

        private async void sendFileBut_Click(object sender, EventArgs e)
        {
            UploadDrive uploadDrive = new UploadDrive();
            string folderId = String.Empty;

            // Kiểm tra tính hợp lệ của liên kết thư mục
            bool isValidLink = IsValidFolderLink(linkBox.Text, out folderId);
            if (!isValidLink)
            {
                MessageBox.Show("Vui lòng nhập một liên kết hợp lệ!", "Liên kết không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem có tệp nào được chọn không
            if (string.IsNullOrEmpty(fileBox.Text))
            {
                MessageBox.Show("Vui lòng chọn tệp!", "Tệp không được chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem tệp có tồn tại không
            if (!System.IO.File.Exists(fileBox.Text)) // Sử dụng System.IO.File để rõ ràng
            {
                MessageBox.Show("Đường dẫn tới tệp không hợp lệ!", "Nhập một đường dẫn hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string credentialsPath = "TênTệpChứngNhận"; // Đường dẫn đến tệp chứng nhận của bạn
            UserCredential credential = await uploadDrive.ObtemAutorizacaoAsync(credentialsPath);
            DriveService service = uploadDrive.CriaDriveService(credential);

            if (service == null)
            {
                MessageBox.Show("Không thể khởi tạo dịch vụ Google Drive.", "Lỗi dịch vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string fileNameOnDrive = Path.GetFileName(fileBox.Text); // Lấy tên tệp được chọn

            var fileMetadata = uploadDrive.TaoMetadataTepTrenDrive(fileNameOnDrive, folderId);
            await uploadDrive.TaiTepLenDriveAsync(service, fileMetadata, fileBox.Text);

            MessageBox.Show("Tệp đã được gửi!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Phương thức để kiểm tra liên kết thư mục và trích xuất ID thư mục
        private bool IsValidFolderLink(string link, out string folderId)
        {
            folderId = string.Empty;

            if (link.StartsWith("https://drive.google.com/drive"))
            {
                string[] parts = link.Split('/');
                if (parts.Length >= 5)
                {
                    folderId = parts[5];
                    if (link.Contains("/u/1"))
                    {
                        folderId = parts[7];
                    }
                    return true;
                }
            }
            else if (link.StartsWith("drive.google.com/drive"))
            {
                string[] parts = link.Split('/');
                if (parts.Length >= 4)
                {
                    folderId = parts[3];
                    if (link.Contains("/u/1"))
                    {
                        folderId = parts[5];
                    }
                    return true;
                }
            }

            return false; // Liên kết không hợp lệ
        }
    }
}
