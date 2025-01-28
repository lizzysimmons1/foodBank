using System;
using System.Collections.Generic;
using FoodBankInventorySystem;

// link the two programs
namespace FoodBankInventorySystem
{
    class Program
    {
        static List<FoodItem> inventory = new List<FoodItem>();

        static void Main(string[] args)
        {
            // begin the main loop for the system
            while (true)
            {   // options for updating the food bank
                Console.WriteLine("\nFood Bank Inventory System");
                Console.WriteLine("1. Add Food Item");
                Console.WriteLine("2. Delete Food Item");
                Console.WriteLine("3. Print List of Current Food Items");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option (enter the number): ");

                string choice = Console.ReadLine();
                // pick choice based on inputted number 
                switch (choice)
                {
                    case "1":
                        AddFoodItem();
                        break;
                    case "2":
                        DeleteFoodItem();
                        break;
                    case "3":
                        PrintFoodItems();
                        break;
                    case "4":
                        Console.WriteLine("Exiting Food Bank Inventory System. Goodbye!");
                        return;
                    default: // if no valid number is chosen have user try again
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddFoodItem()
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();

                Console.Write("Enter category: ");
                string category = Console.ReadLine();

                // make sure this one is a number 
                Console.Write("Enter quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Console.Write("Enter expiration date: ");
                string expirationDate = Console.ReadLine();

                // create foodItem variable with these inputs
                FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
                inventory.Add(newItem);
                Console.WriteLine("Food item added successfully.");
            }
            catch (Exception ex)
            {
                // watch for bugs 
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteFoodItem()
        {
            try
            {
                Console.Write("Enter the name of the food item to delete: ");
                string name = Console.ReadLine();

                FoodItem itemToRemove =
                    // check for food item inputted, ignore the user case 
                    inventory.Find(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (itemToRemove != null)
                {
                    inventory.Remove(itemToRemove);
                    Console.WriteLine("Food item deleted successfully.");
                }
                else
                {
                    // if that item is not listed return this error: 
                    Console.WriteLine("Food item not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void PrintFoodItems()
        {
            if (inventory.Count == 0)
            {
                Console.WriteLine("No food items in inventory.");
            }
            else
            {
                Console.WriteLine("\nCurrent Food Items:");
                foreach (var item in inventory)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
