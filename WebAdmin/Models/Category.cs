namespace WebAdmin.Models;

public class Category
{
    public short CategoryId{get; set;}
    public string CategoryName { get; set; } = null!;
    public string CategoryAlias { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

}