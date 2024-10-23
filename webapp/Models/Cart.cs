namespace WebApp.Models;

public class Cart{
    public string CartCode{get;set;} = null!;
    public int ProductId{get; set;}
    public string ProductName{get; set;} = null!;
    public string Image{get; set;} = null!;
    public decimal Price{get;set;}
    public short Quantity{get; set;}
}