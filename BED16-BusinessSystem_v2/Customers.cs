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
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public Customer(string firstname, string lastname, string email)
        {
            this.firstName = firstname;
            this.lastName = lastname;
            this.email = email;
        }

        // handels return of various data of the customer
        public override string ToString()
        {
            return "First name: " + firstName + " Last name: " + lastName + " Email: " + email;
        }
    }
}
