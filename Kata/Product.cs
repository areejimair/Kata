
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class Product
    {
     public string Name { get; set; }
     public int UPC { get; set; }
     public static string Price { get; set; }
     public  static double PriceCurrency { get; set; }
     public static string priceType{ get; set; }

    public Product(string name, int uPC, string price)
        {
            Name = name;
            UPC = uPC;
            Price = price;
            ProductPriceCurrency();
        }
        public static void ProductPriceCurrency()
        {
            double pricetotal=Price.toPrice();
            
            PriceCurrency = Convert.ToDouble(pricetotal);
            
        }

        public void Tostring()
        {
            Console.WriteLine("Sample product: Book with name =" + this.Name +" ,UPC ="+this.UPC+ " ,price="+Price);
           
        }
    }
}
