using Project0DbContext;

namespace Project0BusinessLogic
{
    public interface ICustomerMethods
    {
        bool AddCustomer(string firstName, string lastName, string store = "");
        Customer GetCurrentCustomer();
        Store GetCurrentStore();
        Customer SearchCustomer(int id);
        Customer SearchCustomer(string name);
        Store SearchStoreByLocation(string locatioName);
        bool SetCurrentCustomer(int customerId);
        bool SetCurrentStore(int storeId);
    }
}