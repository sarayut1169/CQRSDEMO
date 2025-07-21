using CQRSDEMO.Models.Entities;
using CQRSDEMO.Models.Repositories.Bases;
using Microsoft.EntityFrameworkCore;
namespace CQRSDEMO.Models.Repositories.Customer
{
    public class CustomerRepository : DbRepositoryBase<Entities.Customer> , ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

    }
}
