using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Data;
using TilbudsPlatform.core.Entities;
using TilbudsPlatform.core.Services;
using Xunit;

namespace TilbudsPlatform.Tests.IntegrationTests
{
    public class CustomerServiceIntegrationTests
    {
        private TilbudsPlatformContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<TilbudsPlatformContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) 
                .Options;

            var context = new TilbudsPlatformContext(options);
            return context;
        }

        [Fact]
        public async Task AddCustomerAsync_ShouldAddCustomer_WhenValidData()
        {
            var context = GetInMemoryDbContext();
            var customerService = new CustomerService(context);

            string customerName = "John Doe";
            string customerEmail = "john.doe@example.com";

            var newCustomer = await customerService.AddCustomerAsync(customerName, customerEmail);

            Assert.NotNull(newCustomer);
            Assert.Equal(customerName, newCustomer.Name);
            Assert.Equal(customerEmail, newCustomer.Email);

            var savedCustomer = await context.Customers.FirstOrDefaultAsync(c => c.Id == newCustomer.Id);
            Assert.NotNull(savedCustomer);
            Assert.Equal(customerName, savedCustomer.Name);
            Assert.Equal(customerEmail, savedCustomer.Email);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
        {
            var context = GetInMemoryDbContext();
            var customerService = new CustomerService(context);

            var customer = new Customer
            {
                Name = "Jane Doe",
                Email = "jane.doe@example.com"
            };

            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var retrievedCustomer = await customerService.GetByIdAsync(customer.Id);

            Assert.NotNull(retrievedCustomer);
            Assert.Equal(customer.Name, retrievedCustomer.Name);
            Assert.Equal(customer.Email, retrievedCustomer.Email);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnAllCustomers()
        {
            var context = GetInMemoryDbContext();
            var customerService = new CustomerService(context);

            var customer1 = new Customer { Name = "Customer One", Email = "one@example.com" };
            var customer2 = new Customer { Name = "Customer Two", Email = "two@example.com" };

            context.Customers.AddRange(customer1, customer2);
            await context.SaveChangesAsync();

            var customers = await customerService.GetAllAsync();

            Assert.NotNull(customers);
            Assert.Equal(2, customers.Count());
            Assert.Contains(customers, c => c.Name == "Customer One");
            Assert.Contains(customers, c => c.Name == "Customer Two");
        }

        [Fact]
        public async Task DeleteCustomerByIdAsync_ShouldDeleteCustomer_WhenCustomerExists()
        {
            var context = GetInMemoryDbContext();
            var customerService = new CustomerService(context);

            var customer = new Customer
            {
                Name = "Delete Me",
                Email = "delete@example.com"
            };

            context.Customers.Add(customer);
            await context.SaveChangesAsync();

            var result = await customerService.DeleteCustomerByIdAsync(customer.Id);

            Assert.True(result);
            var deletedCustomer = await context.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
            Assert.Null(deletedCustomer);
        }

        [Fact]
        public async Task DeleteCustomerByIdAsync_ShouldThrowException_WhenCustomerDoesNotExist()
        {
            var context = GetInMemoryDbContext();
            var customerService = new CustomerService(context);

            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
                await customerService.DeleteCustomerByIdAsync(999) 
            );
        }
    }
}
