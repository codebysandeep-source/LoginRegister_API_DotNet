using BAL.Configuration;
using BAL.Configurations;
using BAL.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestServerApi;

namespace BAL.Services
{
    public class LoginService : AppDbContext, ILoginService
    {
        private PasswordManager passwordManager;
        public LoginService(PasswordManager _passwordManager)
        {
            passwordManager = _passwordManager;
        }

        public async Task<string> LoginUser(LoginDTO login)
        {
            try
            {
                OpenContext();
                _sqlCommand.Clear_CommandParameter();
                _sqlCommand.Add_Parameter_WithValue("prm_username", login.username);

                string query = "select * from register where username = @prm_username";
                DataTable result = await _sqlCommand.Select_Table(query, CommandType.Text);
 
                List<LoginDTO> loginDetails = DataTableVsListOfType.ConvertDataTableToList<LoginDTO>(result);

                if(loginDetails.Count > 0)
                {
                    bool passwordResult = passwordManager.VerifyPassword(login.password,loginDetails[0].password);
                    if(passwordResult)
                    {
                        return "Login Successful";
                    }
                    else
                    {
                        return "Invalid Password";
                    }
                }
                else
                {
                    return "User not found";
                }

            }
            catch (Exception)
            {

                throw new Exception("Login Failed");

            }
            finally
            {
                CloseContext();
            }
           
        }
    
        
    }
}
