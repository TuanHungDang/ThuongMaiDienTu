namespace webapp.Models;

public class Invoice
{
    public string CartCode { get; set; } = null!;
    public long InvoiceId { get; set; }
    public decimal Amount { get; set; } 
    public DateTime InvoiceDate { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;

}