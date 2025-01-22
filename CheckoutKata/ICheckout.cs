using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    /// <summary>
    /// Defines the contract for a checkout library 
    /// </summary>
    public interface ICheckout
    {
        /// <summary>
        /// Scan an item into checkout
        /// </summary>
       
        void Scan(string item); // SKU of the item to scan

        /// <summary>
        /// Calculates the total price of all scanned items
        /// </summary>
        /// <returns> total price</returns>
        int GetTotalPrice();
    }
}
