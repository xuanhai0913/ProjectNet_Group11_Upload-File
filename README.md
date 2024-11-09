# ProjectNet_Group11_Upload-File

## Giới Thiệu
ProjectNet_Group11_Upload-File là một ứng dụng upload file lên Drive được phát triển bằng ngôn ngữ lập trình C# và Windows Forms. Ứng dụng cho phép người dùng tải lên file, quản lý file, v.v.

## Các Tính Năng Chính
- **Quản lý File**: Cho phép người dùng tải lên và quản lý file trực tiếp trên giao diện.
- **Tìm kiếm và Bộ lọc**: Hỗ trợ tìm kiếm file và lọc dữ liệu dễ dàng.
- **Tích hợp API**: Kết nối và đồng bộ dữ liệu với API của Google Drive.
- **Giao diện Thân Thiện**: Thiết kế UI/UX tối ưu, dễ sử dụng cho người dùng.

## Yêu Cầu Hệ Thống
- **Phần mềm**: .NET Framework 4.7.2 trở lên, Visual Studio hoặc IDE hỗ trợ C#
- **Thư viện bên ngoài**: Các thư viện cần thiết như Google.Apis.Drive.v3 để tích hợp API của Google Drive.

## Hướng dẫn cài đặt
### Bước 1: Chuẩn bị môi trường
- Cài đặt [Visual Studio](https://visualstudio.microsoft.com/) (2019 hoặc mới hơn).
- Đảm bảo đã cài đặt .NET Framework 4.7.2 hoặc mới hơn.

### Bước 2: Tải mã nguồn
1. Clone repository hoặc tải ZIP từ [GitHub](https://github.com/xuanhai0913/ProjectNet_Group11_Upload-File).
2. Giải nén file ZIP vào thư mục mong muốn.

### Bước 3: Mở dự án
1. Mở Visual Studio.
2. Chọn "Open a project or solution" và điều hướng đến thư mục chứa mã nguồn.
3. Mở file dự án (.sln).

### Bước 4: Cài đặt thư viện
1. Mở "Package Manager Console" (Tools > NuGet Package Manager > Package Manager Console).
2. Chạy lệnh:
   ```bash
   Install-Package Google.Apis.Drive.v3

### Bước 5: Chạy ứng dụng
1. Nhấn F5 hoặc chọn "Start Debugging" để chạy ứng dụng.
2. Bắt đầu sử dụng để tải lên và quản lý file trên Google Drive.

