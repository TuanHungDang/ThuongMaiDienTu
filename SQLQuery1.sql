CREATE DATABASE WebBanHang;
GO
USE WebBanHang;
GO
--DROP TABLE Category
CREATE TABLE Category
(
    [CategoryId] SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [CategoryName] [nvarchar](64) NOT NULL,
    [CategoryAlias] [nvarchar](64) NULL,
    [Description] [nvarchar](max) NULL,
    [ImageUrl] [nvarchar](32) NULL
);
GO
--DROP TABLE [Supplier];
CREATE TABLE [dbo].[Supplier]
(
    [SupplierId] [varchar](3) NOT NULL PRIMARY KEY,
    [CompanyName] [nvarchar](64) NOT NULL,
    [Logo] [VARCHAR](32) NOT NULL,
    [ContactName] [nvarchar](64) NULL,
    [Email] [nvarchar](64) NOT NULL,
    [Phone] [nvarchar](16) NULL,
    [Address] [nvarchar](128) NULL,
    [Description] [nvarchar](max) NULL
);
-- Tạo bảng Brand
CREATE TABLE [dbo].[Brand]
(
    [BrandId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [BrandName] [nvarchar](64) NOT NULL,
    [SupplierId] [varchar](3) NOT NULL,
    [Description] [nvarchar](MAX) NULL,
    CONSTRAINT FK_Brand_Supplier FOREIGN KEY (SupplierId) REFERENCES Supplier(SupplierId)
);
GO
SELECT *
FROM Brand;
--DROP TABLE [Product];
-- Tạo bảng Product với khóa ngoại đến bảng Brand
CREATE TABLE [dbo].[Product]
(
    [ProductId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ProductName] nvarchar(64) NOT NULL,
    [ProductAlias] nvarchar(64) NULL,
    [CategoryId] SMALLINT NOT NULL,
    [Unit] nvarchar(MAX) NULL,
    [Price] [DECIMAL] NULL,
    [Image] nvarchar(64) NULL,
    [ProductDate] [datetime] NOT NULL,
    [SaleOff] [DECIMAL] NOT NULL,
    [Viewed] [int] NOT NULL,
    [Description] nvarchar(MAX) NULL,
    [BrandId] [int] NOT NULL,
    CONSTRAINT FK_Product_Brand FOREIGN KEY (BrandId) REFERENCES Brand(BrandId)
);
GO


GO
INSERT INTO Category
    (CategoryName, CategoryAlias, Description, ImageUrl)
VALUES
    (N'Điện Thoại', 'laptop', N'Mô tả', 'DienThoai.png')
,
    (N'Laptop', 'laptop', N'Mô tả', 'Laptop.png')
,
    (N'Tablet', 'table', N'Mô tả', 'table.png')
,
    (N'ÂM Thanh', 'amthanh', N'Mô tả', 'amthanh.png')
,
    (N'Đồ Gia Dụng', 'dogiadung', N'Mô tả', 'dogiadung.png')
,
    (N'Phụ Kiện', 'phukien', N'Mô tả', 'phukien.png')
,
    (N'PC', 'pc', N'Mô tả', 'pc.png')
,
    (N'Màn Hình', 'manhinh', N'Mô tả', 'manhinh.png')
,
    (N'Máy In', 'mayin', N'Mô tả', 'mayin.png')
,
    (N'Tivi', 'tivi', N'Mô tả', 'tivi.png');
GO
SELECT *
FROM Category;

-- Dữ liệu về các hãng điện thoại
INSERT INTO Supplier
    (SupplierId, CompanyName, Logo, ContactName, Email, Phone, Address, Description)
VALUES
    ('APL', 'Apple Inc.', 'apple_logo.png', 'Tim Cook', 'tim.cook@apple.com', '+1-800-275-2273', 'One Apple Park Way, Cupertino, CA 95014, USA', 'Leading technology company known for iPhone, iPad, and Mac.'),
    ('SAM', 'Samsung Electronics', 'samsung_logo.png', 'Kim Hyun Suk', 'hyunsuk.kim@samsung.com', '+82-2-2053-3000', '129 Samsung-ro, Yeongtong-gu, Suwon-si, Gyeonggi-do, South Korea', 'Global leader in electronics and mobile devices.'),
    ('HUA', 'Huawei Technologies', 'huawei_logo.png', 'Ren Zhengfei', 'ren.zhengfei@huawei.com', '+86-755-28780808', 'Huawei Base, Bantian, Longgang District, Shenzhen, China', 'Leading global provider of ICT infrastructure and smart devices.'),
    ('XIA', 'Xiaomi Inc.', 'xiaomi_logo.png', 'Lei Jun', 'lei.jun@xiaomi.com', '+86-10-60606666', '68 Qinghe Middle Street, Haidian District, Beijing, China', 'Innovative consumer electronics and smart manufacturing company.'),
    ('ONE', 'OnePlus', 'oneplus_logo.png', 'Pete Lau', 'pete.lau@oneplus.com', '+86-755-61888688', '18F, Tairan Building, Tairan 8th Road, Futian District, Shenzhen, China', 'Premium smartphone manufacturer known for high-performance devices.');

-- Dữ liệu về các hãng laptop
INSERT INTO Supplier
    (SupplierId, CompanyName, Logo, ContactName, Email, Phone, Address, Description)
VALUES
    ('DEL', 'Dell Inc.', 'dell_logo.png', 'Michael Dell', 'michael.dell@dell.com', '+1-800-456-3355', '1 Dell Way, Round Rock, TX 78682, USA', 'Leading manufacturer of laptops, desktops, and other computer hardware.'),
    ('HP', 'HP Inc.', 'hp_logo.png', 'Enrique Lores', 'enrique.lores@hp.com', '+1-650-857-1501', '1501 Page Mill Road, Palo Alto, CA 94304, USA', 'Global provider of personal computing and other access devices.'),
    ('LEN', 'Lenovo Group', 'lenovo_logo.png', 'Yang Yuanqing', 'yang.yuanqing@lenovo.com', '+86-10-5886-8888', 'No. 6 Chuang Ye Road, Shangdi Information Industry Base, Haidian District, Beijing, China', 'Largest PC vendor by unit sales, known for ThinkPad and Yoga series.'),
    ('ASU', 'AsusTek Computer Inc.', 'asus_logo.png', 'Jonney Shih', 'jonney.shih@asus.com', '+886-2-2894-3447', 'No. 15, Li-Te Road, Beitou District, Taipei, Taiwan', 'Renowned for high-quality laptops, motherboards, and other electronics.'),
    ('ACE', 'Acer Inc.', 'acer_logo.png', 'Jason Chen', 'jason.chen@acer.com', '+886-2-2696-1234', '8F, 88, Sec. 1, Xintai 5th Road, Xizhi, New Taipei City 221, Taiwan', 'Known for affordable and reliable laptops and computer hardware.');

-- Dữ liệu về các hãng tablet
INSERT INTO Supplier
    (SupplierId, CompanyName, Logo, ContactName, Email, Phone, Address, Description)
VALUES
    ('MSF', 'Microsoft Corporation', 'microsoft_logo.png', 'Satya Nadella', 'satya.nadella@microsoft.com', '+1-425-882-8080', 'One Microsoft Way, Redmond, WA 98052, USA', 'Known for Surface tablets and a wide range of software and hardware products.'),
    ('AMZ', 'Amazon.com, Inc.', 'amazon_logo.png', 'Andy Jassy', 'andy.jassy@amazon.com', '+1-206-266-1000', '410 Terry Ave N, Seattle, WA 98109, USA', 'Known for Kindle and Fire tablets, as well as e-commerce and cloud computing services.'),
    ('GOO', 'Google LLC', 'google_logo.png', 'Sundar Pichai', 'sundar.pichai@google.com', '+1-650-253-0000', '1600 Amphitheatre Parkway, Mountain View, CA 94043, USA', 'Known for Pixel Slate and other innovative technology products.'),
    ('SON', 'Sony Corporation', 'sony_logo.png', 'Kenichiro Yoshida', 'kenichiro.yoshida@sony.com', '+81-3-6748-2111', '1-7-1 Konan, Minato-ku, Tokyo 108-0075, Japan', 'Known for Xperia tablets and a wide range of electronics and entertainment products.'),
    ('LG', 'LG Electronics', 'lg_logo.png', 'Kwon Bong-seok', 'bongseok.kwon@lge.com', '+82-2-3777-1114', 'LG Twin Towers, 128 Yeoui-daero, Yeongdeungpo-gu, Seoul, South Korea', 'Known for G Pad tablets and a wide range of consumer electronics.');
GO

SELECT *
FROM Supplier;
GO
-- Thêm dữ liệu cho bảng Brand
INSERT INTO Brand
    (BrandName, SupplierId, Description)
VALUES
    ('iPhone', 'APL', 'Apple Inc. - Leading smartphone brand known for innovation and quality.'),
    ('MacBook', 'APL', 'Apple Inc. - High-performance laptops with sleek design.'),
    ('iPad', 'APL', 'Apple Inc. - Versatile tablets for work and play.'),
    ('Galaxy', 'SAM', 'Samsung Electronics - Popular smartphone series with a wide range of models.'),
    ('Galaxy Tab', 'SAM', 'Samsung Electronics - High-quality tablets with advanced features.'),
    ('Mate', 'HUA', 'Huawei Technologies - High-end smartphones with advanced features.'),
    ('P30', 'HUA', 'Huawei Technologies - Popular smartphone series with excellent camera quality.'),
    ('Mi', 'XIA', 'Xiaomi Inc. - Affordable smartphones with great performance.'),
    ('Redmi', 'XIA', 'Xiaomi Inc. - Budget-friendly smartphones with good features.'),
    ('OnePlus', 'ONE', 'OnePlus - Premium smartphones known for high performance and design.'),
    ('Nord', 'ONE', 'OnePlus - Affordable smartphones with premium features.'),
    ('Inspiron', 'DEL', 'Dell Inc. - Reliable and affordable laptops for everyday use.'),
    ('XPS', 'DEL', 'Dell Inc. - High-end laptops with premium build quality.'),
    ('Pavilion', 'HP', 'HP Inc. - Versatile laptops suitable for both work and play.'),
    ('Spectre', 'HP', 'HP Inc. - Premium laptops with sleek design and powerful performance.'),
    ('ThinkPad', 'LEN', 'Lenovo Group - Business laptops known for durability and performance.'),
    ('Yoga', 'LEN', 'Lenovo Group - Convertible laptops with flexible design.'),
    ('ZenBook', 'ASU', 'AsusTek Computer Inc. - Sleek and powerful laptops for professionals.'),
    ('ROG', 'ASU', 'AsusTek Computer Inc. - High-performance gaming laptops.'),
    ('Aspire', 'ACE', 'Acer Inc. - Budget-friendly laptops with good performance.'),
    ('Predator', 'ACE', 'Acer Inc. - Gaming laptops with powerful hardware.'),
    ('Surface', 'MSF', 'Microsoft Corporation - High-quality tablets with versatile functionality.'),
    ('Surface Laptop', 'MSF', 'Microsoft Corporation - Premium laptops with sleek design.'),
    ('Fire', 'AMZ', 'Amazon.com, Inc. - Affordable tablets with access to Amazon services.'),
    ('Kindle', 'AMZ', 'Amazon.com, Inc. - Popular e-readers with a wide range of books.'),
    ('Pixel', 'GOO', 'Google LLC - Innovative tablets with the latest technology.'),
    ('Pixelbook', 'GOO', 'Google LLC - High-performance laptops with Chrome OS.'),
    ('Xperia', 'SON', 'Sony Corporation - Tablets with excellent multimedia capabilities.'),
    ('Vaio', 'SON', 'Sony Corporation - Premium laptops with stylish design.'),
    ('G Pad', 'LG', 'LG Electronics - Reliable tablets with good performance.'),
    ('Gram', 'LG', 'LG Electronics - Lightweight laptops with long battery life.');
GO
SELECT *
FROM Brand;
go
-- Thêm dữ liệu cho bảng Product với các dòng sản phẩm Redmi Note 11, 12 và 13
INSERT INTO Product
    (ProductName, ProductAlias, CategoryId, Unit, Price, Image, ProductDate, SaleOff, Viewed, Description, BrandId)
VALUES
    ('Redmi Note 11', 'redmi-note-11', 1, 'piece', 219.99, 'redmi_note_11.png', '2023-03-10', 0, 300, 'Xiaomi Redmi Note 11 with 6.43-inch display and Snapdragon 680.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Redmi')),
    ('Redmi Note 11 Pro', 'redmi-note-11-pro', 1, 'piece', 299.99, 'redmi_note_11_pro.png', '2023-04-15', 0, 320, 'Xiaomi Redmi Note 11 Pro with 6.67-inch display and Snapdragon 732G.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Redmi')),
    ('Redmi Note 12', 'redmi-note-12', 1, 'piece', 239.99, 'redmi_note_12.png', '2024-01-20', 0, 340, 'Xiaomi Redmi Note 12 with 6.5-inch display and MediaTek Dimensity 700.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Redmi')),
    ('Redmi Note 12 Pro', 'redmi-note-12-pro', 1, 'piece', 319.99, 'redmi_note_12_pro.png', '2024-02-25', 0, 360, 'Xiaomi Redmi Note 12 Pro with 6.67-inch display and MediaTek Dimensity 920.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Redmi')),
    ('Redmi Note 13', 'redmi-note-13', 1, 'piece', 259.99, 'redmi_note_13.png', '2024-05-05', 0, 380, 'Xiaomi Redmi Note 13 with 6.7-inch display and Snapdragon 750G.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Redmi')),
    ('Redmi Note 13 Pro', 'redmi-note-13-pro', 1, 'piece', 339.99, 'redmi_note_13_pro.png', '2024-06-10', 0, 400, 'Xiaomi Redmi Note 13 Pro with 6.8-inch display and Snapdragon 780G.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Redmi'));
GO

SELECT *
FROM Product;

SELECT BrandName
FROM Brand
WHERE BrandId = @BrandId


-- Dữ liệu cho sản phẩm của Apple
INSERT INTO Product
    (ProductName, ProductAlias, CategoryId, Unit, Price, Image, ProductDate, SaleOff, Viewed, Description, BrandId)
VALUES
    ('iPhone 14', 'iphone-14', 1, 'piece', 999.99, 'iphone_14.png', '2023-09-15', 0, 500, 'Apple iPhone 14 with A15 Bionic chip and advanced camera system.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'iPhone')),
    ('iPhone 14 Pro', 'iphone-14-pro', 1, 'piece', 1099.99, 'iphone_14_pro.png', '2023-09-20', 0, 600, 'Apple iPhone 14 Pro with ProMotion display and enhanced camera features.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'iPhone')),
    ('iPhone SE', 'iphone-se', 1, 'piece', 429.99, 'iphone_se.png', '2023-03-01', 0, 200, 'Apple iPhone SE, compact design with powerful performance.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'iPhone')),
    ('MacBook Air', 'macbook-air', 2, 'piece', 999.99, 'macbook_air.png', '2023-01-10', 0, 300, 'Apple MacBook Air with M1 chip, lightweight and powerful.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'MacBook')),
    ('iPad Pro', 'ipad-pro', 3, 'piece', 799.99, 'ipad_pro.png', '2023-02-15', 0, 400, 'Apple iPad Pro with M1 chip and Liquid Retina display.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'iPad'));


INSERT INTO Product
    (ProductName, ProductAlias, CategoryId, Unit, Price, Image, ProductDate, SaleOff, Viewed, Description, BrandId)
VALUES
    ('Galaxy S23', 'galaxy-s23', 1, 'piece', 799.99, 'galaxy_s23.png', '2023-02-15', 0, 400, 'Samsung Galaxy S23 with Snapdragon 8 Gen 2 and stunning display.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Galaxy')),
    ('Galaxy S23 Ultra', 'galaxy-s23-ultra', 1, 'piece', 1199.99, 'galaxy_s23_ultra.png', '2023-03-01', 0, 500, 'Samsung Galaxy S23 Ultra with advanced camera and S Pen.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Galaxy')),
    ('Galaxy A54', 'galaxy-a54', 1, 'piece', 449.99, 'galaxy_a54.png', '2023-04-10', 0, 250, 'Samsung Galaxy A54 with great performance and value.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Galaxy')),
    ('Galaxy Tab S8', 'galaxy-tab-s8', 3, 'piece', 699.99, 'galaxy_tab_s8.png', '2023-02-20', 0, 300, 'Samsung Galaxy Tab S8 with high-resolution display and S Pen.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Galaxy Tab')),
    ('Galaxy Book Pro', 'galaxy-book-pro', 2, 'piece', 1099.99, 'galaxy_book_pro.png', '2023-01-05', 0, 200, 'Samsung Galaxy Book Pro with AMOLED display and Intel processors.', (SELECT TOP 1
            BrandId
        FROM Brand
        WHERE BrandName = 'Galaxy'));
GO

CREATE TABLE Employees
(
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),-- Tự động tăng
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE,
    Email NVARCHAR(100) UNIQUE,
    Phone NVARCHAR(15),
    HireDate DATE NOT NULL,
    Position NVARCHAR(50),
    Salary DECIMAL(18, 2),
);
GO
INSERT INTO Employees (FirstName, LastName, DateOfBirth, Email, Phone, HireDate, Position, Salary, Username, Password)
VALUES 
('Nguyen', 'Van A', '1990-01-01', 'nguyenvana@example.com', '0123456789', '2023-01-01', 'Developer', 50000.00, 'nguyenvana', 'password123'),
('Tran', 'Thi B', '1985-05-15', 'tranthib@example.com', '0987654321', '2022-06-15', 'Project Manager', 70000.00, 'tranthib', 'password456'),
('Le', 'Van C', '1992-03-20', 'levanc@example.com', '0912345678', '2021-07-01', 'Designer', 45000.00, 'levanc', 'password789'),
('Pham', 'Thi D', '1988-12-10', 'phamthid@example.com', '0934567890', '2020-08-20', 'Tester', 40000.00, 'phamthid', 'password101'),
('Hoang', 'Van E', '1995-08-25', 'hoangvane@example.com', '0945678901', '2023-01-10', 'System Administrator', 60000.00, 'hoangvane', 'password202');
GO
SELECT * FROM Employees;

SELECT * FROM Product