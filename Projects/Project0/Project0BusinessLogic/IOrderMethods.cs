namespace Project0BusinessLogic
{
    public interface IOrderMethods
    {
        bool AddToCart(string productName, int count);
        bool CheckCart(string productName);
        bool CheckInventory(int productId, int storeId, int count);
        void ClearCart();
        int GetItemCountFromCart(string productName);
        int GetProductId(string productName);
        bool IsCartEmpty();
        int PlaceOrder(int storeId, int customerId);
        bool RemoveFromCart(string productName, int count);
        string ViewCart();
    }
}