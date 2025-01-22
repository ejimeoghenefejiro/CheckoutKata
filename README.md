# CheckoutKata
Checkout Kata library in C#
# Checkout Kata


## Example Pricing Rules

| SKU  | Unit Price | Special Price      |
|------|------------|--------------------|
| A    | 50         | 3 for 130          |
| B    | 30         | 2 for 45           |
| C    | 20         | None               |
| D    | 15         | None               |

## Example Calculation

SKU "A" has the following details:
- `quantity = 7`
- `SpecialQuantity = 3`
- `SpecialPrice = 130`
- `UnitPrice = 50`

Steps to calculate the total:
1. **Bundles**: `7 / 3 = 2`.
2. **Remainder**: `7 % 3 = 1`.
3. **Total**:
   - **Bundles**: `2 * 130 = 260`
   - **Remainder**: `1 * 50 = 50`
   - **Final Total**: `260 + 50 = 310`





