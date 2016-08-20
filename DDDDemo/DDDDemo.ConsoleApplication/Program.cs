using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;
using DDDDemo.ConsoleApplication.DIBootstrapper;
using DDDDemo.SharedKernel.Events;
using DDDDemo.UserManagement.Application.Users;

namespace DDDDemo.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new Bootstrapper().CreateContainer();
            var userService = container.Resolve<IUserService>();
            var listener = container.Resolve<IEventListener<UserCreatedEvent>>();

            

            //fail request - password is too weak
            var failRequest = new UserCreationRequest()
            {
                City = "Katowice",
                Country = "Polska",
                FirstName = "Adam",
                LastName = "Nowak",
                IsAdmin = true,
                Password = "1234567", 
                PostalCode = "40-000",
                StreetName = "3 Maja",
                StreetNumber = "23"
            };

            var successRequest = new UserCreationRequest()
            {
                City = "Katowice",
                Country = "Polska",
                FirstName = "Adam",
                LastName = "Nowak",
                IsAdmin = false,
                Password = "1234567",
                PostalCode = "40-000",
                StreetName = "3 Maja",
                StreetNumber = "23"
            };


            userService.CreateUser(successRequest);

            System.Console.ReadKey();
        }
    }
}
