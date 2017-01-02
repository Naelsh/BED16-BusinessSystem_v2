using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    //Product class
    class Product
    {

        public string type { get; set; }  //variable describing type of product
        public int quantity { get; set; } //variable describing quantity of product in stock
        public double price { get; set; } //variable describing the price of the product
        public string productID { get; set; }
        static int productIDCount = 0;

        //ProductClass constructor
        public Product()
        { }

        public Product(string userType, int userQuantity, double userPrice, string userProductID)
        {
            this.type = userType;
            this.quantity = userQuantity;
            this.price = userPrice;
            this.productID = userProductID;

        }

        public override string ToString()
        {


            return "Type of Product: " + this.type + "\nQuantity: " + this.quantity + " Price: " + this.price +
                 "\nProduct ID#: " + this.productID;
        }

        
        public static Product userInput()
        {
            string typeOfProduct, productID;
            int productQuantity;
            double productPrice;

            Console.WriteLine("Please write what type of product do you want to add: ");
            typeOfProduct = Console.ReadLine().ToUpper();
            Console.WriteLine("How many products you have in store: ");
            productQuantity = Int16.Parse(Console.ReadLine());
            Console.WriteLine("What does your product cost: ");
            productPrice = Double.Parse(Console.ReadLine());
            productID = typeOfProduct.Substring(0, 2) + productIDCount.ToString("D2");

            Product userProduct = new Product(typeOfProduct, productQuantity, productPrice, productID);


            return userProduct;
        }



    }
}
