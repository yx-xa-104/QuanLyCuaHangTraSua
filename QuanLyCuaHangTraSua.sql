-- 1. Bảng Account (Tài khoản)
CREATE TABLE Account
(
    UserName NVARCHAR(100) PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL DEFAULT N'Staff',
    PassWord NVARCHAR(1000) NOT NULL DEFAULT 0,
    Type INT NOT NULL DEFAULT 0 -- 1: Admin, 0: Staff
)
GO

-- 2. Bảng TableFood (Bàn ăn)
CREATE TABLE TableFood
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa đặt tên',
    status NVARCHAR(100) NOT NULL DEFAULT N'Trống' -- Trống / Có người
)
GO

-- 3. Bảng FoodCategory (Danh mục món)
CREATE TABLE FoodCategory
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO

-- 4. Bảng Food (Món ăn/Đồ uống)
CREATE TABLE Food
(
    id INT IDENTITY PRIMARY KEY,
    name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
    idCategory INT NOT NULL,
    price FLOAT NOT NULL DEFAULT 0,
    ImagePath NVARCHAR(500) NULL, -- Đường dẫn ảnh

    FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO

-- 5. Bảng Bill (Hóa đơn)
CREATE TABLE Bill
(
    id INT IDENTITY PRIMARY KEY,
    DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
    DateCheckOut DATE,
    idTable INT NOT NULL,
    status INT NOT NULL DEFAULT 0, -- 0: Chưa thanh toán, 1: Đã thanh toán
    discount INT DEFAULT 0,
    totalPrice FLOAT DEFAULT 0,

    FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO

-- 6. Bảng BillInfo (Chi tiết hóa đơn)
CREATE TABLE BillInfo
(
    id INT IDENTITY PRIMARY KEY,
    idBill INT NOT NULL,
    idFood INT NOT NULL,
    count INT NOT NULL DEFAULT 0,

    FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
    FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

-- CÁC HÀM HỖ TRỢ (FUNCTIONS)
-- Hàm chuyển đổi tiếng Việt có dấu thành không dấu
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) 
RETURNS NVARCHAR(4000) 
AS 
BEGIN 
    IF @strInput IS NULL RETURN @strInput 
    IF @strInput = '' RETURN @strInput 
    DECLARE @RT NVARCHAR(4000) 
    DECLARE @SIGN_CHARS NCHAR(136) 
    DECLARE @UNSIGN_CHARS NCHAR (136) 
    SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
    SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
    DECLARE @COUNTER int 
    DECLARE @COUNTER1 int 
    SET @COUNTER = 1 
    WHILE (@COUNTER <=LEN(@strInput)) 
    BEGIN 
      SET @COUNTER1 = 1 
      WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
      BEGIN 
        IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER,1) ) 
        BEGIN           
          IF @COUNTER=1 
              SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1)                   
          ELSE 
              SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
          BREAK 
        END 
        SET @COUNTER1 = @COUNTER1 +1 
      END 
      SET @COUNTER = @COUNTER +1 
    END 
    SET @strInput = replace(@strInput,' ','-') 
    RETURN @strInput 
END
GO


-- CÁC STORED PROCEDURES (USP) --

-- 1. USP_Login
-- Gọi trong AccountDAO
CREATE PROC USP_Login
@userName NVARCHAR(100), @passWord NVARCHAR(100)
AS
BEGIN
    SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

-- 2. USP_GetTableList
-- Gọi trong TableDAO
CREATE PROC USP_GetTableList
AS SELECT * FROM dbo.TableFood
GO

-- 3. USP_InsertBill
-- Gọi trong BillDAO
CREATE PROC USP_InsertBill
@idTable INT
AS
BEGIN
    INSERT dbo.Bill 
    ( 
        DateCheckIn , 
        DateCheckOut , 
        idTable , 
        status,
        discount
    )
    VALUES  
    ( 
        GETDATE() , -- DateCheckIn
        NULL , -- DateCheckOut
        @idTable , -- idTable
        0,  -- status (Chưa thanh toán)
        0   -- discount
    )
END
GO

-- 4. USP_InsertBillInfo
-- Gọi trong BillInfoDAO
-- Logic: Nếu món đã tồn tại trong Bill đó rồi thì cộng dồn số lượng, chưa có thì thêm mới.
CREATE PROC USP_InsertBillInfo
@idBill INT, @idFood INT, @count INT
AS
BEGIN
    DECLARE @isExitsBillInfo INT
    DECLARE @foodCount INT = 1
    
    SELECT @isExitsBillInfo = id, @foodCount = b.count 
    FROM dbo.BillInfo AS b 
    WHERE idBill = @idBill AND idFood = @idFood

    IF (@isExitsBillInfo > 0)
    BEGIN
        DECLARE @newCount INT = @foodCount + @count
        IF (@newCount > 0)
            UPDATE dbo.BillInfo SET count = @foodCount + @count WHERE idFood = @idFood AND idBill = @idBill
        ELSE
            DELETE dbo.BillInfo WHERE idBill = @idBill AND idFood = @idFood
    END
    ELSE
    BEGIN
        INSERT dbo.BillInfo(idBill, idFood, count) VALUES (@idBill, @idFood, @count)
    END
END
GO

-- 5. USP_GetListBillByDate
-- Gọi trong BillDAO để thống kê doanh thu
CREATE PROC USP_GetListBillByDate
@checkIn date, @checkOut date
AS 
BEGIN
    SELECT t.name AS [Tên bàn], b.totalPrice AS [Tổng tiền], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá]
    FROM dbo.Bill AS b, dbo.TableFood AS t
    WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
    AND t.id = b.idTable
END
GO

--------------------------------
-- DỮ LIỆU MẪU (SEED DATA) --
--------------------------------
INSERT INTO dbo.Account (UserName, DisplayName, PassWord, Type)
VALUES (N'admin', N'Quản trị viên', N'5feceb66ffc86f38d952786c6d696c79c2dbc239dd4e91b46729d73a27fb57e9', 1)

INSERT INTO dbo.Account (UserName, DisplayName, PassWord, Type)
VALUES (N'staff', N'Nhân viên', N'5feceb66ffc86f38d952786c6d696c79c2dbc239dd4e91b46729d73a27fb57e9', 0)
GO

-- Thêm Bàn ăn (20 bàn)
DECLARE @i INT = 1
WHILE @i <= 20
BEGIN
    INSERT dbo.TableFood (name) VALUES (N'Bàn ' + CAST(@i AS nvarchar(100)))
    SET @i = @i + 1
END
GO

-- Thêm Danh mục (Category)
INSERT dbo.FoodCategory (name) VALUES (N'Trà sữa')
INSERT dbo.FoodCategory (name) VALUES (N'Cà phê')
INSERT dbo.FoodCategory (name) VALUES (N'Ăn vặt')
INSERT dbo.FoodCategory (name) VALUES (N'Topping')
GO

-- Thêm Món ăn (Food)
-- ID Category: 1 (Trà sữa), 2 (Cà phê), 3 (Ăn vặt), 4 (Topping)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Trà sữa truyền thống', 1, 25000, NULL)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Trà sữa Matcha', 1, 30000, NULL)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Cà phê đen', 2, 20000, NULL)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Cà phê sữa', 2, 25000, NULL)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Khoai tây chiên', 3, 20000, NULL)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Xúc xích', 3, 15000, NULL)
INSERT dbo.Food (name, idCategory, price, ImagePath) VALUES (N'Trân châu đen', 4, 5000, NULL)
GO