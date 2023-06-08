using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.Models
{
    public class SignInRequest
    {
        public string? LoginOrEmail { get; set; }

        public string? Password { get; set; }
    }
}
