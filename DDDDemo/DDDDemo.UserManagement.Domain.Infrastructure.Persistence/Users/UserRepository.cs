using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Exceptions;
using DDDDemo.Persistence;
using DDDDemo.Persistence.Helper;
using DDDDemo.SharedKernel;
using DDDDemo.UserManagement.Domain.Interfaces;
using DDDDemo.UserManagement.Domain.Users;

namespace DDDDemo.UserManagement.Infrastructure.Persistence.Users
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
                var coordinates = new Coordinates(dbUser.Latitude, dbUser.Longitude);

                return new User(
                    dbUser.Id,
                    dbUser.FirstName,
                    dbUser.LastName,
                    dbUser.Password,
                    address, coordinates);
            }

            throw new EntityNotFoundException();

        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public int Add(User user)
        {
            var newId = _dbContext.Users.GetNewId();

            _dbContext.Users.Add(new DbUser(
                newId,
                user.FirstName,
                user.LastName,
                user.Password,
                user.Address.City,
                user.Address.PostalCode,
                user.Address.StreetName,
                user.Address.StreetNumber,
                user.Address.Country,
                user.Coordinates.Latitude,
                user.Coordinates.Longitude
                ));

            return newId;
        }
    }
}
