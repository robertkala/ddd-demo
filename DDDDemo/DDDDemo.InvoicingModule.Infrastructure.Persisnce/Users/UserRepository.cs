using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Exceptions;
using DDDDemo.InvoicingModule.Domain.Interfaces;
using DDDDemo.InvoicingModule.Domain.Users;
using DDDDemo.Persistence;

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
                return new User(
                    dbUser.Id,
                    dbUser.FirstName,
                    dbUser.LastName,
                    dbUser.City,
                    dbUser.PostalCode,
                    dbUser.StreetName,
                    dbUser.StreetNumber);
            }
            
            throw new EntityNotFoundException();
        }
    }
}
