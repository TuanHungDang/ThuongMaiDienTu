using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace WebAdmin.Models;

public class SupplierRepository:BaseRepository
{
    public SupplierRepository(IDbConnection cn):base(cn)
    {}

    public IEnumerable<Supplier> GetSuppliers()
    {
        return connection.Query<Supplier>("SELECT * FROM Supplier");
    }

    public int Add(Supplier obj)
    {
        string sql = "INSERT INTO Supplier (SupplierId, CompanyName, Logo, ContactName, Email, Phone, Address, Description) VALUES (@SupplierId,@CompanyName, @Logo,@ContactName,@Email, @Phone,@Address,@Description)";
        return connection.Execute(sql, obj);
    }

    public int Delete(string id)
    {
        string sql = "DELETE FROM Supplier WHERE SupplierId = @id";
        return connection.Execute(sql, new{id});
    }

    public Supplier? GetSupplier(string id)
    {
        string sql = "SELECT * FROM Supplier WHERE SupplierId = @id";
        return connection.QuerySingleOrDefault<Supplier>(sql, new{id});
    }

    public int Edit (Supplier obj)
    {
        string sql = "UPDATE Supplier SET CompanyName = @CompanyName, Logo = @Logo, ContactName = @ContactName, Email = @Email, Phone = @Phone, Address = @Address , Description = @Description WHERE SupplierId = @SupplierId";
        return connection.Execute(sql, obj);
    }
}