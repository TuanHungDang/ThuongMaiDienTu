using Dapper;
using System.Data;

namespace WebAdmin.Models;

public class BrandRepository:BaseRepository{
    public BrandRepository(IDbConnection cn):base(cn)
    {      
    }

    public IEnumerable<Brand> GetBrands()
    {
        return connection.Query<Brand>("SELECT * FROM Brand");
    }

 public int Add(Brand obj){ 
        
        string sql = "Insert Into Brand(BrandName, SupplierId, Description ) Values(@BrandName, @SupplierId, @Description)";
         
        return connection.Execute(sql,obj);
    }
    
    public int Delete (byte id){
        string sql = " DELETE FROM Brand WHERE BrandId = @Id ";
        return connection.Execute(sql, new{id});
    }

    public Brand? GetBrand(byte id){
        string sql = "SELECT * FROM Brand WHERE BrandId = @id";
        return connection.QuerySingleOrDefault<Brand>(sql, new{id});
    }
    public int Edit(Brand obj){
        string sql = "UPDATE Brand SET BrandName = @BrandName, SupplierId = @SupplierId, Description = @Description WHERE BrandId = @BrandId";
        return connection.Execute(sql, obj);
    }
}