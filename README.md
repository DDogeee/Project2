# Project2
Quản lí key phần mềm

Restore Quanlikeyphanmem.bak file 

https://stackoverflow.com/questions/8715687/how-to-copy-a-database-from-one-computer-to-another

Enable sa login 

https://docs.microsoft.com/vi-vn/sql/database-engine/configure-windows/change-server-authentication-mode?view=sql-server-ver15&viewFallbackFrom=azure-sqldw-latest

Sửa  Project2/appsettings.json 

"DbConnection": Server="Your-ServerName;Database=Quan ly key phan mem;User ID=sa;Password=Your-Password;"

Getlist tool

curl --location --request GET 'https://localhost:44394/api/quan-ly-tool/danh-sach-tool'

Add tool

curl --location --request POST 'https://localhost:44394/api/quan-ly-tool/them-tool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 0,
    "Code" : "AAAAAA",
    "Name" : "Key phần mềm A",
    "Price": 300000,
     "Status": "Hoạt động"
}'

Edit tool

curl --location --request PUT 'https://localhost:44394/api/quan-ly-tool/sua-tool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 0,
    "Code" : "AAAAAA",
    "Name" : "Key phần mềm A",
    "Price": 300000,
     "Status": "Hoạt động"
}'

Delete tool

curl --location --request DELETE 'https://localhost:44394/api/quan-ly-tool/xoa-tool?id=0'

Get Tool By Id

curl --location --request GET 'https://localhost:44394/api/quan-ly-tool/lay-tool-theo-id?id=0'


Login 

curl --location --request POST 'https://localhost:5001/api/quan-ly-user/dang-nhap' \
--header 'Content-Type: application/json' \
--data-raw '{
    "username" : "phamvudung",
    "password" : "123456"
}'


Register

curl --location --request POST 'https://localhost:44394/api/quan-ly-user/dang-ki' \
--header 'Content-Type: application/json' \
--data-raw '{
    "IsAdmin": false,
    "Username": "phamvudung",
    "Password": "123456",
    "Phone": "0346909605",
    "IsDeleted": false
}'

Logout

curl --location --request POST 'https://localhost:44394/api/quan-ly-user/dang-xuat?token=asdasdjdajd' \
--header 'Content-Type: application/json' \
--data-raw '{
    
}'
