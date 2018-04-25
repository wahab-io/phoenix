using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Phoenix.Core;
using Phoenix.Domain;
using Phoenix.Domain.Customer;

namespace Phoenix.Infrastructure.EFCore
{
    /// <summary>
    /// The single responsibility of Customer Repository is to
    /// encapsulate customer persistance logic
    /// </summary>
    public class CustomerRepository : DbContext, IRepository<Customer>
    {
        private readonly ILogger logger;
        public DbSet<Customer> Customers { get; set; }
        public CustomerRepository(ILogger logger)
        {
            this.logger = logger;
            logger.LogInformation("CustomerRepository::CustomerRepository()");
        }

        public Task<IQueryable<Customer>> GetAll()
        {
            logger.LogInformation("CustomerRepository::GetAll()");
            throw new NotImplementedException();
        }

        public Task<Customer> Get(Expression<Func<Customer, bool>> predicate)
        {
            logger.LogInformation("CustomerRepository::Get()");
            throw new NotImplementedException();
        }

        public Task<Customer> GetById(long id)
        {
            logger.LogInformation("CustomerRepository::GetById()");
            throw new NotImplementedException();
        }

        public Task Create(Customer newEntity)
        {
            logger.LogInformation("CustomerRepository::Create()");
            throw new NotImplementedException();
        }

        public Task Remove(Customer entity)
        {
            logger.LogInformation("CustomerRepository::Remove()");
            throw new NotImplementedException();
        }
    }
}