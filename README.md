# Project2
Quản lí key phần mềm

Restore Quanlikeyphanmem.bak file 

https://stackoverflow.com/questions/8715687/how-to-copy-a-database-from-one-computer-to-another

Enable sa login 

https://docs.microsoft.com/vi-vn/sql/database-engine/configure-windows/change-server-authentication-mode?view=sql-server-ver15&viewFallbackFrom=azure-sqldw-latest

Sửa  Project2/appsettings.json 

"DbConnection": Server="Your-ServerName;Database=Quan ly key phan mem;User ID=sa;Password=Your-Password;"

Getlist tool

curl --location --request GET 'https://localhost:44394/api/Tool/GetTool'

Add tool

curl --location --request POST 'https://localhost:44394/api/Tool/AddTool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 0,
    "Code" : "AAAAAA",
    "Name" : "Key phần mềm A",
    "Price": 300000,
    "Status": "Hoạt động"
}'

Edit tool

curl --location --request PUT 'https://localhost:44394/api/Tool/EditTool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 0,
    "Code" : "AAAAAA",
    "Name" : "Key phần mềm a",
    "Price": 200000,
    "Status": "Hoạt động"
}'

Delete tool

curl --location --request DELETE 'https://localhost:44394/api/Tool/DeleteTool?id=0'
