using System.Data;
using System.Data.SqlClient;
namespace WebAdmin.Models;

public abstract class BaseProvider{
    //Biến lưu trữ kết nối cơ sở dữ liệu, có thể null
    IDbConnection? connection;
    //Biêm cấu hình để lấy chuỗi kết nối 
    IConfiguration conf;
    //contructor khởi tạo BaseProvider với cấu hình
    public BaseProvider(IConfiguration conf){
        this.conf = conf;
    }

// Thuộc tính kết nối được khởi tạo nếu nó là null, sử dụng chuỗi kết nối từ cấu hình
    protected IDbConnection Connection => connection ??= new SqlConnection(conf.GetConnectionString("WebBanHang"));
}