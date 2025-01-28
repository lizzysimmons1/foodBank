namespace FoodBankInventorySystem
{
    public class FoodItem
    {
        // define the variables tracked in the inventory system
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string ExpirationDate { get; set; }

        public FoodItem(string name, string category, int quantity, string expirationDate)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            Name = name;
            Category = category;
            Quantity = quantity;
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return
                $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, Expiration Date: {ExpirationDate}";
        }
    }
}