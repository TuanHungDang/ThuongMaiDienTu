using Dapper;
using System.Data;

namespace WebAdmin.Models;

public class CategoryRepository:BaseRepository{
     
    public CategoryRepository(IDbConnection cn) : base(cn){
    }
    
    public IEnumerable<Category> GetCategories(){
        return connection.Query<Category>("Select * from Category");
    }
     
    public int Add(Category obj){ 
        
        string sql = "Insert Into Category(CategoryName, CategoryAlias, Description, ImageUrl ) Values(@CategoryName, @CategoryAlias, @Description, @ImageUrl )";
         
        return connection.Execute(sql,obj);
    }
    
    public int Delete (short id){
        string sql = " DELETE FROM Category WHERE CategoryID = @Id ";
        return connection.Execute(sql, new{id});
    }

    public Category? GetCategory(short id){
        string sql = "SELECT * FROM Category WHERE CategoryID = @id";
        return connection.QuerySingleOrDefault<Category>(sql, new{id});
    }
    public int Edit(Category obj){
        string sql = "UPDATE Category SET CategoryName = @CategoryName, CategoryAlias = @CategoryAlias, Description = @Description, ImageUrl = @ImageUrl  WHERE CategoryID = @CategoryID";
        return connection.Execute(sql, obj);
    }

}