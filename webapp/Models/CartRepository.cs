using System.Data;
using Dapper;

namespace webapp.Models;
public class CartRepository : BaseRepository
{
    public CartRepository(IDbConnection cn): base(cn){
    }

    public int Edit(Cart obj){
        string sql = "UPDATE Cart SET Quantity = @Quantity, UpdatedDate = GETDATE() WHERE CartCode = @CartCode AND ProductId = @ProductId;";
        return connection.Execute(sql, new{obj.CartCode, obj.ProductId, obj.Quantity});
    }

    public int Add(Cart obj){
        return connection.Execute("AddCart", new{obj.CartCode, obj.ProductId, obj.Quantity}, commandType: CommandType.StoredProcedure);
    }

    public IEnumerable<Cart> GetCarts(string code){
        string sql = "SELECT Cart.*, ProductName, Price, Image From Cart JOIN Product ON Cart.ProductId = Product.ProductId AND CartCode = @Code";
        return connection.Query<Cart>(sql, new{code});
    }

    public int Delete(string cartcode, int productId){
        string sql = "DELETE FROM Cart WHERE CartCode = @CartCode AND ProductId= @ProductId";
        return connection.Execute(sql, new{CartCode = cartcode, ProductId = productId});
    }
}