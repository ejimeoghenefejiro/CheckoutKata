using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class ThePricingRule
    {       
        public class PricingRule
        {
            public string SKU { get; } //Stock Keeping Unit (SKU) identifier.
            public int UnitPrice { get; } //Price per unit of the item.
            public int? SpecialQuantity { get; } //For the special pricing rule quantity
            public int? SpecialPrice { get; } // Total price for the special quantity.

            /// <summary>
            /// create a new instance of the PricingRule class.
            /// </summary>
           
            public PricingRule(string sku, int unitPrice, int? specialQuantity = null, int? specialPrice = null)
            {
                SKU = sku;
                UnitPrice = unitPrice;
                SpecialQuantity = specialQuantity;
                SpecialPrice = specialPrice;
            }

        }
    }
}
