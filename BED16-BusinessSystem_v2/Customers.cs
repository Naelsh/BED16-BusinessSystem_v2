using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BED16_BusinessSystem_v2
{
    // Class customerDatabase is a generic list of Customers
    public class CustomerDatabase<T> : IEnumerable where T : Customer
    {
        // defines the first part of the generic list
        T[] customerData;
        private int count = 1000;

        public CustomerDatabase()
        {
            customerData = new T[1000];
        }

        int Count;
        public void AddToCustomerDB(T item)
        {
            bool nomatch = true;
            int i = 0;

            while (nomatch && i < Count)
            {
                if (customerData[i] == null)
                {
                    nomatch = false;
                    customerData[i] = item;
                }
                i++;
            }

            if (nomatch)
                customerData[Count++] = item;
        }

        public void AddCustomer(T item)
        {
            bool isNotProductAdded = true;

            //If any space in the customerData List is empty the funktion stores the added product.
            //If no list slot is =null the warehouse is full
            for (int i = 0; i < count; i++)
            {
                if (customerData[i] == null)
                {

                    customerData[i] = item;

                    i = count;
                    isNotProductAdded = false;
                    Console.WriteLine("Your customer has been added to the database");

                }

                //If the array is full the following lines are written in the console window.
                if (i == count - 1 && isNotProductAdded)
                {
                    Console.WriteLine("Sorry the database is full, unable to add additional customers!");


                }

            }



        }

        public Customer GetCustomer(int listNr)
        {
            return customerData[listNr];
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return customerData[i];
            }
        }

        // class Customer handles adding a customer do customer DB by user input 
        public Customer AddCustomer()
        {
            List<string> allowedInput = new List<string>(); // everything is allowed, so the list is empty
            Console.WriteLine("*Adding a customer to customer DB*");
            Console.WriteLine("Enter customer first name");
            string firstName = Menu.CheckIfProperUserInput(allowedInput);
            Console.WriteLine("Enter customer last name ");
            string lastName = Menu.CheckIfProperUserInput(allowedInput);
            Console.WriteLine("Enter customer email");
            string email = Menu.CheckIfProperUserInput(allowedInput);

            Customer newcustomer = new Customer(firstName, lastName, email);
            return newcustomer;
        }

        // method to list all customers in Customer DB
        public void ListCustomers()
        {
            int noOfCustomers = 0;
            for (int i = 0; i < customerData.Length; i++)
            {
                if (customerData[i] == null)
                {
                }
                else
                {
                    Console.WriteLine(customerData[i].ToString());
                    noOfCustomers++;
                }
            }
            if (noOfCustomers == 0)
            {
                Console.WriteLine("No customers are registered in customer DB yet");
            }
        }
    }

    // class Customer defines the attributes of a customer
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; set; }
        static int customerNumberCount = 0;

        public Customer(string firstname, string lastname, string email)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            customerNumberCount++;
            this.CustomerID = customerNumberCount;
        }

        // handels return of various data of the customer
        public override string ToString()
        {
            return "Customer ID: " + CustomerID + " First name: " + FirstName + " Last name: " + LastName + " Email: " + Email;
        }
    }
}
