using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    public class CaculatePrice 
    {
        public Product product { get; set; }
        public double tax_rate { get; set; }
        public double discount_rate { get; set; }
        public double special_discount_rate { get; set; }
        public double special_discount_before_Tax { get; set; }
        public double Packaging_rate { get; set; }
        public double Transport_cost { get; set; }
        public double taxAmount { get; set; }
        public double discountAmount { get; set; }
        public double CapAmount { get; set; }
        public double UPCAmountMulti { get; set; }

        public double PriceCalculate(double TaxRate, double DiscountRate,double specialDiscount)
        {

            this.tax_rate = TaxRate;
            this.discount_rate = DiscountRate;
            this.special_discount_rate = specialDiscount;
           
            this.taxAmount = Product.PriceCurrency * TaxRate;
            double totaldiscount=((Product.PriceCurrency * DiscountRate) + (Product.PriceCurrency * specialDiscount));
            this.discountAmount = totaldiscount;
            return ( (Product.PriceCurrency * TaxRate) + Product.PriceCurrency) -totaldiscount;
        }
        public double TotalPrice(double TaxRate, double DiscountRate, double specialDiscount, string typeOfDiscount)
        {
            if (String.IsNullOrEmpty(typeOfDiscount) || typeOfDiscount == "after")
            {
                return PriceCalculate(TaxRate, DiscountRate, specialDiscount);
            }
            else
            {
                double newPricebeforeTax = (Product.PriceCurrency - ((Product.PriceCurrency * specialDiscount)).toDoublePreision()).toDoublePreision();
                double UPCdiscount = ((Product.PriceCurrency * specialDiscount)).toDoublePreision();
                this.taxAmount = (newPricebeforeTax * TaxRate).toDoublePreision();
                double DiscountAmount = (newPricebeforeTax * DiscountRate).toDoublePreision();
                this.discountAmount = UPCdiscount + DiscountAmount;
                return Product.PriceCurrency - UPCdiscount + taxAmount - DiscountAmount;
            }
        }
        public double TotalPriceWithExpense(double TaxRate, double DiscountRate, double specialDiscount,double packingCost,double TransportCost)
        {

            this.Packaging_rate = packingCost * Product.PriceCurrency;
            double totalPrice = TotalPrice(TaxRate, DiscountRate, specialDiscount,"");
            
            return totalPrice+ this.Packaging_rate + TransportCost;
        }
       
    
      
       

        public double TotalPriceWithExpenseMethod(double taxRate, double discountRate, double special_discount, double packing_cost, double transport_cost,string method)
        {

            this.Packaging_rate = packing_cost;
            this.Transport_cost = transport_cost;
            if (method.Equals("additive discounts")||String.IsNullOrEmpty(method)) {
                return TotalPriceWithExpense(taxRate, discountRate, special_discount, packing_cost, transport_cost);
            
            }
            else if (method.Equals("multiplicative discounts")){
                double newPrice = (Product.PriceCurrency - ((Product.PriceCurrency * discountRate)));
                this.UPCAmountMulti = (newPrice * special_discount);
                this.taxAmount = (Product.PriceCurrency * taxRate);
                double DiscountAmount = (Product.PriceCurrency * discountRate);
                this.discountAmount = UPCAmountMulti + DiscountAmount;
                return (Product.PriceCurrency + taxAmount - DiscountAmount - UPCAmountMulti + Packaging_rate + Transport_cost);
            }
            return 0.0;
  
        }

        public double TotalPriceWithCAP(double taxRate, double discountRate, double special_discount, double packing_cost, double transport_cost,string method, string cap)
        {


            if (String.IsNullOrEmpty(cap))
            {
                return TotalPriceWithExpenseMethod(taxRate, discountRate, special_discount, packing_cost, transport_cost,method);
            }
             this.CapAmount = cap.toPrice();
            
            
            this.Packaging_rate = packing_cost * Product.PriceCurrency;
            this.Transport_cost = transport_cost;
            
            if (method.Equals("additive discounts")||String.IsNullOrEmpty(method))
            {
                double DiscountAmount = discountRate * Product.PriceCurrency + special_discount * Product.PriceCurrency;
                
                if (DiscountAmount > this.CapAmount)
                {
                    
                    Double total=TotalPriceWithExpense(taxRate, 0.0 , 0.0, packing_cost, transport_cost);
                    Console.WriteLine(total);
                    this.discountAmount = this.CapAmount;
                    
                    return total-discountAmount;
                   
                }
                else
                {
                    this.discountAmount = DiscountAmount;
                    return TotalPriceWithExpense(taxRate, discountRate, special_discount, packing_cost, transport_cost);
                }
               

            }
            else if (method.Equals("multiplicative discounts"))
            {
                double newPrice = TotalPriceWithExpenseMethod(taxRate, discountRate, special_discount, packing_cost, transport_cost, "multiplicative discounts");

                double Totaldiscount = this.discountAmount;
                
                if (Totaldiscount > this.CapAmount)
                {
                    this.discountAmount = this.CapAmount;
                    return (Product.PriceCurrency + taxAmount - this.CapAmount + Packaging_rate + Transport_cost);
                }
                else
                {
                    this.discountAmount = Totaldiscount;
                    return (Product.PriceCurrency + taxAmount - discountAmount - UPCAmountMulti + Packaging_rate + Transport_cost);
                }
                
            }
            return 0.0;
        }
        

    }
}
