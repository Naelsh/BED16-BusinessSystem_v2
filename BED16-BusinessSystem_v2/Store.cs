using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
                    Console.WriteLine("Sorry the warehouse is full, unable to add additional products!");


                }

            }



        }

        public Product GetProduct(int listNr)
        {
            return wareHouse[listNr];
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
            bool isNotProductChanged = true;

            foreach (T product in wareHouse)
            {


                if (priceOrQuantity == 1 && increment == listNr - 1 && wareHouse[increment]!=null)
                {
                    List<string> allowedInput = new List<string>();

                    bool isProperDoubleInput = false;
                    Console.WriteLine("Please write the new Price");
                    do
                    {
                        try
                        {
                            product.Price = Double.Parse(Menu.CheckIfProperUserInput(allowedInput));
                            isProperDoubleInput = true;
                            isNotProductChanged = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Make sure the price consists of a valid number");
                            Debug.WriteLine("Error when new price of a Product was entered " + e.Message);
                        }
                    } while (!isProperDoubleInput);
                    Console.WriteLine("Product price has been changed!");

                }

                if (priceOrQuantity == 2 && increment == listNr - 1 && wareHouse[increment] != null)
                {
                    List<string> allowedInput = new List<string>();

                    bool isProperIntInput = false;
                    Console.WriteLine("Please write the new Quantity");
                    do
                    {
                        try
                        {
                            product.Quantity = Int32.Parse(Menu.CheckIfProperUserInput(allowedInput));
                            isProperIntInput = true;
                            isNotProductChanged = false;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Make sure the quantity consists of a valid number without decimals");
                            Debug.WriteLine("Error when new quantity of a Product was entered " + e.Message);
                        }
                    } while (!isProperIntInput);
                    Console.WriteLine("Product quantity has been changed!");
                    
                }

                increment++;
            }

            if (isNotProductChanged)
            {
                Console.WriteLine("No Product by that number, Please try again!");
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
                if (wareHouse[i] != null && wareHouse[i].ProductID == artnr)
                {
                    Console.WriteLine(wareHouse[i].ProductID);
                    noOfProductsInInventory = wareHouse[i].Quantity;
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
                    pricelist.Add(wareHouse[i].Price);
                }
                else
                {
                }
            }
        }
    }


}
