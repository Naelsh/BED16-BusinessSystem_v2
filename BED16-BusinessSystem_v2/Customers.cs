using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void ChangeCustomer(CustomerDatabase<Customer> customerDB)
        {
            Console.WriteLine("Which customer do you want to edit? Enter customerID");
            List<string> allowedInputs = new List<string>();
            for (int customerNumber = 1; customerNumber <= Customer.customerNumberCount; customerNumber++)
            {
                allowedInputs.Add(customerNumber.ToString());
            }

            int customerID = 0;
            bool isProperIntInput = false;
            do
            {
                try
                {
                    customerID = Int32.Parse(Menu.CheckIfProperUserInput(allowedInputs));
                    isProperIntInput = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Make sure the input consists of a valid number without decimals");
                    Debug.WriteLine("Error when new list number of a Product was entered " + e.Message);
                }
            } while (!isProperIntInput);

            // only view the customer asked for
            Console.Clear();
            Console.WriteLine(this.GetCustomer(customerID).ToString());

            bool wantToEditProperty = false;
            do
            {

            
                // ask for property to be changed
                Console.WriteLine("Which property do you want to change?"
                                    +"\n 1. First Name"
                                    +"\n 2. Last Name"
                                    +"\n 3. Email");
                allowedInputs.Clear();
                for (int allowedNumber = 1; allowedNumber <= 3; allowedNumber++)
                {
                    allowedInputs.Add(allowedNumber.ToString());
                }

                isProperIntInput = false;
                int menuOption = 1;
                do
                {
                    try
                    {
                        menuOption = Int32.Parse(Menu.CheckIfProperUserInput(allowedInputs));
                        isProperIntInput = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Make sure the input consists of a valid number without decimals");
                        Debug.WriteLine("Error when new list number of a Product was entered " + e.Message);
                    }
                } while (!isProperIntInput);

                // get the new value for the property
                Console.WriteLine("What is the new value you want to replace the old one with?");
                allowedInputs.Clear();
                string newInputValue = Menu.CheckIfProperUserInput(allowedInputs);

                // depending on which entry change the corresponding property.
                switch (menuOption)
                {
                    case 1:
                        customerDB.GetCustomer(customerID).FirstName = newInputValue;
                        break;
                    case 2:
                        customerDB.GetCustomer(customerID).LastName = newInputValue;
                        break;
                    case 3:
                        customerDB.GetCustomer(customerID).Email = newInputValue;
                        break;
                    default:
                        break;
                }

                // ask if another property should be edited
                wantToEditProperty = Menu.CheckIfUserWantToContinue();
            } while (wantToEditProperty);

            // when no further properties are to be edited, list the customer to the user
            Console.Clear();
            Console.WriteLine("The result of your editing is as follows:");
            Console.WriteLine(customerDB.GetCustomer(customerID).ToString());

        }
    }

    // class Customer defines the attributes of a customer
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CustomerID { get; set; }
        public static int customerNumberCount = 0;

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
            return "Customer ID: " + this.CustomerID + " First name: " + this.FirstName + " Last name: " + this.LastName + " Email: " + this.Email;
        }


    }

    
}
