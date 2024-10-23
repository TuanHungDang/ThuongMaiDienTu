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

        public IEnumerable<Product> GetProductsRelation(short Categoryid, int id )
    {
        string sql = " SELECT * FROM Product WHERE CategoryId = @CategoryId AND ProductId <> @id";
        return connection.Query<Product>(sql, new{Categoryid, id});
    }

        public IEnumerable<Product> GetProductsByCategory(short id){
        string sql = "SELECT * FROM Product WHERE Categoryid = @Id";
        return connection.Query<Product>(sql, new{id});
    }

}