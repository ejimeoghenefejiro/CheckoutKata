using System;
using System.Collections.Generic;
using Xunit;

namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        [Fact]
        public void SingleItemTest()
        {
            var pricingRules = new List<ThePricingRule>
            {
                new ThePricingRule("A", 50, 3, 130),
                new ThePricingRule("B", 30, 2, 45)
            };
            var checkout = new Checkout(pricingRules);

            checkout.Scan("A");
            Assert.Equal(50, checkout.GetTotalPrice());
        }

        [Fact]
        public void SpecialPricingTest()
        {
            var pricingRules = new List<ThePricingRule>
            {
                new ThePricingRule("A", 50, 3, 130),
                new ThePricingRule("B", 30, 2, 45)
            };
            var checkout = new Checkout(pricingRules);

            checkout.Scan("A");
            checkout.Scan("A");
            checkout.Scan("A");

            Assert.Equal(130, checkout.GetTotalPrice());
        }

        [Fact]
        public void MixedItemsTest()
        {
            //pricing rules.
            var pricingRules = new List<ThePricingRule>
            {
                new ThePricingRule("A", 50, 3, 130),  // "A": 50 each, 3 for 130.
                new ThePricingRule("B", 30, 2, 45),   // "B": 30 each, 2 for 45.
                new ThePricingRule("C", 20)           // "C": 20 each, no special price.
            };

            var checkout = new Checkout(pricingRules);
            
            checkout.Scan("A");  // "A"- 50.
            checkout.Scan("B");  // "B"- 30.
            checkout.Scan("A");  // "A"- 50.
            checkout.Scan("A");  // "A"- Special price applied (3 for 130).
            checkout.Scan("B");  // "B"- Special price applied (2 for 45).

            // 130 (A) + 45 (B) = 175
            Assert.Equal(175, checkout.GetTotalPrice());
        }
    }
}
