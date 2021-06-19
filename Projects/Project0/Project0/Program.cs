using System;
using ModelsLayer;
using Project0BusinessLogic;


namespace Project0
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            int userSelection;
            bool loginSuccess;
            bool isInt;
            int quit;
            bool storeFound = false;
            CustomerMethods custMethods = new CustomerMethods();
            OrderMethods orderMethods = new OrderMethods();
            Display display = new Display();

            do // quit loop
            {
                Console.WriteLine("Welcome!\nPlease choose a selection:\n1. login \n2. exit program");
                isInt = Int32.TryParse(Console.ReadLine(), out quit);
                if (!isInt)
                    Console.WriteLine("Error, please enter an integer.");
                else if (quit == 2)
                    Console.WriteLine("Goodbye!");
                else if (quit == 1)
                {
                    do // customer login loop
                    {
                        Console.WriteLine("Customer Login: \nEnter customer ID or full name: ");
                        string customerInfo = Console.ReadLine();
                        int tempInt = 0;
                        loginSuccess = false;
                        isInt = Int32.TryParse(customerInfo, out tempInt);

                        if (isInt)
                        {
                            var tempCust = custMethods.SearchCustomer(tempInt);
                            if (tempCust != null)
                                loginSuccess = custMethods.SetCurrentCustomer(tempCust.CustomerId);
                        }
                        else
                        {
                            var tempCust = custMethods.SearchCustomer(customerInfo);
                            if (tempCust != null)
                                loginSuccess = custMethods.SetCurrentCustomer(tempCust.CustomerId);
                        }
                        if (!loginSuccess)
                        {
                            Console.WriteLine("Customer not found, would you like to create a new customer account? y/n");
                            string answer = Console.ReadLine();
                            if (answer.ToLower() == "y")
                            {
                                string fName, lName, store;
                                do
                                {
                                    Console.WriteLine("Enter your first name: ");
                                    fName = Console.ReadLine();
                                } while (fName == null);
                                do
                                {
                                    Console.WriteLine("Enter your last name: ");
                                    lName = Console.ReadLine();
                                } while (lName == null);
                                Console.WriteLine("Enter prefered store, or leave blank to skip: ");
                                store = Console.ReadLine();
                                if (custMethods.AddCustomer(fName, lName, store) == true)
                                {
                                    loginSuccess = custMethods.SetCurrentCustomer((custMethods.SearchCustomer($"{fName} {lName}")).CustomerId);
                                }
                                else
                                {
                                    Console.WriteLine("Error, something went wrong.");
                                }
                            }
                        }
                    } while (!loginSuccess);
                    Console.WriteLine($"Customer found: \nID:{custMethods.GetCurrentCustomer().CustomerId}\tName: {custMethods.GetCurrentCustomer().FirstName} {custMethods.GetCurrentCustomer().LastName}");

                    do // ask for store location if user does not have default
                    {
                        Console.WriteLine("Enter store location state, or leave blank to use default store: ");
                        string storeString = Console.ReadLine();
                        if (storeString == "")
                        {
                            //search default
                            if (custMethods.GetCurrentCustomer().StoreId != null)
                            {
                                storeFound = true;
                                int storeId = (int)custMethods.GetCurrentCustomer().StoreId;
                                custMethods.SetCurrentStore(storeId);
                            }
                            else
                            {
                                Console.WriteLine("No default store on record for current customer, please enter a store name.");
                            }
                        }
                        else
                        {
                            var tempStore = custMethods.SearchStoreByLocation(storeString);
                            if (tempStore != null)
                            {
                                storeFound = true;
                                custMethods.SetCurrentStore(tempStore.StoreId);
                            }
                            else
                            {
                                Console.WriteLine("Error, store not found.");
                            }
                        }
                    } while (!storeFound);
                    Console.WriteLine($"Selected store {custMethods.GetCurrentStore().StoreId}, {custMethods.GetCurrentStore().StoreLocation}");
                    // loop through selection menu
                    do
                    {
                        // ask for selection option
                        Console.WriteLine("Please choose a selection:");
                        var selections = Enum.GetNames(typeof(SelectionChoice));
                        for (int x = 0; x < selections.Length; x++)
                        {
                            Console.WriteLine($"{x + 1}. {selections[x]}");
                        }
                        bool success = Int32.TryParse(Console.ReadLine(), out userSelection);
                        if (success)
                        {
                            switch (userSelection)
                            {
                                case 1: // add product to cart
                                    bool prodExists = false;
                                    string productName;
                                    int count;
                                    do // get user input until a valid product is found
                                    {
                                        Console.WriteLine("Enter the name of the product you wish to add:");
                                        productName = Console.ReadLine();
                                        int productId = orderMethods.GetProductId(productName);
                                        if (productId != 0)
                                            prodExists = true;
                                        else
                                            Console.WriteLine("Product not found, please try again.");
                                    } while (!prodExists);
                                    do // get user input until valid number is entered
                                    {
                                        Console.WriteLine("Enter how many you wish to add: ");
                                        isInt = Int32.TryParse(Console.ReadLine(), out count);
                                        if (!isInt)
                                            Console.WriteLine("Error: please enter a number.");
                                        else if (count <= 0)
                                        {
                                            isInt = false;
                                            Console.WriteLine("Please enter a number greater than 0.");
                                        }
                                    } while (!isInt);
                                    orderMethods.AddToCart(productName, count);
                                    break;
                                case 2: // remove product from cart
                                    bool inCart = false;
                                    int removeCount, cartCount;
                                    if (orderMethods.IsCartEmpty())
                                    {
                                        Console.WriteLine("Shopping cart is empty, please add some products and try again.");
                                        break;
                                    }
                                    do // get user input until a product that exists in the cart is entered
                                    {
                                        Console.WriteLine("Enter the name of the product you wish to remove:");
                                        productName = Console.ReadLine();
                                        // check if product is in cart
                                        if (orderMethods.CheckCart(productName))
                                            inCart = true;
                                        else
                                            Console.WriteLine("Product not found in cart, please try again.");
                                    } while (!inCart);
                                    // get count of items in cart
                                    cartCount = orderMethods.GetItemCountFromCart(productName);
                                    do // get user input until valid number is entered
                                    {
                                        Console.WriteLine($"Enter how many you wish to remove ({cartCount} in cart): ");
                                        isInt = Int32.TryParse(Console.ReadLine(), out removeCount);
                                        if (removeCount > cartCount)
                                            Console.WriteLine("Remove amount is greater than amount in cart.");
                                        if (removeCount <= 0)
                                            Console.WriteLine("Please enter a number greater than 0");
                                    } while (!isInt && removeCount > cartCount && removeCount <= 0);
                                    orderMethods.RemoveFromCart(productName, removeCount);
                                    break;
                                case 3: // view itemized list of cart
                                    Console.WriteLine(orderMethods.ViewCart());
                                    break;
                                case 4: // view cart list and submit changes to inventory
                                    if (orderMethods.IsCartEmpty())
                                    {
                                        Console.WriteLine("Shopping cart is empty, add some items then try again.");
                                    }
                                    else
                                    {
                                        int id = orderMethods.PlaceOrder(custMethods.GetCurrentStore().StoreId , custMethods.GetCurrentCustomer().CustomerId);
                                        if (id == 0)
                                            Console.WriteLine("Something went wrong in the order.");
                                        else
                                            Console.WriteLine(display.DisplayOrderDetails(id));
                                    }
                                    break;
                                case 5: // clear cart
                                    orderMethods.ClearCart();
                                    Console.WriteLine("Items removed from cart"); ;
                                    break;
                                case 6: // order histrory
                                    Console.WriteLine(display.DisplayCustomerOrderHistory(custMethods.GetCurrentCustomer().CustomerId));
                                    break;
                                case 7: // change store 
                                    storeFound = false;
                                    do
                                    {
                                        Console.WriteLine("Enter store location state:");
                                        string storeString = Console.ReadLine();
                                        var tempStore = custMethods.SearchStoreByLocation(storeString);
                                        if (tempStore != null)
                                        {
                                            storeFound = true;
                                            custMethods.SetCurrentStore(tempStore.StoreId);
                                            Console.WriteLine($"Store set to {tempStore.StoreLocation}");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error, store not found.");
                                        }
                                    } while (!storeFound);
                                    break;
                                case 8: // store history
                                    Console.WriteLine(display.DisplayStoreOrderHistory(custMethods.GetCurrentStore().StoreId));
                                    break;
                                case 9: // stop loop and logout
                                    break;
                                default: // unrecognized input, try again
                                    Console.WriteLine("Unrecognized input, please try again.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error, please enter a number.");
                        }
                    } while (userSelection != 9);
                } //end else if statement
                else
                {
                    Console.WriteLine("Integer not in range, please try again.");
                }
            } while (quit != 2);
        }// end of main
    }// end of class
}// end ofnamespace
