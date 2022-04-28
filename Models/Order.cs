using System;
using System.ComponentModel.DataAnnotations;


namespace C_Sharp_Boiler.Models
{
    public class Order
    {

    

    [Key]
    public int OrderID {get; set;}
    public int UserID {get; set;}
    // Nav properties
    public User Buyer {get; set;}
    public Product Product {get; set;}
    public int ProductID {get; set;}
    public int QuantityBought {get; set;}
    public double OrderTotal {get; set;}
    public DateTime CreatedAt {get; set;} = DateTime.Now;
    public DateTime UpdatedAt {get; set;} = DateTime.Now;


    }
}