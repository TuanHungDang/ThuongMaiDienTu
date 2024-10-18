using Dapper;
using System.Data;

namespace webapp.Models;

public class ProductRepository : BaseRepository
{

    public ProductRepository(IDbConnection cn) : base(cn)
    {
    }

    public IEnumerable<Product> GetProducts()
    {
        return connection.Query<Product>("Select * from Product");
    }



    public Product? GetProduct(byte id)
    {
        string sql = "SELECT * FROM Product WHERE ProductId = @id";
        return connection.QuerySingleOrDefault<Product>(sql, new { id });
    }

}