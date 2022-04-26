using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C_Sharp_Boiler.Models
{
    public class User 
    {
        [Key]
        public int UserID {get; set;}

        // Other features
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get; set;}



    }
}