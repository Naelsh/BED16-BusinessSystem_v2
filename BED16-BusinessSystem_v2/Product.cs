using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    //Product class
    class Product
    {

        public string Type { get; set; }  //variable describing type of product
        public int Quantity { get; set; } //variable describing quantity of product in stock
        public double Price { get; set; } //variable describing the price of the product
        public string ProductID { get; set; }
        static int productIDCount = 0;

        //ProductClass constructor
        public Product()
        { }

        public Product(string userType, int userQuantity, double userPrice, string userProductID)
        {
            this.Type = userType;
            this.Quantity = userQuantity;
            this.Price = userPrice;
            this.ProductID = userProductID;

        }

        public override string ToString()
        {


            return "Type of Product: " + this.Type + "\nQuantity: " + this.Quantity + " Price: " + this.Price +
                 "\nProduct ID#: " + this.ProductID;
        }
        
        public static Product userInput()
        {
            string typeOfProduct, productID = "";
            int productQuantity = 0;
            double productPrice = 0.0;
            List<string> allowedInput = new List<string>();

            Console.WriteLine("Please write what type of product you want to add: ");
            typeOfProduct = Menu.CheckIfProperUserInput(allowedInput);

            Console.WriteLine("How many products you have in store: ");
            bool isProperIntInput = false;
            do
            {
                try
                {
                    productQuantity = Int16.Parse(Menu.CheckIfProperUserInput(allowedInput));
                    isProperIntInput = true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error when number of Products entered " +e.Message);
                }
            } while (!isProperIntInput);

            bool isProperDoubleInput = false;
            Console.WriteLine("What does your product cost: ");
            do
            {
                try
                {
                    productPrice = Double.Parse(Menu.CheckIfProperUserInput(allowedInput));
                    isProperDoubleInput = true;
                    productID = typeOfProduct.Substring(0, 2) + productIDCount.ToString("D2");
                    productIDCount++;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error when number of Products entered " + e.Message);
                }
            } while (!isProperDoubleInput);

            Product userProduct = new Product(typeOfProduct, productQuantity, productPrice, productID);
            
            return userProduct;
        }
    }

}

