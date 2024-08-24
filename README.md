# Exercise 2: Build 2 Microservices

## Giới Thiệu

Bài tập này yêu cầu xây dựng hai microservices:

1. **ProductService**: Quản lý thông tin sản phẩm.
2. **CartService**: Quản lý giỏ hàng.

### 1. ProductService

**Mục tiêu**: Tạo API CRUD để lấy danh sách sản phẩm và thực hiện các thao tác khác với sản phẩm.

#### **Yêu Cầu**

- **Sử dụng cơ sở dữ liệu**: SQL/PostgreSQL để lưu trữ thông tin sản phẩm.
- **Schema sản phẩm**: `ProductId`, `ProductName`, `Price`, `Quantity`.