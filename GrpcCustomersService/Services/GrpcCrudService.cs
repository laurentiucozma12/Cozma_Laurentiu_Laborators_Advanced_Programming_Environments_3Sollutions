using Grpc.Core;
using GrpcCustomersService;
using DataAccess = LibraryModel.Data;
using ModelAccess = LibraryModel.Models;
public class GrpcCrudService : CustomerService.CustomerServiceBase
{

    private DataAccess.LibraryContext db = null;
    public GrpcCrudService(DataAccess.LibraryContext db)
    {
        this.db = db;
    }
    public override Task<CustomerList> GetAll(Empty empty, ServerCallContext context)
    {
        CustomerList pl = new CustomerList();
        var query = from cust in db.Customers
                    select new Customer()
                    {
                        Id = cust.Id,
                        Name = cust.Name,
                        Address = cust.Address,
                        Birthdate=cust.BirthDate.ToString()
                    };
        pl.Item.AddRange(query.ToArray());
        return Task.FromResult(pl);
    }
    public override Task<Empty> Insert(Customer requestData, ServerCallContext context)
    {
        db.Customers.Add(new ModelAccess.Customer
        {
            Id = requestData.Id,
            Name = requestData.Name,
            Address = requestData.Address,
            BirthDate = DateTime.Parse(requestData.Birthdate)
        });
        db.SaveChanges();
        return Task.FromResult(new Empty());
    }
}