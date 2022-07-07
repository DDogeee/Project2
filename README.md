# Project 2: Tool Management (Quản lí key phần mềm)
## Mục lục
1. [Ngay sau khi clone git](https://github.com/DDogeee/Project2#1-ngay-sau-khi-clone-git)
2. [Trạng thái của tool/order/key](https://github.com/DDogeee/Project2#2-tr%E1%BA%A1ng-th%C3%A1i-c%E1%BB%A7a-toolorderkey)
3. [Các APIs](https://github.com/DDogeee/Project2#3-c%C3%A1c-apis)
    - [User](https://github.com/DDogeee/Project2#user)
      - [Đăng nhập](https://github.com/DDogeee/Project2#--post-request-login-%C4%91%C4%83ng-nh%E1%BA%ADp)
      - [Đăng kí](https://github.com/DDogeee/Project2#--post-request-register-%C4%91%C4%83ng-k%C3%AD)
      - [Đăng xuất](https://github.com/DDogeee/Project2#--post-request-logout-%C4%91%C4%83ng-xu%E1%BA%A5t)
      - [Xem thông tin người dùng bằng username](https://github.com/DDogeee/Project2#--get-request-get-user-by-username-xem-th%C3%B4ng-tin-ng%C6%B0%E1%BB%9Di-d%C3%B9ng-qua-username)
    - [Tool](https://github.com/DDogeee/Project2#tool)
      - [Lấy danh sách các tool](https://github.com/DDogeee/Project2#--get-request-get-tool-l%E1%BA%A5y-danh-s%C3%A1ch-c%C3%A1c-tool)
      - [Thêm tool](https://github.com/DDogeee/Project2#--post-request-add-tool-th%C3%AAm-tool)
      - [Sửa thông tin tool](https://github.com/DDogeee/Project2#--put-request-edit-tool-s%E1%BB%ADa-th%C3%B4ng-tin-tool)
      - [Xoá tool](https://github.com/DDogeee/Project2#--put-request-delete-tool-xo%C3%A1-tool)
      - [Xem thông tin tool bằng ID](https://github.com/DDogeee/Project2#--get-request-get-tool-by-id-xem-th%C3%B4ng-tin-c%E1%BB%A7a-tool-theo-id)
    - [Order](https://github.com/DDogeee/Project2#order)
      - [Lấy danh sách đơn hàng](https://github.com/DDogeee/Project2#--get-request-get-order-l%E1%BA%A5y-danh-s%C3%A1ch-c%C3%A1c-%C4%91%C6%A1n-h%C3%A0ng)
      - [Lấy danh sách đơn hàng đang chờ duyệt](https://github.com/DDogeee/Project2#--get-request-get-pending-order-l%E1%BA%A5y-danh-s%C3%A1ch-c%C3%A1c-%C4%91%C6%A1n-h%C3%A0ng-%C4%91ang-ch%E1%BB%9D-duy%E1%BB%87t)
      - [Thêm đơn hàng mới](https://github.com/DDogeee/Project2#--post-request-add-order-th%C3%AAm-%C4%91%C6%A1n-h%C3%A0ng-m%E1%BB%9Bi)
      - [Duyệt đơn hàng](https://github.com/DDogeee/Project2#--put-request-approve-order-duy%E1%BB%87t-%C4%91%C6%A1n-h%C3%A0ng)
      - [Xoá đơn hàng](https://github.com/DDogeee/Project2#--put-request-delete-order-xo%C3%A1-%C4%91%C6%A1n-h%C3%A0ng)
      - [Xem đơn hàng bằng ID](https://github.com/DDogeee/Project2#--get-request-get-order-by-id-xem-%C4%91%C6%A1n-h%C3%A0ng-qua-id)
      - [Xem lịch sử đặt hàng của người dùng bằng username](https://github.com/DDogeee/Project2/#--get-request-get-order-by-username-l%E1%BA%A5y-l%E1%BB%8Bch-s%E1%BB%AD-%C4%91%E1%BA%B7t-h%C3%A0ng-c%E1%BB%A7a-m%E1%BB%99t-user)
    - [Key](https://github.com/DDogeee/Project2#key)
      - [Lấy danh sách các key](https://github.com/DDogeee/Project2#--get-request-get-key-xem-to%C3%A0n-b%E1%BB%99-danh-s%C3%A1ch-c%C3%A1c-key)
      - [Gia hạn thời gian cho key](https://github.com/DDogeee/Project2#--put-request-extend-key-gia-h%E1%BA%A1n-th%E1%BB%9Di-gian-cho-key)
      - [Xoá key](https://github.com/DDogeee/Project2#--put-request-delete-key-xo%C3%A1-key)
      - [Xem key bằng ID](https://github.com/DDogeee/Project2#--get-request-get-key-by-id-xem-key-theo-id)  
    - [Order detail](https://github.com/DDogeee/Project2#order-detail)
      - [Lấy danh sách các Order Detail](https://github.com/DDogeee/Project2#--get-request-get-order-detail-l%E1%BA%A5y-danh-s%C3%A1ch-to%C3%A0n-b%E1%BB%99-order-detail)
      - [Xem Order Detail bằng ID](https://github.com/DDogeee/Project2#--get-request-get-order-detail-by-id-xem-order-detail-theo-id)
      - [Xem các Order Detail của cùng một Order](https://github.com/DDogeee/Project2#--get-request-get-order-detail-by-orderid-xem-c%C3%A1c-order-detail-c%E1%BB%A7a-c%C3%B9ng-m%E1%BB%99t-orderid)

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

**(Ngoại trừ các API Login, Register, Get Tool, Get Tool by ID, _các API còn lại đều cần bearer token_. Bearer token có thể nhận được sau khi đăng nhập thành công)**

### User

### - [POST request] Login (Đăng nhập)

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

### - [POST request] Register (Đăng kí)

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

### - [POST request] Logout (Đăng xuất)

Link:  
```
https://localhost:44394/api/quan-ly-user/dang-xuat
```

JSON: Để trống

### - [GET request] Get User by username (Xem thông tin người dùng qua username)

Link (thay [name] trong đường dẫn bằng một xâu là tên đăng nhập, không có dấu ngoặc vuông):  
```
https://localhost:44394/api/quan-ly-user/chi-tiet/[name]
```

Ví dụ:
```
https://localhost:44394/api/quan-ly-user/chi-tiet/phamvudung
```

sẽ lấy thông tin của người dùng có tên đăng nhập là phamvudung

JSON: Để trống

### Tool

### - [GET request] Get Tool (Lấy danh sách các tool)

Link:  
```
https://localhost:44394/api/quan-ly-tool/danh-sach-tool
```

JSON: Để trống

### - [POST request] Add Tool (Thêm tool)

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

### - [PUT request] Edit Tool (Sửa thông tin tool)

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

### - [PUT request] Delete Tool (Xoá tool)

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

### - [GET request] Get Tool by ID (Xem thông tin của tool theo ID)

Link (thay [id] trong đường dẫn bằng một số nguyên là mã số id của tool, không có dấu ngoặc vuông):  
```
https://localhost:5001/api/quan-ly-tool/chi-tiet/[id]
```

Ví dụ:
```
https://localhost:5001/api/quan-ly-tool/chi-tiet/1
```
sẽ lấy thông tin của tool có id == 1

JSON: Để trống

### Order

### - [GET request] Get Order (Lấy danh sách các đơn hàng)

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/danh-sach
```

JSON: Để trống

### - [GET request] Get Pending Order (Lấy danh sách các đơn hàng đang chờ duyệt)

Link:  
```
https://localhost:44394/api/quan-ly-don-hang/cho-duyet
```

JSON: Để trống

### - [POST request] Add Order (Thêm đơn hàng mới)

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
    "Username": "phamvudung",
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

### - [PUT request] Approve Order (Duyệt đơn hàng)

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

### - [PUT request] Delete Order (Xoá đơn hàng)

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

### - [GET request] Get Order by ID (Xem đơn hàng qua ID)

Link (thay [id] trong đường dẫn bằng một số nguyên là mã số id của order, không có dấu ngoặc vuông):  
```
https://localhost:5001/api/quan-ly-don-hang/chi-tiet/[id]
```

Ví dụ:
```
https://localhost:5001/api/quan-ly-don-hang/chi-tiet/1
```
sẽ lấy thông tin của order có id == 1

JSON: Để trống

### - [GET request] Get Order by Username (Lấy lịch sử đặt hàng của một user)

Link (thay [name] trong đường dẫn bằng một xâu là tên đăng nhập, không có dấu ngoặc vuông):  
```
https://localhost:5001/api/quan-ly-don-hang/lich-su/[name]
```

Ví dụ:
```
https://localhost:5001/api/quan-ly-don-hang/lich-su/phamvudung
```
sẽ lấy toàn bộ các order thuộc về user có tên đăng nhập là phamvudung

JSON: Để trống

### Key

### - [GET request] Get Key (Xem toàn bộ danh sách các key)

Link:  
```
https://localhost:44394/api/quan-ly-key/danh-sach-key
```

JSON: Để trống


### - [PUT request] Extend Key (Gia hạn thời gian cho key)

Key sẽ được kéo dài thời hạn thêm 30 ngày sau khi gọi API này

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

### - [PUT request] Delete Key (Xoá key)

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

### - [GET request] Get Key by ID (Xem key theo ID)

Link (thay [id] trong đường dẫn bằng một số nguyên là mã số id của key, không có dấu ngoặc vuông):  
```
https://localhost:5001/api/quan-ly-key/chi-tiet/[id]
```

Ví dụ:
```
https://localhost:5001/api/quan-ly-key/chi-tiet/1
```
sẽ lấy thông tin về key có id == 1

JSON: Để trống

### Order Detail

### - [GET request] Get Order Detail (Lấy danh sách toàn bộ Order Detail)

Link:  
```
https://localhost:44394/api/chi-tiet-don-hang/danh-sach
```

JSON: Để trống

### - [GET request] Get Order Detail by ID (Xem Order Detail theo ID)

Link (thay [id] trong đường dẫn bằng một số nguyên là mã số id của order detail, không có dấu ngoặc vuông):  
```
https://localhost:5001/api/chi-tiet-don-hang/chi-tiet/[id]
```

Ví dụ:
```
https://localhost:5001/api/chi-tiet-don-hang/chi-tiet/1
```
sẽ lấy thông tin về order detail có id == 1

JSON: Để trống

### - [GET request] Get Order Detail by OrderID (Xem các Order Detail của cùng một OrderID)

Link (thay [orderId] trong đường dẫn bằng một số nguyên là mã số id của order, không có dấu ngoặc vuông):  
```
https://localhost:5001/api/chi-tiet-don-hang/order/[orderId]
```

Ví dụ:
```
https://localhost:5001/api/chi-tiet-don-hang/order/1
```
sẽ lấy toàn bộ các order detail thuộc về order có id == 1

JSON: Để trống
