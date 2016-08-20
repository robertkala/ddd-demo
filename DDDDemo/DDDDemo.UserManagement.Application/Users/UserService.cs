using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDDemo.Common.Events;
using DDDDemo.Common.Operations;
using DDDDemo.SharedKernel.Events;
using DDDDemo.UserManagement.Domain.Interfaces;
using DDDDemo.UserManagement.Domain.Users;
using DDDDemo.UserManagement.Domain.Users.Factories;

namespace DDDDemo.UserManagement.Application.Users
{
    public class UserService : IUserService
    {
        private readonly UserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IEventPublisher _eventPublisher;

        public UserService(UserFactory userFactory, IUserRepository userRepository, IEventPublisher eventPublisher)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _eventPublisher = eventPublisher;
        }

        public Response CreateUser(UserCreationRequest userCreationRequest)
        {
            User user = null;
            if (userCreationRequest.IsAdmin)
            {
                user = _userFactory.CreateAdmin(userCreationRequest.FirstName, userCreationRequest.LastName,
                    userCreationRequest.Password, userCreationRequest.City, userCreationRequest.PostalCode,
                    userCreationRequest.StreetName, userCreationRequest.StreetNumber, userCreationRequest.Country);
            }
            else
            {
                user = _userFactory.CreateUser(userCreationRequest.FirstName, userCreationRequest.LastName,
                    userCreationRequest.Password, userCreationRequest.City, userCreationRequest.PostalCode,
                    userCreationRequest.StreetName, userCreationRequest.StreetNumber, userCreationRequest.Country);
            }

            var userId = _userRepository.Add(user);
            user.Id = userId;

            var userCreationEvent = new UserCreatedEvent(userId);

            _eventPublisher.Publish(userCreationEvent);

            return Response.CreateSuccessfulResponse();
        }
    }
}
