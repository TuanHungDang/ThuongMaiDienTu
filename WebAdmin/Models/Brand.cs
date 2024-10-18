namespace WebAdmin.Models;

public class Brand
{
    public short BrandId{get; set;}
    public string BrandName{get;set;} = null!;
    public string SupplierId{get;set;} = null!;
    public string Description{get;set;} = null!;
}