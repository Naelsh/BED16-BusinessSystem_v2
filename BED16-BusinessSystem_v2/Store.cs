using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    class Store<T> : IEnumerable where T : Product
    {
        //a variable which helps a

        T[] wareHouse; //warehouse list which stores instances of the productClass class.
        private int count = 100; //variable used for handling the wareHouse list spaces


        public Store()
        {
            wareHouse = new T[100];
        }

        public void AddProduct(T item)
        {
            bool isNotProductAdded = true;



            //If any space in the warehouse List is empty the funktion stores the added product.
            //If no list slot is =null the warehouse is full
            for (int i = 0; i < count; i++)
            {
                if (wareHouse[i] == null)
                {



                    wareHouse[i] = item;

                    i = count;
                    isNotProductAdded = false;
                    Console.WriteLine("You product has been added to the warehouse");

                }

                //If the array is full the following lines are written in the console window.
                if (i == count - 1 && isNotProductAdded)
                {
                    Console.WriteLine("Sorry the warehouse is full, unable to add addtional products!");


                }

            }



        }


        public void ListProducts()
        {

            int increment = 0;
            bool isThereNoProducts = true;

            foreach (T product in wareHouse)
            {

                if (wareHouse[increment] != null)
                {
                    Console.WriteLine((increment + 1) + ". " + product.ToString());

                    Console.WriteLine("----------------------");
                    isThereNoProducts = false;
                }
                increment++;
            }

            //If no Products present in the list.
            if (isThereNoProducts) { Console.WriteLine("No products in stock!"); }
        }


        public void editProduct(int listNr, int priceOrQuantity)
        {
            int increment = 0;
            bool isNotProductChanged = false;

            foreach (T product in wareHouse)
            {
                if (priceOrQuantity == 1 && increment == listNr - 1)
                {
                    Console.WriteLine("Please write the new Price");
                    product.price = Double.Parse(Console.ReadLine());
                    Console.WriteLine("Product price has been changed!");

                    isNotProductChanged = false;
                }

                else if (priceOrQuantity == 2 && increment == listNr - 1)
                {


                    Console.WriteLine("Please write the new Quantity");
                    product.quantity = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Product quantity has been changed!");
                    isNotProductChanged = false;
                }

                increment++;
            }

            if (isNotProductChanged)
            {
                Console.WriteLine("No Product by that Nr, Please try again!");
            }

            Console.WriteLine("Press any key to continue......");
            Console.ReadKey();


        }


        //IEnumerator method for used to enable the foreach loop of the generic list.
        public IEnumerator GetEnumerator()
        {

            for (int i = 0; i < count; i++)
            {

                yield return wareHouse[i];
            }


        }

        public int AmountOfProductInInventory(string artnr)
        {
            int noOfProductsInInventory = 0;
            for (int i = 0; i < wareHouse.Length; i++)
            {
                if (wareHouse[i] != null && wareHouse[i].productID == artnr)
                {
                    Console.WriteLine(wareHouse[i].productID);
                    noOfProductsInInventory = wareHouse[i].quantity;
                }
                else
                {
                }
            }
            return noOfProductsInInventory;
        }

        public void ListProductPrices()
        {
            List<double> pricelist = new List<double>();
            for (int i = 0; i < wareHouse.Length; i++)
            {
                if (wareHouse[i] != null)
                {
                    pricelist.Add(wareHouse[i].price);
                }
                else
                {
                }
            }
        }

        public void ChangeProduct()
        {
            int menuChoice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("*Changing product price or amount in iventory*");
                Console.WriteLine("Enter number"
                                    + "\n1. to enter a product art nr to change"
                                    + "\n2. search for a product to change"
                                    + "\n3. Go back to main menu");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out menuChoice))
                {
                    switch (menuChoice)
                    {
                        case 1:
                            Console.WriteLine("Enter product art nr");
                            string artnr = Console.ReadLine().ToUpper();
                            Console.ReadKey();
                            break;
                        case 2:
                            int noOfProducts = 0;
                            for (int i = 0; i < data.Length; i++)
                            {
                                if (data[i] == null)
                                {
                                }
                                else
                                {
                                    Console.WriteLine("Prod " + i + " " + (data[i].ToString()));
                                    noOfProducts++;
                                }
                            }
                            if (noOfProducts == 0)
                            {
                                Console.WriteLine("No products have been added to your store");
                            }
                            Console.WriteLine("Enter # of the product to change price for or q to go back");
                            int chosenProduct = 0;
                            bool change = false;
                            do
                            {
                                string chosenLine = Console.ReadLine();
                                if (int.TryParse(chosenLine, out chosenProduct) && (chosenProduct < noOfProducts))
                                {
                                    change = true;
                                    Console.WriteLine("Current price of art number is " + data[chosenProduct].Price);
                                    Console.WriteLine("Enter new price");
                                    float price = 0;
                                    do
                                    {
                                        string enteredPrice = Console.ReadLine();
                                        if (float.TryParse(enteredPrice, out price))
                                        {
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter price in numbers");
                                        }
                                    }
                                    while (price <= 0);
                                    data[chosenProduct].Price = price;
                                    Console.WriteLine("The price has been updated");
                                }
                                else if (chosenLine == "q")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter # of product to change or q to go back");
                                }
                            }
                            while (change == false);
                            Console.ReadKey();
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Enter a number between 1 and 3");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please, enter a number");
                    Console.ReadKey();
                }
            }
            while (menuChoice != 3);
        }
    }


}
}
