using BAL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{
    public interface IRegisterService
    {
        Task<string> RegisterUser(RegisterDTO register);
    }
}
