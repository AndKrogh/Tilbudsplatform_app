using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Data;
using TilbudsPlatform.core.Entities;
using TilbudsPlatform.core.Services;

public class CustomerServiceTests
{
    [Fact]
    public async Task GetByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
    {
        var options = new DbContextOptionsBuilder<TilbudsPlatformContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new TilbudsPlatformContext(options);

        context.Customers.Add(new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" });
        context.Customers.Add(new Customer { Id = 2, Name = "Jane Doe", Email = "jane@example.com" });
        await context.SaveChangesAsync();

        var service = new CustomerService(context);

        var result = await service.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal("john@example.com", result.Email);
    }
}
