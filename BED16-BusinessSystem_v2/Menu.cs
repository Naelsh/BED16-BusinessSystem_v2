using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                                + "\n1. Product - Add a product to the store"
                                + "\n2. Product - Change the price of a product"
                                + "\n3. Product - Change amount of a product in the inventory"
                                + "\n4. Customer - Register a new customer"
                                + "\n5. Order - Create a new order for a customer"
                                + "\n6. Order - Change an order"
                                + "\n7. Order - List all orders by a customer"
                                + "\n8. Order - Cancel an order"
                                + "\n9. to quit");

            Console.Write("Select an option by entering the corresponding menu number ");
            List <string> allowedUserInput= new List<string>();
            for (int menuRow = 1; menuRow <= 9; menuRow++)
            {
                allowedUserInput.Add(menuRow.ToString());
            }
            string userInput = CheckIfProperUserInput(allowedUserInput);

            Console.Clear();
            switch (userInput)
            {
                case "1":
                    // creates a new product
                    bool wantToCreateProducts = true;
                    do
                    {
                        Product newProduct = Product.userInput(); // creates the product
                        myStore.AddProduct(newProduct); // adds product to the store

                        Console.WriteLine("-------Current List of Products-------"); // temporary debugging code
                        myStore.ListProducts(); // temporary debugging code
                        Console.WriteLine("--------------------------------------"); // temporary debugging code
                        
                        wantToCreateProducts = CheckIfUserWantToContinue();
                    } while (wantToCreateProducts);
                    ShowMainMenu(myStore, myCustomerDB);
                    break;

                case "2":
                    // Change price
                    // first list all available products
                    Console.WriteLine("-------Current List of Products-------");
                    myStore.ListProducts();
                    Console.WriteLine("--------------------------------------");
                    // ask for which product ID that should be changed.
                    Console.WriteLine("Which product do you want to change? Enter the full Product ID#");
                    // set up a list of all products present

                    /*
                    List<string> products = new List<string>();
                    foreach (var product in myStore)
                    {
                        products.Add(product.)
                    }
                    string userSpecifiedProductID = CheckIfProperUserInput();
                    */

                    // check if product exist in the store, continue until user enters a correct product
                    // or want to return to main menu
                    // if it does, ask for a new price and update the correct product
                    

                    break;
                case "3":
                    // Show Change Amount In Inventory
                    break;
                case "4":
                    // Show Register New Customer
                    bool wantToCreateCustomer = true;
                    do
                    {
                        Customer newCustomer = myCustomerDB.AddCustomer();
                        myCustomerDB.AddToCustomerDB(newCustomer);

                        Console.WriteLine("-------Current List of Customers-------"); // temporary debugging code
                        myCustomerDB.ListCustomers(); // temporary debugging code
                        Console.WriteLine("---------------------------------------"); // temporary debugging code

                        wantToCreateCustomer = CheckIfUserWantToContinue();
                    } while (wantToCreateCustomer);
                    ShowMainMenu(myStore, myCustomerDB);
                    break;

                case "5":
                    // Show Create New Order
                    bool wantToCreateOrder = true;
                    do
                    {
                        Order.AddNewOrder();
                        wantToCreateProducts = CheckIfUserWantToContinue();
                    } while (wantToCreateOrder);
                    ShowMainMenu(myStore, myCustomerDB);
                    break;
                case "6":
                    // Show Change Order
                    break;
                case "7":
                    // Show List of All Orders based on customer
                    break;
                case "8":
                    // Show Cancel Order
                    break;
                case "9":
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
            Console.WriteLine("Do you want to do the same process again? (y/n) Press 'y' to go again."
                + "If 'n' is typed, you will return to the main menu.");
            List<string> allowedInput = new List<string>();
            allowedInput.Add("Y");
            allowedInput.Add("N");
            string userInput = CheckIfProperUserInput(allowedInput);
            
            if (userInput == "Y")
            {
                return true;
            }
            return false;
        }

        // function for checking viability of user input, only validates on a single character
        public static string CheckIfProperUserInput(List<string> allowedInputs)
        {
            bool hasAtLeastOneCharacter = false;
            bool isProperUserInput = false;
            string userInput;
            if (allowedInputs.Count == 0)
            {
                isProperUserInput = true;
            }
            foreach (var allowdInput in allowedInputs)
            {
                allowdInput.ToUpper();
            }

            do
            {
                userInput = Console.ReadLine().ToString().ToUpper();
                if (userInput.Length > 0)
                {
                    hasAtLeastOneCharacter = true;
                }
                else
                {
                    Console.WriteLine("Input requires at least one character");
                }
                foreach (var allowedInput in allowedInputs)
                {
                    if (allowedInput == userInput)
                    {
                        isProperUserInput = true;
                    }
                }
                if (!isProperUserInput)
                {
                    Console.WriteLine("Input has to match one of the options");
                }
            } while (!hasAtLeastOneCharacter || !isProperUserInput);
            return userInput;
        }

    }
}
