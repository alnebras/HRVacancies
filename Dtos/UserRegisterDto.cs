using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRVacancies.Dtos
{
    public class UserRegisterDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
    }
}
