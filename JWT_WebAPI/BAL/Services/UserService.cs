using BAL.Model;
using System;
using System.Collections.Generic;

namespace BAL.Services
{
    public class UserService : IUserService
    {
        private readonly UserDTOService _userDTOService;
        public UserService(UserDTOService userDTOService)
        {
            _userDTOService = userDTOService;
        }
        public List<UserDTO> UserFunction()
        {
            //Create UserDTO Object
            UserDTO user1 = new UserDTO { user_id = 1, username = "Sandeep", phone = "9876543210" };
            UserDTO user2 = new UserDTO { user_id = 2, username = "Dewas", phone = "0123456789" };

            //Add the User using UserDTOService
            _userDTOService.AddUsers(user1);
            _userDTOService.AddUsers(user2);

            // Retrieve the list of users from UserDTOService
            List<UserDTO> users = _userDTOService.GetUsers();

            return users;
        }


    }
}
