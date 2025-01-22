using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    /// <summary>
    /// Implements the ICheckout interface to manage scanned items and calculate total price of items picked.
    /// </summary>
    public class Checkout : ICheckout
    {
        private readonly List<ThePricingRule> _pricingRules;
        private readonly List<string> _scannedItems;

        /// <summary>
        /// Create a new instance of the Checkout class with pricing rules.
        /// </summary>
        /// <param name="pricingRules">list of pricing rules.</param>
        public Checkout(List<ThePricingRule> pricingRules)
        {
            _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
            _scannedItems = new List<string>();
        }

        /// <summary>
        /// Scans an item into the checkout system.
        /// </summary>
        /// <param name="item">The SKU of the item to scan.</param>
        public void Scan(string item)
        {
            // Ensure the item is not null or empty.
            if (string.IsNullOrWhiteSpace(item))
            {
                throw new ArgumentException("Item SKU cannot be null or empty.");
            }
            // Check if the item exists in the pricing rules.
            if (!_pricingRules.Any(rule => rule.SKU == item))
            {
                throw new ArgumentException($"Invalid SKU: {item}");
            }            
            //Add item to list of scanned items.
            _scannedItems.Add(item);
        }

        /// <summary>
        /// Calculates the total price of all scanned items.
        /// </summary>
        /// <returns>The total price.</returns>
        public int GetTotalPrice()
        {
            int total = 0;

            // Group scanned items by SKU for easier processing.
            var groupedItems = _scannedItems.GroupBy(item => item);

            foreach (var group in groupedItems)
            {
                string sku = group.Key;
                int quantity = group.Count();

                // Find the matching pricing rule.
                var rule = _pricingRules.First(r => r.SKU == sku);
                //Check if this SKU has a special pricing rule like "3 for 130".
                if (rule.SpecialQuantity.HasValue && rule.SpecialPrice.HasValue)
                {
                    // Calculate special bundles that can be form.
                    int bundles = quantity / rule.SpecialQuantity.Value;

                    // Calculate leftover after forming a bundle.
                    int remainder = quantity % rule.SpecialQuantity.Value;

                    total += bundles * rule.SpecialPrice.Value; // Add price for the bundles to the total(Bundles: 2 * 130 = 260).
                    total += remainder * rule.UnitPrice;  // Add the price for the leftover items to the total(Remainder: 1 * 50 = 50).
                }
                else
                {
                    total += quantity * rule.UnitPrice;
                }
            }

            return total;
        }

    }
}
