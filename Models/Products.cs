using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace C_Sharp_Boiler.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Photo {get; set;}
        [Required]
        [Range(0.01, double.MaxValue)]
        public double Price {get; set;}
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity {get; set;}
        [Required]
        public string Description {get; set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get; set;}

        // One to Many Connection
        public int UserId {get; set;}
        // Many to Many
        public List<Order> CustomerOrders {get; set;}



    }
}