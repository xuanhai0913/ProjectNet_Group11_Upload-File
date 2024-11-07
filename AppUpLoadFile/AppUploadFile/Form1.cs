using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UploadFilesToDrive
{
    public partial class Form1 : Form
    {
        private DriveService driveService;
        private List<string> filesToUpload = new List<string>();
        private Dictionary<string, string> uploadedFiles = new Dictionary<string, string>(); // filePath -> fileId
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            InitializeDriveService();
            this.Click += new EventHandler(Form1_Click);
            // Đăng ký sự kiện Click cho tất cả các điều khiển
            // Nghĩa là bất kỳ hành động click nào trong form đều được bắt được bởi Form1
            foreach (Control control in this.Controls)
            {
                control.Click += new EventHandler(Form1_Click);
            }
        }

        // Khởi tạo dịch vụ Google Drive với thông tin xác thực người dùng
        private void InitializeDriveService()
        {
            try
            {
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    // Thêm quyền truy cập vào Drive
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        new[] { DriveService.Scope.Drive }, // Cấp quyền truy cập toàn bộ Drive
                        "user",
                        CancellationToken.None).Result;
                }

                driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Upload Files to Drive",
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo dịch vụ Drive: {ex.Message}");
            }
        }

        // Mở hộp thoại để chọn tệp và thêm tệp vào danh sách để upload
        private void btnAddFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        filesToUpload.Add(file);
                        lstFiles.Items.Add(file);
                    }
                }
            }
        }

        // Bắt đầu quá trình upload tệp lên Google Drive
        private async void btnUpload_Click(object sender, EventArgs e)
        {
            string folderName = txtFolderId.Text.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Vui lòng nhập tên thư mục.");
                return;
            }

            string folderId = await GetOrCreateFolder(folderName);
            if (string.IsNullOrEmpty(folderId))
            {
                txtResult.Text = "Không thể tạo hoặc lấy thư mục.";
                return;
            }

            txtResult.Text = "Đang upload...";
            cancellationTokenSource = new CancellationTokenSource();

            // Tạo một danh sách tạm thời để lưu các file cần upload
            var filesToUploadTemp = new List<string>(filesToUpload);

            foreach (var file in filesToUploadTemp)
            {
                await UploadFile(file, folderId);
            }

            txtResult.AppendText(Environment.NewLine + "Upload hoàn tất.");
        }

        // Kiểm tra xem thư mục đã tồn tại chưa và tạo mới nếu chưa
        private async Task<string> GetOrCreateFolder(string folderName)
        {
            // Kiểm tra xem thư mục đã tồn tại chưa
            var folderId = await FindFolderId(folderName);
            if (string.IsNullOrEmpty(folderId))
            {
                // Nếu thư mục chưa tồn tại, tạo thư mục mới
                folderId = await CreateFolder(folderName);
            }
            return folderId;
        }

        // Tìm ID của thư mục theo tên
        private async Task<string> FindFolderId(string folderName)
        {
            try
            {
                // Tạo truy vấn tìm thư mục theo tên
                var request = driveService.Files.List();
                request.Q = $"mimeType='application/vnd.google-apps.folder' and name='{folderName}' and trashed=false";
                request.Fields = "files(id, name)";

                var result = await request.ExecuteAsync();
                if (result.Files.Count > 0)
                {
                    return result.Files[0].Id; // Trả về ID của thư mục đầu tiên tìm thấy
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm thư mục: {ex.Message}");
            }
            return null; // Nếu không tìm thấy thư mục nào
        }

        // Tạo một thư mục mới trên Google Drive
        private async Task<string> CreateFolder(string folderName)
        {
            var folderMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };

            try
            {
                var request = driveService.Files.Create(folderMetadata);
                request.Fields = "id";
                var folder = await request.ExecuteAsync();
                return folder.Id;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo thư mục: {ex.Message}");
                return null;
            }
        }

        // Upload một tệp lên Google Drive
        private async Task UploadFile(string filePath, string folderId)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath),
                Parents = new List<string> { folderId }
            };

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var request = driveService.Files.Create(fileMetadata, fileStream, "application/octet-stream");
                request.Fields = "id";

                try
                {
                    var progress = await request.UploadAsync(cancellationTokenSource.Token);
                    var fileUploaded = request.ResponseBody;
                    if (progress.Status == UploadStatus.Completed && fileUploaded != null)
                    {
                        uploadedFiles[filePath] = fileUploaded.Id; // Lưu ID tệp để tham chiếu sau
                        lstFiles.Items.Remove(filePath); // Xóa file khỏi danh sách hiển thị
                        filesToUpload.Remove(filePath); // Xóa file khỏi danh sách cần upload
                        txtResult.AppendText(Environment.NewLine + $"Đã upload: {filePath}"); // Hiển thị thông báo upload thành công
                    }
                    else if (progress.Status == UploadStatus.Failed)
                    {
                        // Chỉ hiển thị thông báo thất bại nếu không phải do hủy
                        if (progress.Exception == null)
                        {
                            txtResult.AppendText(Environment.NewLine + $"Upload file {filePath} thất bại.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtResult.AppendText(Environment.NewLine + $"Lỗi trong quá trình upload file {filePath}: {ex.Message}");
                }
            }
        }

        // Hủy quá trình upload hiện tại
        private void btnCancelUpload_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            txtResult.AppendText(Environment.NewLine + "Upload đã bị hủy.");
        }

        // Xóa một tệp được chọn khỏi danh sách
        private async void btnRemoveFile_Click(object sender, EventArgs e)
        {
            // Check if any item is selected in the list
            if (lstFiles.SelectedItem != null)
            {
                // Store the selected file path
                string selectedFile = lstFiles.SelectedItem.ToString();

                // Remove the selected file from the list
                filesToUpload.Remove(selectedFile);
                lstFiles.Items.Remove(selectedFile);

                // Optionally, update the result text box to inform the user
                txtResult.AppendText(Environment.NewLine + $"Đã xóa tệp: {selectedFile}"); // Ensure new line after the message
            }
            else
            {
                txtResult.AppendText(Environment.NewLine + "Vui lòng chọn tệp để xóa."); // New line for this message as well
            }
        }

        // Xóa tất cả các mục trong danh sách
        private void bntRemoveAll_Click(object sender, EventArgs e)
        {
            // Xóa tất cả các mục trong ListBox
            lstFiles.Items.Clear();
            filesToUpload.Clear(); // Xóa tất cả các tệp trong danh sách filesToUpload
            txtResult.AppendText(Environment.NewLine + "Đã xóa tất cả các tệp trong danh sách.");
        }

        // Liệt kê tất cả các tệp trong thư mục đã cho
        private async Task ListFilesInFolder(string folderName, ListBox lstFiles)
        {
            var folderId = await FindFolderId(folderName); // Tìm ID thư mục

            if (!string.IsNullOrEmpty(folderId))
            {
                try
                {
                    // Tạo truy vấn tìm các tệp trong thư mục
                    var request = driveService.Files.List();
                    request.Q = $"'{folderId}' in parents and trashed=false"; // Chỉ lấy tệp trong thư mục cụ thể
                    var result = await request.ExecuteAsync();
                    lstFiles.Items.Clear(); // Xóa danh sách hiện tại
                    request.Fields = "files(id, name)";
                    if (result.Files.Count > 0)
                    {
                        foreach (var file in result.Files)
                        {
                            lstFiles.Items.Add(file.Name); // Thêm tên tệp vào danh sách
                        }
                    }
                    else { MessageBox.Show($"{folderName} trống."); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi lấy danh sách tệp: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy thư mục với tên đã cho.");
            }
        }



        // Nút để liệt kê các tệp trong thư mục
        private async void btnListFilesInFolder_Click(object sender, EventArgs e)
        {
            string folderName = txtFolderId.Text.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Vui lòng nhập tên thư mục.");
                return;
            }

            await ListFilesInFolder(folderName, lstFiles);
        }

        // download các tệp từ Google Drive về máy tính
        private async void btnDownloadFiles_Click(object sender, EventArgs e)
        {
            string folderName = txtFolderId.Text.Trim();
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("Vui lòng nhập tên thư mục.");
                return;
            }

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    txtResult.Text = "Đang download...";
                    string downloadPath = folderBrowserDialog.SelectedPath;
                    await DownloadFilesFromList(lstFiles, folderName, downloadPath);
                    txtResult.AppendText(Environment.NewLine + "Download hoàn tất.");
                }
            }
        }

        // download các tệp được chọn từ danh sách
        private async Task DownloadFilesFromList(ListBox lstFiles, string folderName, string downloadPath)
        {
            try
            {
                var folderId = await FindFolderId(folderName); // Tìm ID thư mục

                if (!string.IsNullOrEmpty(folderId))
                {
                    // Tạo danh sách tạm thời để lưu các tệp đã download thành công
                    List<string> downloadedFiles = new List<string>();

                    // Sử dụng một danh sách sao chép để tránh lỗi trong quá trình lặp
                    var filesToDownload = lstFiles.Items.Cast<string>().ToList();

                    foreach (var fileName in filesToDownload)
                    {
                        var fileId = await GetFileIdByName(fileName, folderId); // Tìm ID của tệp theo tên và ID thư mục

                        if (!string.IsNullOrEmpty(fileId))
                        {
                            var request = driveService.Files.Get(fileId);
                            using (var stream = new FileStream(Path.Combine(downloadPath, fileName), FileMode.Create, FileAccess.Write))
                            {
                                await request.DownloadAsync(stream); // download tệp
                            }

                            // Xóa tệp đã download khỏi danh sách hiển thị ngay lập tức
                            lstFiles.Items.Remove(fileName);

                            // Thêm tệp đã download vào danh sách
                            downloadedFiles.Add(fileName);
                            txtResult.AppendText(Environment.NewLine + $"Đã download thành công tệp: {fileName}.");
                        }
                        else
                        {
                            MessageBox.Show($"Không tìm thấy tệp: {fileName}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thư mục với tên đã cho.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi download tệp: {ex.Message}");
            }
        }

        // Hàm hỗ trợ để tìm ID tệp theo tên trong thư mục
        private async Task<string> GetFileIdByName(string fileName, string folderId)
        {
            var request = driveService.Files.List();
            request.Q = $"'{folderId}' in parents and name='{fileName}' and trashed=false";
            request.Fields = "files(id)";

            var result = await request.ExecuteAsync();
            return result.Files.Count > 0 ? result.Files[0].Id : null; // Trả về ID của tệp đầu tiên tìm thấy
        }

        private void btnGetFolder_Click(object sender, EventArgs e)
        {
            lstFolders.Visible = !lstFolders.Visible;
            if (lstFolders.Visible)
            {
                var request = driveService.Files.List();
                request.Q = "mimeType = 'application/vnd.google-apps.folder' and trashed = false";
                request.Fields = "files(id, name)";

                var result = request.Execute();
                lstFolders.Items.Clear();

                foreach (var folder in result.Files)
                {
                    lstFolders.Items.Add(folder.Name);
                }
            }

            // Chỉ lấy ID thư mục nếu người dùng đã chọn một mục
            if (lstFolders.SelectedItem != null)
            {
                txtFolderId.Clear();
                string selectedFolderId = lstFolders.SelectedItem.ToString();
                txtFolderId.AppendText($"{selectedFolderId}");
            }
        }
        // Lớp phụ trợ để lưu tên và ID
        public class ListItem
        {
            public string Name { get; set; }
            public string Id { get; set; }

            public ListItem(string name, string id)
            {
                Name = name;
                Id = id;
            }

            public override string ToString()
            {
                return Name; // Hiển thị tên trong ListBox
            }
        }

        private void lstFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        // Thêm sự kiện Click cho form
        private void Form1_Click(object sender, EventArgs e)
        {
            // Ẩn lstFolders khi nhấp vào bất kỳ đâu trên form
            if (!lstFolders.Bounds.Contains(PointToClient(Cursor.Position)))
            {
                lstFolders.Visible = false;
            }
        }

        private void lstFolders_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstFolders.SelectedItem != null)
            {
                // Ghi giá trị của item đã chọn vào TextBox
                txtFolderId.Text = lstFolders.SelectedItem.ToString();
            }
        }
    }
}
