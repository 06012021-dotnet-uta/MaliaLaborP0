using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Project0DbContext;


namespace Project0BusinessLogic
{
    public class CustomerMethods : ICustomerMethods
    {
        private Project0DBContext _context;
        private Customer _currentCustomer;
        private Store _currentStore;

        /// <summary>
        /// Constructor for CustomerMethods class.
        /// </summary>
        public CustomerMethods()
        {
            this._context = new Project0DBContext();
            this._currentCustomer = new Customer();
            this._currentStore = new Store();
        }

        /// <summary>
        /// Returns current customer that is using program.
        /// </summary>
        /// <returns>Customer object that is using program</returns>
        public Customer GetCurrentCustomer()
        {
            return _currentCustomer;
        }

        /// <summary>
        /// Returns current store that orders will be made to.
        /// </summary>
        /// <returns>Store object that new orders will be made to.</returns>
        public Store GetCurrentStore()
        {
            return _currentStore;
        }

        /// <summary>
        /// Searches for and returns store from store databse table with given location name.
        /// </summary>
        /// <param name="locationName">Name of state store is located in</param>
        /// <returns>Store object with matching location name. Returns null if store not found.</returns>
        public Store SearchStoreByLocation(string locationName)
        {
            Store store;
            try
            {
                store = _context.Stores.Where(x => x.StoreLocation.ToLower() == locationName.ToLower()).First();
            }
            catch (Exception)
            {
                return null;
            }
            return store;
        }

        /// <summary>
        /// Search for and return customer with matching name from customer database table.
        /// </summary>
        /// <param name="name">Name of customer to search for. Either first and last name separated by a space character OR last name only (will return first result if many exist.)</param>
        /// <returns>Customer object that matches either both first and last name, OR first match with same last name only.</returns>
        public Customer SearchCustomer(string name)
        {
            Customer customer;
            if (name.Contains(' '))
            {
                //split string on space
                string[] names = name.Split(' ');
                // make a list of customers with matching last name
                List<Customer> lastNames = _context.Customers.Where(x => x.LastName.ToLower() == names[1].ToLower()).ToList();
                // search list of matches for match with first name
                customer = _context.Customers.Where(x => x.FirstName == names[0].ToLower()).FirstOrDefault();
            }
            else
            {
                customer = _context.Customers.Where(x => x.LastName.ToLower() == name.ToLower()).FirstOrDefault();
            }
            return customer;
        }// end SearchCustomer(string)

        /// <summary>
        /// Searches for and returns customer with matching ID from customer database table.
        /// </summary>
        /// <param name="id">Customer ID to search in database.</param>
        /// <returns>Customer object with matching customer ID. Returns null if none found</returns>
        public Customer SearchCustomer(int id)
        {
            Customer customer;
            customer = _context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            return customer;
        }

        /// <summary>
        /// Attempts to add a new customer to the database, returns false if fails.
        /// </summary>
        /// <param name="firstName">First name of new customer</param>
        /// <param name="lastName">Last name of new customer</param>
        /// <param name="store">(Optional) Store location name of prefered store.</param>
        /// <returns>Boolean that reflects the success of adding a new customer. (True if success)</returns>
        public bool AddCustomer(string firstName, string lastName, string store = "")
        {
            bool isSuccess = true;
            try
            {
                if (store == "")
                {
                    var cust = new Customer()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                    };
                    _context.Entry(cust).State = EntityState.Added;
                    //_context.Add(cust); instead of ^
                    _context.SaveChanges();
                }
                else
                {
                    Store tempStore = SearchStoreByLocation(store);
                    if (tempStore != null)
                    {
                        var cust = new Customer()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Store = tempStore
                        };
                        _context.Entry(cust).State = EntityState.Added;
                        _context.SaveChanges();
                    }
                    else
                    {
                        isSuccess = false;
                    }
                }
            }
            catch (Exception)
            {

                isSuccess = false;
            }
            return isSuccess;
        } // end AddCustomer

        /// <summary>
        /// Sets customer that will be purchasing order. Returns false if fails.
        /// </summary>
        /// <param name="customerId">ID of customer to change current customer to.</param>
        /// <returns>Boolean reflecting success of setting current customer. (True if success)</returns>
        public bool SetCurrentCustomer(int customerId)
        {
            bool isSuccess = false;
            _currentCustomer = null;
            _currentCustomer = _context.Customers.Where(x => x.CustomerId == customerId).First();
            if (_currentCustomer != null)
                isSuccess = true;
            else
                isSuccess = false;
            return isSuccess;
        }

        /// <summary>
        /// Sets store that order will be purchased from. Returns false if fails.
        /// </summary>
        /// <param name="storeId">ID of store to change current store to</param>
        /// <returns>Boolean reflecting success of setting current customer. (True if success)</returns>
        public bool SetCurrentStore(int storeId)
        {
            bool isSuccess;
            _currentStore = _context.Stores.Where(x => x.StoreId == storeId).First();
            if (_currentStore != null)
                isSuccess = true;
            else
                isSuccess = false;
            return isSuccess;
        }
    }// end of class
}
