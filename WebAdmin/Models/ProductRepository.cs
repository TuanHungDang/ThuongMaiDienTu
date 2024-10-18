using Dapper;
using System.Data;

namespace WebAdmin.Models;

public class ProductRepository : BaseRepository
{

    public ProductRepository(IDbConnection cn) : base(cn)
    {
    }

    public IEnumerable<Product> GetProducts()
    {
        return connection.Query<Product>("Select * from Product");
    }



    public int Delete(byte id)
    {
        string sql = " DELETE FROM Product WHERE ProductId = @Id ";
        return connection.Execute(sql, new { id });
    }

    public Product? GetProduct(byte id)
    {
        string sql = "SELECT * FROM Product WHERE ProductId = @id";
        return connection.QuerySingleOrDefault<Product>(sql, new { id });
    }
    public int Add(Product obj)
    {
        string sql = @"
    INSERT INTO Product 
    (ProductName, ProductAlias, CategoryId, Unit, Price, Image, ProductDate, SaleOff, Viewed, Description, BrandId) 
    VALUES 
    (@ProductName, @ProductAlias, @CategoryId, @Unit, @Price, @Image, @ProductDate, @SaleOff, @Viewed, @Description, 
    (SELECT TOP 1 BrandId FROM Brand WHERE BrandName = @BrandName))";
        return connection.Execute(sql, obj);
    }

    public int Edit(Product obj)
    {
        string sql = @"UPDATE Product SET
     ProductName = @ProductName, ProductAlias = @ProductAlias, CategoryId = @CategoryId, Unit = @Unit, Price = @Price, Image = @Image, ProductDate = @ProductDate, SaleOff = @SaleOff, Viewed = @Viewed, Description = @Description, BrandId = (SELECT TOP 1 BrandId FROM Brand WHERE BrandName = @BrandName) WHERE ProductId = @ProductId";
        return connection.Execute(sql, obj);
    }
}