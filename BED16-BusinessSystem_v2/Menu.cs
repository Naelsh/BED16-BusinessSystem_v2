using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    class Menu
    {
        public Menu()
        {

        }

        // function for checking viability of user input, only validates on a single character
        public static bool CheckIfProperUserInput(string allowedInput, char input)
        {
            foreach (char character in allowedInput)
            {
                if (character == input)
                {
                    return true;
                }
            }
            return false;
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to order management of Group 4"
                                + "\n1. to add a product to the store"
                                + "\n2. to change the price of a product"
                                + "\n3. to change amount of a product in the inventory"
                                + "\n4. to register a new customer"
                                + "\n5. to create a new order for a customer"
                                + "\n6. to change an order"
                                + "\n7. to list all orders by a customer"
                                + "\n8. to cancel an order"
                                + "\n9. to quit");

            bool isProperUserInput = false;
            char itemSelection = '4';
            do
            {
                Console.Write("Select an option by entering the corresponding menu number ");
                string userInput = Console.ReadLine().ToString();
                isProperUserInput = CheckIfProperUserInput("1234", userInput[0]);
                if (isProperUserInput)
                {
                    itemSelection = userInput[0];
                }
            } while (!isProperUserInput);
            switch (itemSelection)
            {
                case '1':
                    // creates a new product
                    Product newProduct = Product.userInput();

                    break;
                case '2':
                    ShowChangeProductPriceMenu();
                    
                    break;
                case '3':
                    ShowChangeAmountInInventoryMenu();
                    break;
                case '4':
                    ShowRegisterNewCustomerMenu();
                    break;
                case '5':
                    ShowCreateNewOrderMenu();
                    break;
                case '6':
                    ShowChangeOrderMenu();
                    break;
                case '7':
                    ShowListAllOrderMenu();
                    break;
                case '8':
                    ShowCancelOrderMenu();
                    break;
                case '9':
                    TerminateProgram();
                    break;
                default:
                    break;
            }

        }

        public static void ShowChangeProductPriceMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 2. to change the price of a product");
            Console.WriteLine("Write the number of the product which price you want to change: ");
            // MyStore.ListProducts();
            // MyStore.editProduct(Int32.Parse(Console.ReadLine()), 1);
        }

        public static void ShowChangeAmountInInventoryMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 3. to change amount of a product in the inventory");
            Console.WriteLine("Write the number of the product which quantity you want to change: ");
            //MyStore.ListProducts();
            //MyStore.editProduct(Int32.Parse(Console.ReadLine()), 2);
        }

        public static void ShowRegisterNewCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 4. to register a new customer");
            Console.ReadLine();
        }

        public static void ShowCreateNewOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 5. to create a new order for a customer");
            Console.ReadLine();
        }

        public static void ShowChangeOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 6. to change an order");
            Console.ReadLine();
        }

        public static void ShowListAllOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 7. to list all orders by a customer");
            Console.ReadLine();
        }

        public static void ShowCancelOrderMenu()
        {
            Console.Clear();
            Console.WriteLine("You have selected option 8. to cancel an order");
            Console.ReadLine();
        }

        public static void TerminateProgram()
        {
            Console.WriteLine("Thanks for the visit!");
            Console.ReadLine();
        }
    }
}
