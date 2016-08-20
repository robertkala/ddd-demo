using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Exceptions;
using DDDDemo.InvoicingModule.Domain.Interfaces;
using DDDDemo.InvoicingModule.Domain.Users;
using DDDDemo.Persistence;
using DDDDemo.SharedKernel;

namespace DDDDemo.InvoicingModule.Infrastructure.Persistence.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Get(int id)
        {
            var dbUser = _dbContext.Users.SingleOrDefault(p => p.Id == id);

            if (dbUser != null)
            {
                var address = new Address(dbUser.City, dbUser.PostalCode, dbUser.StreetName, dbUser.StreetNumber, dbUser.Country);
                return new User(
                    dbUser.Id,
                    dbUser.FirstName,
                    dbUser.LastName,
                    address);
            }
            
            throw new EntityNotFoundException();
        }
    }
}
