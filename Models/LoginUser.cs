using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_Sharp_Boiler.Models
{
    public class LoginUser 
    {
        
        // Other features
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword {get; set;}
        



    }
}