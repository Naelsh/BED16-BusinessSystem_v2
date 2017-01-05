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

            // setting up testdata
            Product produkt1 = new Product("printer", 14, 1000, "PR001");
            myStore.AddProduct(produkt1);
            setUpTestData(myStore, myCustomerDB);

            Order order = new Order();
            Menu.ShowMainMenu(myStore, myCustomerDB);
        }

        // test method for setting up propper test-data
        public static void setUpTestData(Store<Product> myStore, CustomerDatabase<Customer> myCustomerDB)
        {
            // set up 10 customers
            for (int customer = 0; customer < 10; customer++)
            {
                string customerFristName = "SurName " + customer;
                string customerLastName = "Family Name " + customer;
                string customerMail = "mail" + customer + "@test.com";
                Customer newCustomer = new Customer(customerFristName, customerLastName, customerMail);
                myCustomerDB.AddCustomer(newCustomer);
            }

            // set up products
            for (int product = 0; product < 10; product++)
            {
                string productName = "test object " + product;
                int productQuantity = product;
                double productPrice = 50 * product;
                string productId = "TE" + product;
                Product newProduct = new Product(productName, productQuantity, productPrice, productId);
                myStore.AddProduct(newProduct);
            }

            // set up orders
            for (int order = 0; order < 10; order++)
            {
                Order newOrder = new Order();
                Customer orderCustomer = myCustomerDB.GetCustomer(order % 2);
                newOrder.Customer = orderCustomer;
                Product orderProduct = myStore.GetProduct(order % 2);
                newOrder.Products.Add(orderProduct);
                foreach (Product orderLineProduct in newOrder.Products)
                {
                    orderLineProduct.Quantity = order;
                }
            }

        }
    }
}
