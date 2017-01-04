using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    class Order
    {

        static int numberOfOrders = 0; // the total number of orders present
        static List<Order> orders = new List<Order>(); // list of all orders in the system

        // basic constructor
        public Order()
        {
            this.OrderNumber = numberOfOrders;
            numberOfOrders++;
            this.IsActive = true;
            this.IsDelivered = false;
            orders.Add(this);
        }

        public static void AddNewOrder(Store<Product> myStore, CustomerDatabase<Customer> myCustomerDB)
        {
            Console.WriteLine("Do you have a customer that you want to create an order to directly? (y/n)");
            List<string> allowedUserInput = new List<string>();
            allowedUserInput.Add("Y");
            allowedUserInput.Add("N");
            string userInput = Menu.CheckIfProperUserInput(allowedUserInput);

            Order newOrder = new Order();

            if (userInput == "Y")
            {
                myCustomerDB.ListCustomers();
                Console.WriteLine("\nChoose one of the customers in the list above");

            }
            else
            {
                
                Console.WriteLine("New order has been created. Order number: " + newOrder.OrderNumber);
            }

            Console.WriteLine("Next step is to add articles to your order. Press any key to continue");
            Console.ReadKey();
            AddProductToOrder(newOrder, myStore);
        }

        private static void AddProductToOrder(Order order, Store<Product> myStore)
        {
            // first list all available products
            Console.Clear();
            Console.WriteLine("-------Current List of Products-------");
            myStore.ListProducts();
            Console.WriteLine("--------------------------------------");

            // ask for which product ID that should be added to the order.
            Console.WriteLine("Which product do you want to add? Enter the row number based on above list");
            int listNumber = 1;
            List<string> allowedInput = new List<string>();
            bool isProperIntInput = false;
            bool wantToAddProduct = true;
            do
            {
                do
                {
                    try
                    {
                        listNumber = Int32.Parse(Menu.CheckIfProperUserInput(allowedInput));
                        isProperIntInput = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Make sure the input consists of a valid number without decimals");
                        Debug.WriteLine("Error when new list number of a Product was entered " + e.Message);
                    }
                } while (!isProperIntInput);
                order.Products.Add(myStore.GetProduct((listNumber - 1)));

                wantToAddProduct = Menu.CheckIfUserWantToContinue();
            } while (wantToAddProduct);
            
        }
            

        // properties
        public bool IsDelivered { get; set; }
        public bool IsActive { get; set; }
        public int OrderNumber { get; private set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return "Order number: " + this.OrderNumber + " Customer: " + this.Customer.ToString();
        }

        // add a product based on product number to the order
        public void AddProductToOrder(Product product)
        {
            this.Products.Add(product);
        }

        // removed the old customer and set it to the new customer
        public void SetCustomerToOrder(Customer customer)
        {
            this.Customer = customer;
        }

        // print out a list of all orders present in the list of orders
        public void ListAllOrders()
        {
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }

        public Order GetOrderFromOrderNumber(int orderNumber)
        {
            foreach (var order in orders)
            {
                if (order.OrderNumber == orderNumber)
                {
                    return order;
                }

            }
            Order tempOrder = new Order();
            return tempOrder; // ugly solution, this creates an empty order if no order was found
        }

        //Cancel a order

        public void CancelOrder()
        {
           
            int orderNrInput=0;
            Console.WriteLine("Please write the order number representing the order you want to cancel: ");
            ListAllOrders();

            List<string> allowedInput = new List<string>();

            bool isProperDoubleInput = false;
           
            do
            {
                try
                {
                    orderNrInput = Int32.Parse(Menu.CheckIfProperUserInput(allowedInput));
                    
                    isProperDoubleInput = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input not eglible, please try again! ");
                    Debug.WriteLine("Error when new price of a Product was entered " + e.Message);
                }
            } while (!isProperDoubleInput);

            bool IsNotOrderNrFound = true;


            //Checks if the given order nr was found

            foreach (var order in orders)
            {
                if (order.OrderNumber == orderNrInput && order.IsActive)
                {
                    order.IsActive = false;
                    Console.WriteLine("Order: " + orderNrInput + " have been canceled!");
                    IsNotOrderNrFound = false;
                }
                
            }

            if (IsNotOrderNrFound)
            {
                Console.WriteLine("No order by given order number was found!");
            }

            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            
            
        }


    }



    }

