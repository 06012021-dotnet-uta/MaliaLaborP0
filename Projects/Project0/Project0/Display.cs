using Project0DbContext;
using System.Collections.Generic;
using System.Linq;


namespace Project0
{
    class Display
    {
        private Project0DBContext _context;

        public Display()
        {
            this._context = new Project0DBContext();
        }

        /// <summary>
        /// Loops through shopping cart and adds product details to a returned string.
        /// </summary>
        /// <param name="orderId">ID of the order desired to display.</param>
        /// <returns>
        /// String containing order details from each line in the shopping cart.
        /// </returns>
        public string DisplayOrderDetails(int orderId)
        {
            string returnString = "";
            decimal lineTotal, total = 0;
            var orderLines = _context.OrderLines.Where(x => x.OrderId == orderId).ToList();
            returnString += $"Order: {orderId}, Date: {_context.Orders.Where(x => x.OrderId == orderId).First().OrderDate}\n";
            foreach (var line in orderLines)
            {
                Product product = _context.Products.Where(x => x.ProductId == line.ProductId).First();
                lineTotal = line.ProductCount * product.Price;
                total += lineTotal;
                returnString += $"\t{product.ProductName}:\t\tCount: {line.ProductCount}\tLine total: {lineTotal}\n";
            }
            if (orderLines.Count == 0)
                returnString = $"Order for ID {orderId} doesn't exist.";
            else
                returnString += $"Total: {total}\n";
            return returnString;
        }

        /// <summary>
        /// Loops through customer order history and adds details to a returned string.
        /// </summary>
        /// <param name="customerId">ID of customer to get order history for.</param>
        /// <returns>String containing order details for past orders of specified customer.</returns>
        public string DisplayCustomerOrderHistory(int customerId)
        {
            string returnString = "";
            returnString += $"\nOrder History for Customer ID: {customerId}\n";
            List<OrderHistory> orderList = _context.OrderHistories.Where(x => x.CustomerId == customerId).ToList();
            foreach (var order in orderList)
            {
                returnString += DisplayOrderDetails(order.OrderId);
            }
            return returnString;
        }

        /// <summary>
        /// Loops through store order history and adds details to a returned string.
        /// </summary>
        /// <param name="storeId">ID of store to get order history for.</param>
        /// <returns>String containing order details for past orders made from a specified store.</returns>
        public string DisplayStoreOrderHistory(int storeId)
        {
            string returnString = "";
            returnString += $"\nOrder History for Store ID: {storeId}\n";
            List<Order> orderList = _context.Orders.Where(x => x.StoreId == storeId).ToList();
            foreach (var order in orderList)
            {
                returnString += DisplayOrderDetails(order.OrderId);
            }
            return returnString;
        }
    }// end of class
}//end of namespace
