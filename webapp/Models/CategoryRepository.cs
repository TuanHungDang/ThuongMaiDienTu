using Dapper;
using System.Data;

namespace webapp.Models;
public class CategoryRepository : BaseRepository
{
    public CategoryRepository(IDbConnection cn) : base(cn) { }

    public IEnumerable<Category> GetCategories()
    {
        return connection.Query<Category>("Select * from Category");
    }

    public Category? GetCategory(short id)
    {
        string sql = "SELECT * FROM Category WHERE CategoryID = @id";
        return connection.QuerySingleOrDefault<Category>(sql, new { id });
    }

}