using BAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IUserService
    {
         List<UserDTO> UserFunction();
    }
}
