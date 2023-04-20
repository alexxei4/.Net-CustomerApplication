using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// Name : Alexei Ougriniouk , 000776331
/// Date: Feb 13 2021
/// Purpose: Organizing a customer database
///I, Alexei Ougriniouk, 000776331 certify that this material is my original work. No other person's work has been used without due acknowledgement.
namespace Lab1Csharp
{
    // this class is for storing the information for all of the customers
    class Customer
    {
        // all of these variables are intialized to start this program
        private string custname;        
        private int custid;
        private string prodname;  
        private decimal salesprice;       
        private int quantity;       
        private decimal salestotal;

        /// <summary>
        /// Customer is a constructor that is crucial for storing the text information and to calculate the sales total from the text file
        /// as its not given in this file
        /// </summary>
        /// <param name="custname"></param>
        /// <param name="custid"></param>
        /// <param name="prodname"></param>
        /// <param name="salesprice"></param>
        /// /// <param name="quantity"></param>
        /// /// <param name="salestotal"></param>
        public Customer(string custname, int custid, string prodname, decimal salesprice,int quantity,decimal salestotal)
        {
            this.custname = custname;
            this.custid = custid;
            this.prodname = prodname;
            this.salesprice = salesprice;
            this.quantity = quantity;
            this.salestotal = Convert.ToDecimal(salesprice) * Convert.ToDecimal(quantity);

        }

        ///returns the total in sales
        ///Also it calculates a 5% discount or a 12.5% if the qauntity fits the criteria
        ///<returns>Sales Total</returns>
        public decimal getsalestotal()
        {
            if(250 >this.quantity && this.quantity > 99)
            {
                return Convert.ToDecimal(this.salesprice) * Convert.ToDecimal(this.quantity) * 0.95M ;
            }
            if (250 < this.quantity)
            {
                return Convert.ToDecimal(this.salesprice) * Convert.ToDecimal(this.quantity) * 0.875M;
            }

            else 
            {
                return Convert.ToDecimal(this.salesprice) * Convert.ToDecimal(this.quantity);
            }
            
        }

        /// <summary>
        ///  gets quantity
        /// </summary>
        /// <returns>Quantity</returns>
        public int getQuantity()
        {
            return this.quantity;
        }

        /// <summary>
        ///  gets customer name
        /// </summary>
        /// <returns>custname</returns>
        public string getCustomerName()
        {
            return this.custname;
        }
        /// <summary>
        ///  gets product name
        /// </summary>
        /// <returns>prodname</returns>
        public string getProductName()
        {
            return this.prodname;
        }

        /// <summary>
        ///  gets customer id
        /// </summary>
        /// <returns>custid</returns>
        public int getCustomerID()
        {
            return this.custid;
        }

        /// <summary>
        ///  gets sales price
        /// </summary>
        /// <returns>salesprice</returns>
        public decimal getSalesprice()
        {
            return this.salesprice;
        }

        //To String Function
        // this is for formatting the string so it can be organized and read properly 
        public override string ToString()
        {
            return $"{custname},{custid},{prodname},{salesprice}, {quantity} , {salestotal} \n";

        }

        /// <summary>
        /// sets quantity
        /// </summary>
        /// <param name="quantity"></param>
        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        /// <summary>
        /// sets customer name
        /// </summary>
        /// <param name="custname"></param>
        public void setCustomerName(string custname)
        {
            this.custname = custname;
        }
        /// <summary>
        /// sets prod name
        /// </summary>
        /// <param name="prodname"></param>
        public void setProductName(string prodname)
        {
            this.prodname = prodname;
        }

        /// <summary>
        /// sets customer id
        /// </summary>
        /// <param name="custid"></param>
        public void setNumber(int custid)
        {
            this.custid = custid;
        }

        /// <summary>
        /// sets sale prices 
        /// </summary>
        /// <param name="salesprice"></param>
        public void setSalesPrice(decimal salesprice)
        {
            this.salesprice = salesprice;
        }

    }
}
