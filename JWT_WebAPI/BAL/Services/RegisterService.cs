using BAL.Configurations;
using BAL.Model;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BAL.Configuration;
using System.Collections.Generic;
using TestServerApi;

namespace BAL.Services
{
    public class RegisterService : AppDbContext, IRegisterService
    {
        private PasswordManager passwordManager;
        public RegisterService(PasswordManager _passwordManager)
        {
            passwordManager = _passwordManager;
        }

        public async Task<string> RegisterUser(RegisterDTO register)
        {
            try
            {
                OpenContext();
                _sqlCommand.Clear_CommandParameter();
                _sqlCommand.Add_Parameter_WithValue("prm_username", register.username);

                DataTable user_result = await _sqlCommand.Select_Table("select username from register where username=@prm_username", CommandType.Text);
                List<RegisterDTO> userDetails = DataTableVsListOfType.ConvertDataTableToList<RegisterDTO>(user_result);

                if(userDetails.Count > 0)
                {
                    return "User already exist";
                }
                else
                {
                    register.password = passwordManager.HashPassword(register.password);
                    await _sqlCommand.AddOrEditWithStoredProcedure("register_userRegister", null, register, "prm_");
                    return "Register Successful";
                }

                

            }
            catch (Exception) 
            {
                throw new Exception("User register failed");
            }
            finally 
            { 
                CloseContext();
            }


        }



    }
}
