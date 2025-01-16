using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Data;
using TilbudsPlatform.core.Entities;
using TilbudsPlatform.core.Services;
using Xunit;

public class CustomerServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
    {
        // Arrange: Set up an in-memory database
        var options = new DbContextOptionsBuilder<TilbudsPlatformContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new TilbudsPlatformContext(options);

        // Add test data to the in-memory database
        context.Customers.Add(new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" });
        context.Customers.Add(new Customer { Id = 2, Name = "Jane Doe", Email = "jane@example.com" });
        await context.SaveChangesAsync();

        var service = new CustomerService(context);

        // Act: Call the service method
        var result = await service.GetByIdAsync(1);

        // Assert: Verify the result
        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal("john@example.com", result.Email);
    }
}
