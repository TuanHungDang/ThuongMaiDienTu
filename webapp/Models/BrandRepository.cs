using Dapper;
using System.Data;

namespace webapp.Models;

public class BrandRepository:BaseRepository{
    public BrandRepository(IDbConnection cn):base(cn)
    {      
    }

    public IEnumerable<Brand> GetBrands()
    {
        return connection.Query<Brand>("SELECT * FROM Brand");
    }

    public Brand? GetBrand(byte id){
        string sql = "SELECT * FROM Brand WHERE BrandId = @id";
        return connection.QuerySingleOrDefault<Brand>(sql, new{id});
    }

}