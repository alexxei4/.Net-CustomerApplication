using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
/// Name : Alexei Ougriniouk , 000776331
/// Date: Feb 13 2021
/// Purpose: Organizing a customer database
///I, Alexei Ougriniouk, 000776331 certify that this material is my original work. No other person's work has been used without due acknowledgement.
namespace Lab1Csharp
{
    class Program
    {
        /// <summary>
         /// The Display just shows the options available to the user 
        /// </summary>
        public static void Display()
        {
            Console.WriteLine("1) Sort by Customer Name (A-Z)");
            Console.WriteLine("2) Sort by Customer ID (1-9)");
            Console.WriteLine("3) Sort by Product Name (A-Z)");
            Console.WriteLine("4) Sort by Quantity (Highest-Lowest)");
            Console.WriteLine("5) Sort by Total Sales (Highest-Lowest)\n");
            Console.WriteLine("6) Exit\n");

        }

        /// <summary>
        /// This is the read method
        /// it will read the data from the employees.txt files into an array.
        /// 
        /// This will return the employee array
        /// </summary>
        /// <returns>Customer,custname,discount,prodname,custid,salesprice,quantity</returns>
        public static Customer[] Read()
        {
            ///streamreader declaration
            StreamReader s = new StreamReader("customers.txt");
            int lineCount = File.ReadAllLines("customers.txt").Length;

            ///counter for the string loop
            int i = 0;
            string str;

            Customer[] customers = new Customer[100];        /// This is declared for storing the customers ( Assignment said to have it up to 100)

            ///This reads the text files and stores it into the customer array
            while ((str = s.ReadLine()) != null)
            {
                string[] tempArray = str.Split(',');
                //customer name
                string custname = tempArray[0];
                //customer id
                int custid = Convert.ToInt32(tempArray[1]);
                //product name
                string prodname = tempArray[2];
                //sales price
                
                decimal salesprice = Convert.ToDecimal(tempArray[3]);
                //quantity
                int quantity = Convert.ToInt32(tempArray[4]);
                //sales total
                decimal salestotal = Convert.ToDecimal(salesprice) * Convert.ToDecimal(quantity);
                //discount if applicable
                decimal discount;
                if (250 > quantity && quantity > 99)
                {
                     discount = 0.95M;
                }
                if (250 < quantity )
                {
                     discount = 0.875M;
                }
                else {

                     discount = 1M;
                }


                customers[i] = new Customer(custname,custid,prodname,salesprice,quantity,salestotal * discount);
                i++;
            }
            return customers;
        }

        /// <summary>
        /// This is where the Customer Array gets sorted
        /// </summary>
        /// <param name="customers"></param>
        /// <param name="pick"></param>
        /// <returns>customers</returns>
        public static Customer[] sort(Customer[] customers, int pick)
        {
            
            switch (pick)
            {
                // Case 1 is for sorting customer names from A-Z
                case 1:
                    
                    for (int i = 0; i < 14; i++)
                    {
                        Customer x = customers[i];
                        int min = 0;
                        for (int j = i - 1; j >= 0 && min != 1;)
                        {
                            if (customers[j].getCustomerName().CompareTo(x.getCustomerName()) > 0)
                            {
                                customers[j + 1] = customers[j];
                                j--;
                                customers[j + 1] = x;
                            }
                            else
                            {
                                min = 1;
                            }
                        }
                    }
                    break;
                case 2:
                    //Case 2 sorts ID's 1-9
                    for (int i = 0; i < 14; i++)
                    {
                        Customer x = customers[i];
                        int min = 0;
                        for (int j = i - 1; j >= 0 && min != 1;)
                        {
                            if (customers[j].getCustomerID().CompareTo(x.getCustomerID()) > 0)
                            {
                                customers[j + 1] = customers[j];
                                j--;
                                customers[j + 1] = x;
                            }
                            else
                            {
                                min = 1;
                            }
                        }
                    }
                    break;
                case 3:
                    //Case 3 sorts by product name A-Z
                    for (int i = 0; i < 14; i++)
                    {
                        Customer x = customers[i];
                        int min = 0;
                        for (int j = i - 1; j >= 0 && min != 1;)
                        {
                            if (customers[j].getProductName().CompareTo(x.getProductName()) > 0)
                            {
                                customers[j + 1] = customers[j];
                                j--;
                                customers[j + 1] = x;
                            }
                            else
                            {
                                min = 1;
                            }
                        }
                    }
                    break;
                case 4:
                    //Case 4 sorts by quantity High-Low
                    for (int i = 0; i < 14; i++)
                    {
                        Customer x = customers[i];
                        int min = 0;
                        for (int j = i - 1; j >= 0 && min != 1;)
                        {
                            if (customers[j].getQuantity().CompareTo(x.getQuantity()) < 0)
                            {
                                customers[j + 1] = customers[j];
                                j--;
                                customers[j + 1] = x;
                            }
                            else
                            {
                                min = 1;
                            }
                        }
                    }
                    break;
                case 5:
                    //Case 5 sorts by Total Sales High-Low
                    for (int i = 0; i < 14; i++)
                   
                    {
                        Customer x = customers[i];
                        int min = 0;
                        for (int j = i - 1; j >= 0 && min != 1;)
                        {
                            if (customers[j].getsalestotal().CompareTo(x.getsalestotal()) < 0)
                            {
                                customers[j + 1] = customers[j];
                                j--;
                                customers[j + 1] = x;
                            }
                            else
                            {
                                min = 1;
                            }
                        }
                    }
                    break;
            }
            return customers;
        }

        /// <summary>
        /// Main interacts with the user and recieves the values for the decisions to be made
        /// </summary>
        public static void Main (String [] args)
        {
            Customer[] customers = Read();    
            ///Displays the options
            Display();                           
            int pick = 0;
            bool checker = false;
            //Error checking for  invalid input 
            while (!(checker))
            {
                try
                {
                    Console.Write("Enter option: ");
                    pick = int.Parse(Console.ReadLine());
                    checker = true;
                    continue;
                }
                catch (Exception )
                {
                    Console.Clear();
                    Display();
                    //Console is unhappy if you enter invalid input
                    Console.WriteLine("PICK A CHOICE BETWEEN 1-6 >:(");
                }
            }
            
            // This is for formatting the table
            string custname = "Customer Name";
            string custID = "Customer ID";
            string prodname = "Product Name";
            string salesprice = "Sales P.";
            string quantity = "Quantity";
            string salestotal = "Total";
            /// based on what decision is made the sort is returned, after it prompts to make another decision if you want to see more 
            /// sorts or if you just want to exit the system
            switch (pick)
            {
                case 1:

                    customers = sort(customers, pick);
                    Console.Clear();
                
                    Console.WriteLine("CUSTOMER NAME A-Z");

                    Console.Write($"{custname}| {custID}| {prodname}|{salesprice}|{quantity}|{salestotal}\n");
                    Console.Write("----------------------------------------------------------------\n");
                  


                    foreach (Customer c in customers)
                    {
                        if (c != null)
                        {
                            Console.WriteLine($"{c}");
                        }
                        continue;
                    }
                    Console.WriteLine("Enter what you want to do next");
                    pick = int.Parse(Console.ReadLine());
                    if (pick == 1)
                    {
                        goto case 1;
                    }
                    if (pick == 2)
                    {
                        goto case 2;
                    }
                    if (pick == 3)
                    {
                        goto case 3;
                    }
                    if (pick == 4)
                    {
                        goto case 4;
                    }
                    if (pick == 5)
                    {
                        goto case 5;
                    }
                    if (pick == 6)
                    {
                        break;
                    }
                    break;
                



                case 2:

                    customers = sort(customers, pick);
                    Console.Clear();

                    Console.WriteLine("SORT BY ID 1-9");

                    Console.Write($"{custname}| {custID}| {prodname}|{salesprice}|{quantity}|{salestotal}\n");
                    Console.Write("----------------------------------------------------------------\n");
                    foreach (Customer c in customers)
                    {
                        if (c != null)
                        {
                            Console.WriteLine(c);
                        }
                    }
                    Console.WriteLine("Enter what you want to do next");
                    pick = int.Parse(Console.ReadLine());
                    if (pick == 1)
                    {
                        goto case 1;
                    }
                    if (pick == 2)
                    {
                        goto case 2;
                    }
                    if (pick == 3)
                    {
                        goto case 3;
                    }
                    if (pick == 4)
                    {
                        goto case 4;
                    }
                    if (pick == 5)
                    {
                        goto case 5;
                    }
                    if (pick == 6)
                    {
                        break;
                    }
                    break;
                case 3:

                    customers = sort(customers, pick);
                    Console.Clear();

                    Console.WriteLine("SORT BY PRODUCT NAME A-Z");

                    Console.Write($"{custname}| {custID}| {prodname}|{salesprice}|{quantity}|{salestotal}\n");
                    Console.Write("----------------------------------------------------------------\n");
                    foreach (Customer c in customers)
                    {
                        if (c != null)
                        {
                            Console.WriteLine(c);
                        }
                    }

                    Console.WriteLine("Enter what you want to do next");
                    pick = int.Parse(Console.ReadLine());
                    if (pick == 1)
                    {
                        goto case 1;
                    }
                    if (pick == 2)
                    {
                        goto case 2;
                    }
                    if (pick == 3)
                    {
                        goto case 3;
                    }
                    if (pick == 4)
                    {
                        goto case 4;
                    }
                    if (pick == 5)
                    {
                        goto case 5;
                    }
                    if (pick == 6)
                    {
                        break;
                    }
                    break;
                case 4:

                    customers = sort(customers, pick);
                    Console.Clear();

                    Console.WriteLine("SORT BY QUANTITY HIGH-LOW");

                    Console.Write($"{custname}| {custID}| {prodname}|{salesprice}|{quantity}|{salestotal}\n");
                    Console.Write("----------------------------------------------------------------\n");
                    foreach (Customer c in customers)
                    {
                        if (c != null)
                        {
                            Console.WriteLine(c);
                        }
                    }

                    Console.WriteLine("Enter what you want to do next");
                    pick = int.Parse(Console.ReadLine());
                    if (pick == 1)
                    {
                        goto case 1;
                    }
                    if (pick == 2)
                    {
                        goto case 2;
                    }
                    if (pick == 3)
                    {
                        goto case 3;
                    }
                    if (pick == 4)
                    {
                        goto case 4;
                    }
                    if (pick == 5)
                    {
                        goto case 5;
                    }
                    if (pick == 6)
                    {
                        break;
                    }
                    break;
                case 5:

                    customers = sort(customers, pick);
                    Console.Clear();

                    Console.WriteLine("SORT BY SALES HIGH-LOW");

                    Console.Write($"{custname}| {custID}| {prodname}|{salesprice}|{quantity}|{salestotal}\n");
                    Console.Write("----------------------------------------------------------------\n");

                    foreach (Customer c in customers)
                    {
                        if (c != null)
                        {
                            Console.WriteLine(c);
                        }
                    }
                    Console.WriteLine("Enter what you want to do next");
                    pick = int.Parse(Console.ReadLine());
                    if (pick == 1)
                    {
                        goto case 1;
                    }
                    if (pick == 2)
                    {
                        goto case 2;
                    }
                    if (pick == 3)
                    {
                        goto case 3;
                    }
                    if (pick == 4)
                    {
                        goto case 4;
                    }
                    if (pick == 5)
                    {
                        goto case 5;
                    }
                    if (pick == 6)
                    {
                        break;
                    }
                    break;
                case 6:
                    break;

            }


        }
     
    }
}
