# Cần sửa api "Get Order by UserId"

# Project 2: Tool Management (Quản lí key phần mềm)
## Mục lục
1. [Ngay sau khi clone git](https://github.com/DDogeee/Project2/blob/master/README.md#1-ngay-sau-khi-clone-git)
2. [Trạng thái của tool/order/key](https://github.com/DDogeee/Project2/blob/master/README.md#2-tr%E1%BA%A1ng-th%C3%A1i-c%E1%BB%A7a-toolorderkey)
3. [Các APIs](https://github.com/DDogeee/Project2/blob/master/README.md#3-c%C3%A1c-apis)
    - [User](https://github.com/DDogeee/Project2/blob/master/README.md#user)
    - [Tool](https://github.com/DDogeee/Project2/blob/master/README.md#tool)
    - [Order](https://github.com/DDogeee/Project2/blob/master/README.md#order)
    - [Key](https://github.com/DDogeee/Project2/blob/master/README.md#key)
    - [Order detail](https://github.com/DDogeee/Project2/blob/master/README.md#order-detail)

### 1. Ngay sau khi clone git: 
a. Khôi phục bản backup ToolManagement.bak theo hướng dẫn sau: 

https://stackoverflow.com/questions/8715687/how-to-copy-a-database-from-one-computer-to-another

b. Enable sa login:

https://docs.microsoft.com/vi-vn/sql/database-engine/configure-windows/change-server-authentication-mode?view=sql-server-ver15&viewFallbackFrom=azure-sqldw-latest

c. Sửa lại file Project2/appsettings.Development.json, thay vào tên SQL Server và mật khẩu tài khoản sa trong máy

"DbConnection": Server="***Your-ServerName***;Database=ToolManagement;User ID=sa;Password=***Your-Password***;"

### 2. Trạng thái của tool/order/key

**Status**

- `1`: Active - Tool/Key đang hoạt động, Order đã được duyệt
- `0`: Pending - Order/Key đang chờ duyệt 
- `-1`: Inactive - Order bị từ chối, Key hết hạn hoặc bị vô hiệu hoá, ...
- `-2`: Deleted - Tool/Key/Order được đánh dấu là bị xoá (tuy nhiên vẫn tồn tại trong cơ sở dữ liệu)

### 3. Các APIs:  

(Ngoại trừ các API Login, Register, Get Tool, Get Tool by ID, các API còn lại đều cần bearer token. Bearer token có thể nhận được sau khi đăng nhập thành công)

### User

- **[POST request] Login (Đăng nhập)**

Link:  
```
https://localhost:44394/api/quan-ly-user/dang-nhap
```

JSON:
```json
{
    "username" : "phamvudung",
    "password" : "123456"
}
```

Curl command:
```
curl --location --request POST 'https://localhost:44394/api/quan-ly-user/dang-nhap' \
--header 'Content-Type: application/json' \
--data-raw '{
    "username" : "phamvudung",
    "password" : "123456"
}'
```

- **[POST request] Register (Đăng kí)**

Link:  
```
https://localhost:44394/api/quan-ly-user/dang-ki
```

JSON:
```json
{
    "IsAdmin": false,
    "Username": "phamvudung",
    "Password": "123456",
    "Phone": "0346909605"
}
```

Curl command:
```
curl --location --request POST 'https://localhost:44394/api/quan-ly-user/dang-ki' \
--header 'Content-Type: application/json' \
--data-raw '{
    "IsAdmin": false,
    "Username": "phamvudung",
    "Password": "123456",
    "Phone": "0346909605"
}'
```

- **[POST request] Logout (Đăng xuất)**

Link:  
```
https://localhost:44394/api/quan-ly-user/dang-xuat
```

JSON: Để trống

Curl command:
```
curl --location --request POST 'https://localhost:44394/api/quan-ly-user/dang-xuat' \
--header 'Content-Type: application/json' \
--data-raw '{
    
}'
```

- **[GET request] Get User by ID (Xem thông tin người dùng qua ID)**

Link:  
```
https://localhost:44394/api/quan-ly-user/chi-tiet
```

JSON:
```json
{
    "id": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-user/chi-tiet' \
--header 'Content-Type: application/json' \
--data-raw '{
        "id": 1
}'
```

### Tool

- **[GET request] Get Tool (Lấy danh sách các tool)**

Link:  
```
https://localhost:44394/api/quan-ly-tool/danh-sach-tool
```

JSON: Để trống

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-tool/danh-sach-tool' \
--header 'Content-Type: application/json' \
--data-raw '{

}'
```

- **[POST request] Add Tool (Thêm tool)**

Link:  
```
https://localhost:44394/api/quan-ly-tool/them-tool
```

JSON:
```json
{
    "Code": "code gì đó",
    "Name": "Tool reg hotmail số lượng lớn[Chạy đa luồng]",
    "Image": null,
    "Description": " - Hỗ trợ Fake ip đa dạng. ",
    "Price": 2500000,
    "Status": 1,
    "CreatedBy": "phamvudung"
}
```

Curl command:
```
curl --location --request POST 'https://localhost:44394/api/quan-ly-tool/them-tool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Code": "code gì đó",
    "Name": "Tool reg hotmail số lượng lớn[Chạy đa luồng]",
    "Image": null,
    "Description": " - Hỗ trợ Fake ip đa dạng. ",
    "Price": 2500000,
    "Status": 1,
    "CreatedBy": "phamvudung"
}'
```

- **[PUT request] Edit Tool (Sửa thông tin tool)**

Link:  
```
https://localhost:44394/api/quan-ly-tool/sua-tool
```

JSON:
```json
{
    "ID": 1,
    "Code": "LLLLLL",
    "Name": "Key phần mềm nào đó",
    "Description": ":D",
    "Price": 67676767,
    "Status": 1,
    "ModifiedBy": "phamvudung"
}
```

Curl command:
```

curl --location --request PUT 'https://localhost:44394/api/quan-ly-tool/sua-tool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 1,
    "Code": "LLLLLL",
    "Name": "Key phần mềm nào đó",
    "Description": ":D",
    "Price": 67676767,
    "Status": 1,
    "ModifiedBy": "phamvudung"
}'
```

- **[DELETE request] Delete Tool (Xoá tool)**

Link:  
```
https://localhost:44394/api/quan-ly-tool/xoa-tool
```

JSON:
```json
{
    "ID": 1,
    "DeletedBy": "phamvudung"
}
```

Curl command:
```
curl --location --request DELETE 'https://localhost:44394/api/quan-ly-tool/xoa-tool' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 1,
    "DeletedBy": "phamvudung"
}'
```

- **[GET request] Get Tool by ID (Xem thông tin của tool theo ID)**

Link:  
```
https://localhost:44394/api/quan-ly-tool/chi-tiet
```

JSON:
```json
{
    "ID": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-tool/chi-tiet' \
--header 'Content-Type: application/json' \
--data-raw '{
    "ID": 1
}'
```

### Order

- **[GET request] Get Order (Lấy danh sách các đơn hàng)**

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/danh-sach
```

JSON: Để trống

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-don-hang/danh-sach' \
--header 'Content-Type: application/json' \
--data-raw '{

}'
```

- **[GET request] Get Pending Order (Lấy danh sách các đơn hàng đang chờ duyệt)**

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/cho-duyet
```

JSON: Để trống

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-don-hang/cho-duyet' \
--header 'Content-Type: application/json' \
--data-raw '{

}'
```

- **[POST request] Add Order (Thêm đơn hàng mới)**

Mỗi một khách hàng có thể tạo một đơn hàng, và trong đó có nhiều tool khác nhau, tương ứng với mỗi tool đã chọn sẽ là số lượng key mà khách hàng muốn mua. 

Khi API này được gọi, backend sẽ tạo các Order Detail (chi tiết từng đơn hàng nhỏ) tương ứng với số lượng key đã đặt, đồng thời sinh sẵn các key. Đơn hàng (và key trong đó) sẽ ở trạng thái chờ duyệt.

Chú ý: Nếu không có giảm giá, nên để trường "Discount": 0. Nếu có giảm giá, chẳng hạn 25%, thì "Discount": 25.

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/them-don-hang
```

JSON:
```json
{
    "UserId": 1,
    "Tools": 
    [
        {
            "ToolId": 1,
            "NumberOfKeys": 2,
            "Discount": 95,
            "MachineId": "cc00f1dc-fceb-42e0-8217-3ee6e4b73ab9"
        },
        {
            "ToolId": 11,
            "NumberOfKeys": 3,
            "Discount": 0,
            "MachineId": "76ad5816-f66a-450a-b650-070dec110df1"
        }
    ]
}
```

Curl command:
```
curl --location --request POST 'https://localhost:44394/api/quan-ly-don-hang/them-don-hang' \
--header 'Content-Type: application/json' \
--data-raw '{
    "UserId": 1,
    "Tools": 
    [
        {
            "ToolId": 1,
            "NumberOfKeys": 2,
            "Discount": 95,
            "MachineId": "cc00f1dc-fceb-42e0-8217-3ee6e4b73ab9"
        },
        {
            "ToolId": 11,
            "NumberOfKeys": 3,
            "Discount": 0,
            "MachineId": "76ad5816-f66a-450a-b650-070dec110df1"
        }
    ]
}'
```

- **[PUT request] Approve Order (Duyệt đơn hàng)**

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/duyet-don-hang
```

JSON:
```json
{
    "Id": 1
}
```

Curl command:
```
curl --location --request PUT 'https://localhost:44394/api/quan-ly-don-hang/duyet-don-hang' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

- **[DELETE request] Delete Order (Xoá đơn hàng)**

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/xoa-don-hang
```

JSON:
```json
{
    "ID": 1
}
```

Curl command:
```
curl --location --request DELETE 'https://localhost:44394/api/quan-ly-don-hang/xoa-don-hang' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

- **[GET request] Get Order by ID (Xem đơn hàng qua ID)**

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/theo-id
```

JSON:
```json
{
    "ID": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-don-hang/theo-id' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

- **[GET request] Get Order by UserID (Lấy các đơn hàng của một UserID)** - *(Lỗi stack overflow)*

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/theo-user
```

JSON:
```json
{
    "UserId": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-don-hang/theo-user' \
--header 'Content-Type: application/json' \
--data-raw '{
    "UserId": 1
}'
```

### Key

- **[GET request] Get Key (Xem toàn bộ danh sâch các key)**

Link:  
```
https://localhost:44394/api/quan-ly-key/danh-sach-key
```

JSON: Để trống

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-key/danh-sach-key' \
--header 'Content-Type: application/json' \
--data-raw '{

}'
```

- **[PUT request] Extend Key (Gia hạn thời gian cho key)**

Key sẽ được kéo dài thời hạn thêm 365 ngày sau khi gọi API này (Cần có nhiều giai đoan hơn?)

Link:  
```
https://localhost:44394/api/quan-ly-key/gia-han-key
```

JSON:
```json
{
    "Id": 1
}
```

Curl command:
```
curl --location --request PUT 'https://localhost:44394/api/quan-ly-key/gia-han-key' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

- **[DELETE request] Delete Key (Xoá key)**

Link:  
```
https://localhost:44394/api/quan-ly-key/xoa-key
```

JSON:
```json
{
    "Id": 1
}
```

Curl command:
```
curl --location --request DELETE 'https://localhost:44394/api/quan-ly-key/xoa-key' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

- **[GET request] Get Key by ID (Xem key theo ID)**

Link:  
```
https://localhost:44394/api/quan-ly-key/theo-id
```

JSON:
```json
{
    "Id": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/quan-ly-key/theo-id' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

### Order Detail

- **[GET request] Get Order Detail (Lấy danh sách toàn bộ Order Detail)**

Link:  
```
https://localhost:44394/api/chi-tiet-don-hang/danh-sach
```

JSON: Để trống

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/chi-tiet-don-hang/danh-sach' \
--header 'Content-Type: application/json' \
--data-raw '{

}'
```


- **[GET request] Get Order Detail by ID (Xem Order Detail theo ID)**

Link:  
```
https://localhost:44394/api/chi-tiet-don-hang/theo-id
```

JSON: 
```
{
    "Id": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/chi-tiet-don-hang/theo-id' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Id": 1
}'
```

- **[GET request] Get Order Detail by OrderID (Xem Order Detail theo OrderID)**

Link:  
```
https://localhost:44394/api/chi-tiet-don-hang/theo-don-hang
```

JSON: 
```
{
    "OrderId": 1
}
```

Curl command:
```
curl --location --request GET 'https://localhost:44394/api/chi-tiet-don-hang/theo-don-hang' \
--header 'Content-Type: application/json' \
--data-raw '{
    "OrderId": 1
}'
```
