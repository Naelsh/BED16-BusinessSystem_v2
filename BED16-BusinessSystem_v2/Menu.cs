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



        public static void ShowMainMenu(Store<Product> myStore, CustomerDatabase<Customer> myCustomerDB)
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

            Console.Clear();
            switch (itemSelection)
            {
                case '1':
                    // creates a new product
                    bool wantToCreateProducts = true;
                    do
                    {
                        Product newProduct = Product.userInput();
                        wantToCreateProducts = CheckIfUserWantToContinue();
                    } while (wantToCreateProducts);
                    ShowMainMenu(myStore, myCustomerDB);
                    break;
                case '2':
                    // Show Change Product Price
                    
                    break;
                case '3':
                    // Show Change Amount In Inventory
                    break;
                case '4':
                    // Show Register New Customer
                    break;
                case '5':
                    // Show Create New Order
                    break;
                case '6':
                    // Show Change Order
                    break;
                case '7':
                    // Show List All Order
                    break;
                case '8':
                    // Show Cancel Order
                    break;
                case '9':
                    // TerminateProgram
                    Console.WriteLine("Thank you for your visit! Have a great day");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }

        }

        // make sure the user want to continue
        public static bool CheckIfUserWantToContinue()
        {
            Console.WriteLine("Do you want to do the same process again? (y/n) If 'n' is typed, you will return to" 
                +" the main menu.");
            bool isProperUserInput = false;
            string userInput = "";
            do
            {
                Console.Write("Please write 'y' or 'n' ");
                userInput = Console.ReadLine().ToString().ToUpper();
                isProperUserInput = CheckIfProperUserInput("YN", userInput[0]);
            } while (!isProperUserInput);

            if (userInput[0] == 'Y')
            {
                return true;
            }
            return false;
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

    }
}
