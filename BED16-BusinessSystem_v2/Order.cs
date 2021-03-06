﻿using System;
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
        public static List<Order> orders = new List<Order>(); // list of all orders in the system

        // properties
        public bool IsDelivered { get; set; }
        public bool IsActive { get; set; }
        public int OrderNumber { get; private set; }
        public int CustomerID { get; set; }
        public List<Product> Products { get; set; } // list of all products
        // public List<int> quantity { get; set; } // list of all quantities of products. Is in direct correlation to the products list

        // basic constructor
        public Order()
        {
            this.OrderNumber = numberOfOrders;
            numberOfOrders++;
            this.IsActive = true;
            this.IsDelivered = false;
            orders.Add(this);
            this.Products = new List<Product>();
        }

        // A constructor that don´t att any new orders to the list but will make all the methods of the class accessable.
        public Order(string nullOrder)
        {


        }

        public static void AddNewOrder(Store<Product> myStore, CustomerDatabase<Customer> myCustomerDB)
        {
            Console.WriteLine("You will follow a form adding all data in sections. First of is adding a customer. "
                + "Next is adding the products you want in your order. "
                + "The final step is defining how many of each product that should be present on each product-row\n");
            
            Order newOrder = new Order();
            Console.WriteLine("New order has been created. Order number: " + newOrder.OrderNumber);

            
            myCustomerDB.ListCustomers();
            Console.WriteLine("\nChoose one of the customers in the list above by entering the appropriate number");
            int listNumber = 1;
            List<string> allowedInput = new List<string>();
            bool isProperIntInput = false;
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
                    Debug.WriteLine("Error when list number of a Customer was entered " + e.Message);
                }
            } while (!isProperIntInput);
            newOrder.CustomerID = listNumber;
            
    
            Console.WriteLine("Next step is to add articles to your order. Press any key to continue");
            Console.ReadLine();
            AddProductToOrder(newOrder, myStore);

            Console.WriteLine("The next step is to set the amount of each article in your order. Press any key to continue");
            Console.ReadLine();
            AddQuantityForProducts(newOrder);

        }

        // by taking in the order and the current list of all products in the store adding the product to the order
        private static void AddProductToOrder(Order order, Store<Product> myStore)
        {
            // first list all available products
            Console.Clear();
            Console.WriteLine("-------Current List of Products-------");
            myStore.ListProducts();
            Console.WriteLine("--------------------------------------");
            
            int listNumber = 1;
            List<string> allowedInput = new List<string>();
            bool isProperIntInput = false;
            bool wantToAddProduct = true;
            do
            {
                // ask for which product ID that should be added to the order.
                Console.WriteLine("Which product do you want to add? Enter the row number based on above list");
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

                if (myStore.GetProduct(listNumber - 1) != null)
                {
                    Product selectedProduct = myStore.GetProduct((listNumber - 1));
                    selectedProduct.Quantity = 0;
                    order.Products.Add(selectedProduct);
                    Console.WriteLine("The following product has been added to your order:\n" + selectedProduct.ToString());

                }

                else
                { Console.WriteLine("No product by that number, please try again!"); }

                wantToAddProduct = Menu.CheckIfUserWantToContinue();
            } while (wantToAddProduct);
            
        }

        private static void AddQuantityForProducts(Order order)
        {
            foreach (Product product in order.Products)
            {
                Console.WriteLine("For article:\n" + product.ToString());
                Console.WriteLine("Please enter amount to be sold");
                int quantity = 1;
                List<string> allowedInput = new List<string>();
                bool isProperIntInput = false;
                do
                {
                    try
                    {
                        quantity = Int32.Parse(Menu.CheckIfProperUserInput(allowedInput));
                        isProperIntInput = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Make sure the input consists of a valid number without decimals");
                        Debug.WriteLine("Error when list number of a Customer was entered " + e.Message);
                    }
                } while (!isProperIntInput);
                Console.WriteLine("Added: " + quantity + " to the product");
                product.Quantity = quantity;
            }
        }

        public override string ToString()
        {
            string orderProductsString = "";
            foreach (Product product in Products)
            {
                orderProductsString = orderProductsString + "\n\n" + product.ToString();
            }
            string orderStatusString = "";
            if (this.IsActive)
            {
                orderStatusString = "Open";
            }
            if (!this.IsActive)
            {
                orderStatusString = "Canceled";
            }
            return "Order number: " + this.OrderNumber + "\nOrderstatus: " + orderStatusString + "\nCustomer: \n" 
                + this.CustomerID.ToString() + orderProductsString;
        }

        // add a product based on product number to the order
        public void AddProductToOrder(Product product)
        {
            this.Products.Add(product);
        }

        /* Deprecated code
        // removed the old customer and set it to the new customer
        public void SetCustomerToOrder(Customer customer)
        {
            this.Customer = customer;
        }
        */

        // print out a list of all orders present in the list of orders
        public void ListAllOrders()
        {
            int increment = 0;

           
           
            foreach (Order order in orders)
            {


                try
                {

                    Debug.WriteLine(increment);
                    if (orders[increment] != null)
                    {

                        Console.WriteLine("Order Number: " + order.OrderNumber + " Costumer: " + order.CustomerID.ToString());
                        Console.WriteLine("----------------------");

                    }
                }
                catch (Exception e)
                { Debug.WriteLine("error in order " + increment + " : " + e.Message); }
                increment++;

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
                    Debug.WriteLine("Error when trying to cancle order." + e.Message);
                }
            } while (!isProperDoubleInput);

            bool IsNotOrderNrFound = true;


            //Checks if the given order nr was found

            foreach (var order in orders)
            {
                if (order.OrderNumber == orderNrInput && order.IsActive)
                {
                    order.IsActive = false;
                    Console.Clear();
                    Console.WriteLine("Order: " + orderNrInput + " have been canceled, see order specifications below:");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine(order.ToString());
                    IsNotOrderNrFound = false;
                }
                
            }

            if (IsNotOrderNrFound)
            {
                Console.WriteLine("No active order by given order number was found!");
                Console.WriteLine("Please try again!");
            }

            Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
            
            
        }


        public void ChangeOrder(Store<Product> myStore)
        {
            Console.WriteLine("Write the order number representing the order you want to edit: ");
            ListAllOrders();
            int orderNrUserInput=0;
            List<string> allowedInput = new List<string>();

            bool isProperDoubleInput = false;


            //Input which order you want to edit by stating the order nr
            do
            {
                try
                {
                    orderNrUserInput = Int32.Parse(Menu.CheckIfProperUserInput(allowedInput));

                    isProperDoubleInput = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input not eglible, please try again! ");
                    Debug.WriteLine("Error in user input when trying to choose which order to cancle." + e.Message);
                   
                }
            } while (!isProperDoubleInput);




            //Input which feature of the order you want to change

            bool isOrderPickCorrect = false;

            isProperDoubleInput = false;
            foreach (var order in orders)
            {
                if (order.OrderNumber == orderNrUserInput)
                {
                    isOrderPickCorrect = true;
                    //Change products in order
                    //order.IsActive = false;
                    Console.Clear();

                    order.Products.Clear();
                    Console.WriteLine("All products in your order have been deleted, please add new products with the following instructions: ");
                    Console.WriteLine("Chosen order: ");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine(order.ToString());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();





                    AddProductToOrder(order, myStore);


                        Console.Clear();
                        Console.WriteLine("The products in Order " + order.OrderNumber + " have been changed: ");
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine(order.ToString());
                        Console.WriteLine("----------------------------------------------");




                    


                }

            }



            if (!isOrderPickCorrect)
            {
                Console.WriteLine("No order by that number, please try again!");

            }


            Console.WriteLine("Press any key to continue...");


        }


    }



}

