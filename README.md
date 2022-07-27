# Project 2: Tool Management (Quản lí key phần mềm)

Đây là bản git tổng hợp của front-end ([commit #43f34e2](https://github.com/sakamiq1/Frontend-Stuff/commit/43f34e2283794114dcb4b96952ca9eb6a9d93576)) và back-end ([commit #9b8d4a4](https://github.com/DDogeee/Project2/commit/9b8d4a4c9a11cf668b96506e08cd1ab8a2631c1e))

## Trước khi bắt đầu

1. Cài đặt .NetCore 3.1: https://dotnet.microsoft.com/en-us/download/dotnet/3.1

2. Khôi phục bản backup ToolManagement.bak (trong thư mục Backend) theo hướng dẫn sau: 

https://stackoverflow.com/questions/8715687/how-to-copy-a-database-from-one-computer-to-another

3. Enable sa login trong Microsoft SQL Server Management Studio:

https://docs.microsoft.com/vi-vn/sql/database-engine/configure-windows/change-server-authentication-mode?view=sql-server-ver15&viewFallbackFrom=azure-sqldw-latest

4. Sửa lại file Project2/appsettings.Development.json, thay vào tên SQL Server và mật khẩu tài khoản sa trong máy

"DbConnection": Server="***Your-ServerName***;Database=ToolManagement;User ID=sa;Password=***Your-Password***;"

## Chạy project

Nhấn đúp chuột vào file batch `Win10_Start_Project2.bat` (chỉ cho hệ điều hành Windows). Đợi một lúc để hệ thống tải các file cần thiết và chạy chương trình
