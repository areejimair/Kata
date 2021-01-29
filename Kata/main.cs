
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    class main
    {
        /*To Test it price can be written as $20.25 or 20.25 ($ or anyCURRENCY)*/
        /*The Rate (Percent is applied % then number)*/


        static void Main(string[] args)
        {
            Product p = new Product( "The Little Prince",12345,"20.25 USD");
            Console.WriteLine("                     Product Information");
            p.Tostring();
            
            
           
            CaculatePrice c = new CaculatePrice();
            int number = 0;
            while (true)
            {
               
                Console.WriteLine("1-Apply only Tax");
                Console.WriteLine("2-Apply Discount");
                Console.WriteLine("3-Report Applying Tax and Discount");
                Console.WriteLine("4-SELECTIVE Special Discount to UPC number");
                Console.WriteLine("5- PRECEDENCE Special Discount to UPC number Before Applying Tax");
                Console.WriteLine("6- EXPENSES");
                Console.WriteLine("7- COMBINING Method");
                Console.WriteLine("8- CAP");
               
                number = Convert.ToInt32(Console.ReadLine());
                switch (number){
                    case 1: {
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                           
                            double answer = 0.0;
                            answer = c.PriceCalculate(TaxRate,0.0,0.0);
                            Console.WriteLine("Cost= " + Product.Price);
                            Console.WriteLine("Tax Amount= " + c.taxAmount.toDoublePreision() + Product.priceType);
                            Console.WriteLine("Total=" + answer.toDoublePreision() + Product.priceType);
                           
                            break;
                        }
                    case 2:
                        {
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            Double DiscountRate = Console.ReadLine().PercentToDouble();
                            double total =c.PriceCalculate(TaxRate, DiscountRate,0.0);
                            Console.WriteLine("Tax=" + c.tax_rate.toPercentAge() + ", discount=" + c.discount_rate.toPercentAge()
                             + ",Tax Amount=" + c.taxAmount.toDoublePreision() + ",Discount amount =" + c.discountAmount.toDoublePreision()
                             + "Price before =" + Product.Price+ ", price after = " + total.toDoublePreision()+Product.priceType);
                            break;
                        }
                    case 3:
                        {
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            Double DiscountRate = Console.ReadLine().PercentToDouble();
                            if (DiscountRate == 0.0)
                            {
                                double total = c.PriceCalculate(TaxRate, DiscountRate,0.0);
                                Console.WriteLine("Total Price="+total.toDoublePreision()+ Product.priceType);
                                Console.WriteLine("There is no discounted amount");
                            }
                            else
                            {
                                double total = c.PriceCalculate(TaxRate, DiscountRate,0.0);
                                Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                Console.WriteLine(c.discountAmount.toDoublePreision()+ Product.priceType + " discount amount which was deduced");
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            Double DiscountRate = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC-discount =");
                            double specialDiscount=Console.ReadLine().PercentToDouble();
                            Console.Write("UPC =");
                            int UPC=Convert.ToInt32(Console.ReadLine());
                            if (UPC.Equals(p.UPC))
                            {
                                double total = c.PriceCalculate(TaxRate, DiscountRate,specialDiscount);
                                Console.WriteLine("Total Price=" + total.toDoublePreision() + Product.priceType);
                                Console.WriteLine("Total discount amount "+ c.discountAmount.toDoublePreision() + Product.priceType);
                            }
                            else
                            {
                                double total = c.PriceCalculate(TaxRate, DiscountRate,0.0);
                                Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                Console.WriteLine("Total discount amount " + c.discountAmount.toDoublePreision() + Product.priceType);
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            Double DiscountRate = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC-discount =");
                            double specialDiscount = Console.ReadLine().PercentToDouble();
                            Console.Write("Type of Discount(before or after) =");
                            string typeDiscount = Console.ReadLine();
                            Console.Write("UPC =");
                            int ? UPC = Convert.ToInt32(Console.ReadLine());
                            if (UPC.Equals(p.UPC))
                            {
                                double total = c.TotalPrice(TaxRate, DiscountRate, specialDiscount,typeDiscount);
                                Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                Console.WriteLine("Total discount amount " + c.discountAmount.toDoublePreision()+ Product.priceType);
                            }
                            else
                            {
                                double total = c.TotalPrice(TaxRate, DiscountRate,0.0,typeDiscount);
                                Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                Console.WriteLine("Total discount amount " + c.discountAmount.toDoublePreision()+ Product.priceType);
                            }
                            break;
                        }
                    case 6:
                        {
                           
                            Double? DiscountRate;
                            double? specialDiscount;
                            string UPC;
                            Double? PackingCost;
                            Double? TransportCost;
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            DiscountRate = Console.ReadLine().PercentToDouble();
                            Console.Write("Dis" + DiscountRate);
                            Console.Write("UPC-discount =");
                            specialDiscount = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC =");
                            UPC = Console.ReadLine();
                            Console.Write("Packaging cost percent =");
                            PackingCost = Console.ReadLine().PercentToDouble();
                            Console.Write("Transport cost =");
                            TransportCost = Console.ReadLine().toPrice();

                            if (String.IsNullOrEmpty(UPC))
                            {
                                
                                if (DiscountRate==0 && specialDiscount==0 && PackingCost==0 && TransportCost==0 )
                                {
                                    
                                    double total = c.PriceCalculate(TaxRate,0.0,0.0);
                                    Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                    Console.WriteLine("no Discounts");
                                }
                                
                            }
                            else
                            {
                               
                                double discountRate = DiscountRate ?? 0.0;
                                double special_discount = specialDiscount ?? 0.0;
                                double Packing_cost = PackingCost ?? 0.0;
                                double Transport_cost = TransportCost ?? 0.0;
                                
                                    double total = c.TotalPriceWithExpense(TaxRate, discountRate, special_discount, Packing_cost, Transport_cost);
                                    Console.WriteLine("Cost=" + Product.PriceCurrency+ Product.priceType);
                                    Console.WriteLine("Tax=" + c.taxAmount.toDoublePreision() + Product.priceType);
                                    Console.WriteLine("Discounts=" + c.discountAmount.toDoublePreision() + Product.priceType);
                                    Console.WriteLine("Packaging=" + c.Packaging_rate.toDoublePreision() + Product.priceType);
                                    Console.WriteLine("Transport=" + c.Transport_cost.toDoublePreision() + Product.priceType);
                                    Console.WriteLine("Total Price=" + total.toDoublePreision() + Product.priceType);

                                
                            }
                           
                            break;
                        }
                    case 7:
                        {

                            Double? DiscountRate;
                            double? specialDiscount;
                            string UPC;
                            Double? PackingCost;
                            Double? TransportCost;
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            DiscountRate = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC-discount =");
                            specialDiscount = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC =");
                            UPC = Console.ReadLine();
                            Console.Write("Packaging cost percent =");
                            PackingCost = Console.ReadLine().toPrice();
                            Console.Write("Transport cost =");
                            TransportCost = Console.ReadLine().toPrice();
                            Console.Write("combining method for  discounts:=");
                            string method = Console.ReadLine();

                            if (String.IsNullOrEmpty(UPC))
                            {

                                if (DiscountRate == 0 && specialDiscount == 0 && PackingCost == 0 && TransportCost == 0)
                                {

                                    double total = c.PriceCalculate(TaxRate,0.0,0.0);
                                    Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                    Console.WriteLine("no Discounts");
                                }

                            }

                            else
                            {
                                int UPCn = Convert.ToInt32(UPC);
                                if (UPCn.Equals(p.UPC))
                                {
                                    {
                                        Console.WriteLine("Im here");
                                        double discountRate = DiscountRate ?? 0.0;
                                        double special_discount = specialDiscount ?? 0.0;
                                        double Packing_cost = PackingCost ?? 0.0;
                                        double Transport_cost = TransportCost ?? 0.0;

                                        double total = c.TotalPriceWithExpenseMethod(TaxRate, discountRate, special_discount, Packing_cost, Transport_cost, method);
                                        Console.WriteLine("Cost=" + Product.PriceCurrency+ Product.priceType);
                                        Console.WriteLine("Tax=" + c.taxAmount.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Discounts=" + c.discountAmount.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Packaging=" + c.Packaging_rate.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Transport=" + c.Transport_cost.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                    }

                                }
                            }


                            break;
                        }
                    case 8:
                        {

                            Double? DiscountRate;
                            double? specialDiscount;
                            string UPC;
                            Double? PackingCost;
                            Double? TransportCost;
                            Console.Write("TaxRate=");
                            Double TaxRate = Console.ReadLine().PercentToDouble();
                            Console.Write("DiscountRate=");
                            DiscountRate = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC-discount =");
                            specialDiscount = Console.ReadLine().PercentToDouble();
                            Console.Write("UPC =");
                            UPC = Console.ReadLine();
                            Console.Write("Packaging cost percent =");
                            PackingCost = Console.ReadLine().toPrice();
                            Console.Write("Transport cost =");
                            TransportCost = Console.ReadLine().toPrice();
                            Console.Write("combining method for  discounts:=");
                            string method = Console.ReadLine();
                            Console.Write("Cap=");
                            string Cap = Console.ReadLine();
                            if (String.IsNullOrEmpty(UPC))
                            {

                                if (DiscountRate == 0 && specialDiscount == 0 && PackingCost == 0 && TransportCost == 0)
                                {

                                    double total = c.PriceCalculate(TaxRate,0.0,0.0);
                                    
                                    Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                    Console.WriteLine("no Discounts");
                                }

                            }
                            else
                            {
                                int UPCn = Convert.ToInt32(UPC);
                                double discountRate = DiscountRate ?? 0.0;
                                double special_discount = specialDiscount ?? 0.0;
                                double Packing_cost = PackingCost ?? 0.0;
                                double Transport_cost = TransportCost ?? 0.0;
                                if (UPCn.Equals(p.UPC))
                                {
                                    {
                                        Console.WriteLine("Im here");
                                        double total = c.TotalPriceWithCAP(TaxRate, discountRate, special_discount, Packing_cost, Transport_cost,method,Cap);
                                        Console.WriteLine("Cost=" + Product.PriceCurrency+ Product.priceType);
                                        Console.WriteLine("Tax=" + c.taxAmount.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Discounts=" + c.discountAmount.toDoublePreision()+ Product.priceType);
                                        Console.WriteLine("Packaging=" + c.Packaging_rate.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Transport=" + c.Transport_cost.toDoublePreision() + Product.priceType);
                                        Console.WriteLine("Total Price=" + total.toDoublePreision()+ Product.priceType);
                                    }

                                }
                                else
                                {
                                    double total = c.PriceCalculate(TaxRate, discountRate, 0.0);

                                    Console.WriteLine("Total Price=" + total.toDoublePreision() + Product.priceType);
                                    Console.WriteLine("Discounts="+c.discountAmount.toDoublePreision());
                                }
                            }


                            break;
                        }




                    default: { break; }
                
                
                }
            }
           
            Console.ReadLine();

        }
    }
}
