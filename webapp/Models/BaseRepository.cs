using System.Data;

namespace webapp.Models;
// Lớp trừu tượng BaseRepository cung cấp các chức năng cơ bản cho repository
public abstract class BaseRepository{
     // Biến bảo vệ để lưu trữ kết nối cơ sở dữ liệu
    // 'protected' có nghĩa là biến này chỉ có thể được truy cập trong lớp này và các lớp dẫn xuất
    protected IDbConnection connection;
    // Hàm khởi tạo để khởi tạo kết nối cơ sở dữ liệu
    // Hàm khởi tạo chấp nhận một đối tượng IDbConnection, đại diện cho kết nối tới cơ sở dữ liệu
    public BaseRepository(IDbConnection cn){
        connection = cn ;// Gán kết nối được truyền vào hàm khởi tạo
    }
}