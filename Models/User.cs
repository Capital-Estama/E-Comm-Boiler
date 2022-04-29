using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace C_Sharp_Boiler.Models
{
    public class User 
    {
        [Key]
        public int UserID {get; set;}

        // Other features
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get; set;}
        [Required]
        [MinLength(2)]
        public string Username {get; set;}
        [Required]
        [EmailAddress]
        public string Email{get;set;}


        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;
        // connect to one to many
        public List<Product> ProductsBeingSold {get; set;}
        // connect to many to mamy
        public List<Order> MyOrders {get; set;}

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get; set;}

        



    }
}