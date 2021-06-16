using Microsoft.EntityFrameworkCore;
using Project0DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project0BusinessLogic
{
    public class OrderMethods : IOrderMethods
    {
        private Project0DBContext _context;
        private CustomerMethods _custMethods;
        private Dictionary<int, int> _shoppingCart = new Dictionary<int, int>(); //.Key is product ID and .Value is count

        /// <summary>
        /// Constructor for OrderMethods class.
        /// </summary>
        public OrderMethods()
        {
            this._context = new Project0DBContext();
            this._custMethods = new CustomerMethods();
        }

        /// <summary>
        /// Searches Product database for product with given name and returns ID of product if valid or 0 if not found.
        /// </summary>
        /// <param name="productName">Name of product to search for.</param>
        /// <returns>ID of product with given name, or 0 if no result is found.</returns>
        public int GetProductId(string productName)
        {
            int id = 0;
            try
            {
                Product temp = _context.Products.Where(x => x.ProductName.ToLower() == productName.ToLower()).First();
                if (temp != null)
                    id = temp.ProductId;
            }
            catch (Exception)
            {
                id = 0;
            }
            return id;
        }

        /// <summary>
        /// Checks shopping cart count and returns true if empty.
        /// </summary>
        /// <returns>Boolean reflecting if cart is empty. (True if empty.)</returns>
        public bool IsCartEmpty()
        {
            if (_shoppingCart.Count == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Attempts to add a product with a given name and count to shopping cart.
        /// </summary>
        /// <param name="productName">Name of product to add to shopping cart.</param>
        /// <param name="count">Number of desired products to add to shopping cart.</param>
        /// <returns>Boolean reflecting success of adding to shopping cart. (True if success)</returns>
        public bool AddToCart(string productName, int count)
        {
            bool isSuccess = false;
            Product product = _context.Products.Where(x => x.ProductName.ToLower() == productName.ToLower()).First();
            if (product != null)
            {
                // add product ids and counts to cart
                if (_shoppingCart.ContainsKey(product.ProductId))
                    _shoppingCart[product.ProductId] += count;
                else
                    _shoppingCart[product.ProductId] = count;
                // find listing in cart and check inventory for updated count
                var item = _shoppingCart.Where(x => x.Key == product.ProductId).First();
                isSuccess = CheckInventory(item.Key, _custMethods.GetCurrentStore().StoreId, item.Value);
            }
            return isSuccess;
        }

        /// <summary>
        /// Attempts to remove a product with a given name and count from the shopping cart.
        /// </summary>
        /// <param name="productName">Name of product to remove from shopping cart</param>
        /// <param name="count">Number of products wished to be removed from shopping cart.</param>
        /// <returns>Boolean reflecting the success of removing the products. (True if success.)</returns>
        public bool RemoveFromCart(string productName, int count)
        {
            bool isSuccess = false;
            Product product = _context.Products.Where(x => x.ProductName.ToLower() == productName.ToLower()).First();
            if (product != null)
            {
                // if the product is in the cart and count to remove is less than or equal to count in cart
                if (_shoppingCart.ContainsKey(product.ProductId) && _shoppingCart.Where(x => x.Key == product.ProductId).First().Value >= count)
                {
                    _shoppingCart[product.ProductId] -= count;
                    isSuccess = true;
                }
            }
            return isSuccess;
        }

        /// <summary>
        /// Clears Dictionary containing product ID's and counts.
        /// </summary>
        public void ClearCart()
        {
            _shoppingCart.Clear();
        }

        /// <summary>
        /// Loops through shopping cart and adds product details to a returned string.
        /// </summary>
        /// <returns>String containing details about shopping cart.</returns>
        public string ViewCart()
        {
            string returnString = "Shopping Cart:";
            decimal total = 0;
            decimal lineTotal = 0;
            foreach (var item in _shoppingCart)
            {
                var tempProduct = _context.Products.Where(x => x.ProductId == item.Key).First();
                lineTotal = tempProduct.Price * item.Value;
                returnString += $"\n{tempProduct.ProductName}: \t\tCount: {item.Value} \tTotal: {lineTotal}";
                total += (tempProduct.Price * item.Value);
            }
            returnString += $"\nTotal: {total}";
            if (total == 0)
                returnString = "Shopping cart is empty.";
            return returnString;
        }

        /// <summary>
        /// Checks inventories table for count of products and returns boolean reflecting if enough stock is present.
        /// </summary>
        /// <param name="productId">ID of product to search for.</param>
        /// <param name="storeId">ID of store to check inventory.</param>
        /// <param name="count">Number of desired products.</param>
        /// <returns>Boolean reflecting if enough stock is present. (True if store has enough products)</returns>
        public bool CheckInventory(int productId, int storeId, int count)
        {
            try
            {
                var product = _context.Inventories.Where(x => x.StoreId == storeId && x.ProductId == productId).First();
                if (product.ProductCount >= count)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Loops through shopping cart and looks for product with given name and returns boolean if true or false.
        /// </summary>
        /// <param name="productName">Name of product to search shopping cart for.</param>
        /// <returns>Boolean reflecting if product exists in shopping cart. (True if in cart.)</returns>
        public bool CheckCart(string productName)
        {
            bool inCart = false;
            foreach (var item in _shoppingCart)
            {
                int id = GetProductId(productName);
                if (item.Key == id && id != 0)
                {
                    inCart = true;
                    break;
                }
            }
            return inCart;
        }

        /// <summary>
        /// Loops through shopping cart and returns number of products with a given name are present.
        /// </summary>
        /// <param name="productName">Name of product to search shopping cart for.</param>
        /// <returns>Number of products with given name in shopping cart, returns 0 if not in cart.</returns>
        public int GetItemCountFromCart(string productName)
        {
            int id = GetProductId(productName);
            foreach (var item in _shoppingCart)
            {
                if (item.Key == id && id != 0)
                    return item.Value;
            }
            return 0;
        }

        /// <summary>
        /// Commits shopping cart to database entries and returns ID of order just created.
        /// </summary>
        /// <returns>ID of order that was just created.</returns>
        public int PlaceOrder(int storeId, int customerId) // change this, make a variable inside class
        {
            int returnId = 1;
            if (_shoppingCart.Count == 0)
                returnId = 0;
            else // cart is not empty
            {
                try
                {
                    // loop though product id dict for inventory check
                    foreach (var id in _shoppingCart)
                    {
                        // search product for match
                        Product product = _context.Products.Where(x => x.ProductId == id.Key).First(); //check null
                        if (!CheckInventory(id.Key, storeId, id.Value) || product == null) // not enough stock or product 
                        {
                            returnId = 0;
                            break;
                        }
                    }

                    // all checks clear, create new rows in tables
                    if (returnId != 0)
                    {
                        // create order
                        Order newOrder = new Order()
                        {
                            StoreId = storeId
                        };
                        _context.Orders.Add(newOrder);
                        _context.SaveChanges();
                        returnId = newOrder.OrderId;
                        // create orderlines
                        foreach (var id in _shoppingCart)
                        {
                            OrderLine newLine = new OrderLine()
                            {
                                ProductId = id.Key,
                                ProductCount = id.Value,
                                OrderId = returnId
                            };
                            _context.OrderLines.Add(newLine);
                            // search inventories list to find matching store and product id
                            var inventoriesList = _context.Inventories.Where(x => x.ProductId == id.Key).ToList();
                            foreach (var item in inventoriesList)
                            {
                                if (item.StoreId == storeId)
                                {
                                    // update product count in inventory
                                    item.ProductCount -= id.Value;
                                    _context.Inventories.Update(item);
                                }
                            }
                        }
                        _context.SaveChanges();

                        // create orderhistory
                        OrderHistory newHistory = new OrderHistory()
                        {
                            CustomerId = customerId,
                            OrderId = returnId,
                        };
                        _context.Add(newHistory);
                        _shoppingCart.Clear();
                        _context.SaveChanges();
                    }
                } // end try
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Source} {e.Message}");
                    returnId = 0;
                }
            } // end else
            return returnId;
        } // end PlaceOrder
    }// end of class
}
