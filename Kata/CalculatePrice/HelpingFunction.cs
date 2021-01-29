using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public static class HelpingFunction
    {
        public static string ToDoublePreision(this double twoPre)
        {
            return String.Format("{0:0.00}", twoPre);
        }
        public static double toDoublePreision(this double twoPre)
        {
            return Math.Round(twoPre, 2);
        }
       
        public static string toPercentAge(this double amount)
        {
            return amount.ToString("#0.##%");
        }
        public static double PercentToDouble(this string percent)
        {
            string Sdouble = null;
            if ((percent==null))
            {
                return 0.0;
            }
            for(int i = 1; i < percent.Length; i++)
            {
                Sdouble += percent[i];

            }
            return (Convert.ToDouble(Sdouble))/100;    
        }
        public static double toPrice(this string price)
        {
            string pricetotal = null;
            if (String.IsNullOrEmpty(price))
            {
                return 0.0;
            }
            else
            {
                if (price[0] == ('$'))
                {
                    Product.priceType = "$";
                    for (int i = 1; i < price.Length; i++)
                    {
                        pricetotal += price[i];
                    }
                }
                else if (price[0] == '%') {

                    return price.PercentToDouble()*Product.PriceCurrency;
                }

                else
                {

                    string[] split = price.Split(' ');
                    pricetotal = split[0];
                    Product.priceType = split[1];
                }
            }

            return Convert.ToDouble(pricetotal);
        }
    }
}
