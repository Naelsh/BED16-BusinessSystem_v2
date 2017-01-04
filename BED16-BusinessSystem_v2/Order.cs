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
        // basic constructor
        public Order()
        {
            this.OrderNumber = numberOfOrders;
            numberOfOrders++;
            this.IsActive = true;
            this.IsDelivered = false;
            orders.Add(this);
        }

        // constructor for when you know the customer
        public Order(Customer customer)
        {
            this.Customer = customer;
            this.OrderNumber = numberOfOrders;
            numberOfOrders++;
            this.IsActive = true;
            this.IsDelivered = false;
            orders.Add(this);
        }

        public static void AddNewOrder()
        {
            Console.WriteLine("Do you have a customer that you want to create an order to directly? (y/n)");
            List<string> allowedUserInput = new List<string>();
            allowedUserInput.Add("Y");
            allowedUserInput.Add("N");
            string userInput = Menu.CheckIfProperUserInput(allowedUserInput);
            
            if (userInput == "Y")
            {
                Console.WriteLine("This feature is not yet implemented");
            }
            else
            {
                Order newOrder = new Order();
                Console.WriteLine("New order has been created. Order number: " + newOrder.OrderNumber);
            }
        }

        static int numberOfOrders = 0; // the total number of orders present
        static List<Order> orders = new List<Order>(); // list of all orders in the system

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

