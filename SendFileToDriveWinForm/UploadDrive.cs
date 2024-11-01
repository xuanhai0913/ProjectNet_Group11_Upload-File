using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SendFileToDriveWinForm
{
    public class UploadDrive
    {
        // Phương thức này sẽ yêu cầu quyền truy cập vào tài khoản Google Drive của người dùng
        public async Task<UserCredential> ObtemAutorizacaoAsync(string duongDanChungThuc)
        {
            try
            {
                var tokenStorage = new FileDataStore("TokenStorage", true);
                using (var stream = new FileStream(duongDanChungThuc, FileMode.Open, FileAccess.Read))
                {
                    var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { DriveService.Scope.DriveFile },
                        "user",
                        CancellationToken.None,
                        tokenStorage);
                    return credential;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi ủy quyền: " + ex.Message);
                return null;
            }
        }

        // Phương thức khởi tạo dịch vụ Drive
        public DriveService CriaDriveService(UserCredential credential)
        {
            if (credential == null)
            {
                Console.WriteLine("Không thể khởi tạo dịch vụ Drive: thông tin xác thực không hợp lệ.");
                return null;
            }

            return new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Upload to Drive",
            });
        }

        // Tạo metadata cho tệp mới trong Google Drive
        public Google.Apis.Drive.v3.Data.File TaoMetadataTepTrenDrive(string tenTepTrenDrive, string idThuMucDich)
        {
            return new Google.Apis.Drive.v3.Data.File()
            {
                Name = tenTepTrenDrive,
                Parents = new List<string> { idThuMucDich }
            };
        }

        // Tải tệp lên Google Drive
        public async Task TaiTepLenDriveAsync(DriveService service, Google.Apis.Drive.v3.Data.File fileMetadata, string duongDanTep)
        {
            if (service == null)
            {
                Console.WriteLine("Dịch vụ Drive không khả dụng.");
                return;
            }

            try
            {
                using (var stream = new FileStream(duongDanTep, FileMode.Open))
                {
                    var request = service.Files.Create(fileMetadata, stream, "application/octet-stream");
                    request.Fields = "id";
                    await request.UploadAsync();

                    Console.WriteLine("Tệp đã được tải lên với ID: " + request.ResponseBody?.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tải tệp lên Drive: " + ex.Message);
            }
        }

        // Xóa tất cả tệp trong thư mục chỉ định
        public async Task XoaTatCaTapTinTrongThuMucAsync(DriveService service, string idThuMucDich)
        {
            if (service == null)
            {
                Console.WriteLine("Dịch vụ Drive không khả dụng.");
                return;
            }

            try
            {
                var listRequest = service.Files.List();
                listRequest.Q = $"'{idThuMucDich}' in parents";
                listRequest.Fields = "nextPageToken, files(id, name)";

                var fileList = await listRequest.ExecuteAsync();

                if (fileList.Files != null && fileList.Files.Count > 0)
                {
                    Console.WriteLine("Các tệp sẽ bị xóa:");

                    foreach (var file in fileList.Files)
                    {
                        Console.WriteLine($"ID: {file.Id} - Tên: {file.Name}");
                        await service.Files.Delete(file.Id).ExecuteAsync();
                        Console.WriteLine($"Đã xóa tệp: {file.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Không tìm thấy tệp nào trong thư mục.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tệp: " + ex.Message);
            }
        }
    }
}
