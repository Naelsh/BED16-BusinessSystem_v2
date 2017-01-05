using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            Store<Product> myStore = new Store<Product>();
            CustomerDatabase<Customer> myCustomerDB = new CustomerDatabase<Customer>();
            Product produkt1 = new Product("printer", 14, 1000, "PR001");
            myStore.AddProduct(produkt1);
            Order order = new Order();
            Menu.ShowMainMenu(myStore, myCustomerDB);
        }

        static int checkInt(int userInput)
        {
            return userInput;
        }

        static void setUpTestData(Store<Product> myStore, CustomerDatabase<Customer> myCustomerDB)
        {
            // set up customers
            List<string> customerSurNames = new List<string>();
            List<string> customerLastNames = new List<string>();
            List<string> customerMail = new List<string>();
            for (int customer = 0; customer < 10; customer++)
            {
                
            }

            // set up products

            // set up orders

        }
    }
}
