using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Model
{
    public class UserDTO
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string phone { get; set; }
    }

    public class UserDTOService
    {
        private List<UserDTO> users = new List<UserDTO>();

        public void AddUsers(UserDTO user)
        {
            users.Add(user);
        }

        public List<UserDTO> GetUsers() 
        { 
            return users;
        }
    }
}
