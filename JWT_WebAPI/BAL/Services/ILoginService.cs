using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using BAL.Model;

namespace BAL.Services
{
    public interface ILoginService
    {
        Task<string> LoginUser(LoginDTO login);

    }
}
