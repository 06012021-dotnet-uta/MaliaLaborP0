using Microsoft.EntityFrameworkCore;
using Project0BusinessLogic;
using Project0DbContext;
using System;
using System.Linq;
using Xunit;

namespace Project0Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestPassSearchCustomerByName()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            string customerName = "Doug Dimmadome";
            int expected = 2;
            Customer result;

            // act
            result = customerMethods.SearchCustomer(customerName);

            // assert
            Assert.Equal(expected, result.CustomerId);
        }

        [Fact]
        public void TestFailSearchCustomerByName()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            string customerName = "Real fake name";
            Customer result;

            // act
            result = customerMethods.SearchCustomer(customerName);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void TestPassSearchCustomerByID()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            int customerId = 1;
            string expected = "Malia";
            Customer result;

            // act
            result = customerMethods.SearchCustomer(customerId);

            // assert
            Assert.Equal(expected, result.FirstName);
        }

        [Fact]
        public void TestFailSearchCustomerByID()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            int customerId = 100;
            Customer result;

            // act
            result = customerMethods.SearchCustomer(customerId);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void TestPassSearchStore()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            string storeName = "Arizona";
            Store result;

            //act
            result = customerMethods.SearchStoreByLocation(storeName);

            // assert
            Assert.NotNull(result);
        }

        [Fact]
        public void TestFailSearchStore()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            string storeName = "New New York";
            Store result;

            //act
            result = customerMethods.SearchStoreByLocation(storeName);

            // assert
            Assert.Null(result);
        }

        [Fact]
        public void TestPassSetCurrentCustomer()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            int customerId = 1;
            bool result;

            //act
            result = customerMethods.SetCurrentCustomer(customerId);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void TestPassSetCurrentStore()
        {
            // arrange
            CustomerMethods customerMethods = new CustomerMethods();
            int storeId = 1;
            bool result;

            //act
            result = customerMethods.SetCurrentStore(storeId);

            // assert
            Assert.True(result);
        }

        [Fact]
        public void TestPassGetProductId()
        {
            // arrange
            OrderMethods orderMethods = new OrderMethods();
            string name = "Hammer";
            int result;
            int expected = 1;

            //act
            result = orderMethods.GetProductId(name);

            // assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestPassIsCartEmpty()
        {
            // arrange
            OrderMethods orderMethods = new OrderMethods();
            bool result;

            //act
            result = orderMethods.IsCartEmpty();

            // assert
            Assert.True(result);
        }
    }
}
