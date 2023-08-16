using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BAL.Model
{
    public class RegisterDTO
    {
        
        public int register_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

    }

}
