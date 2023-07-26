using DockerDotNetLearning.Api.Domain.Entities;
using DockerDotNetLearning.Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await SeedData();

app.Run();



// SeedData method with 20 customers
async Task SeedData()
{
    if (!app.Environment.IsDevelopment()) return;

    try
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();

        context.Database.EnsureCreated();

        if (await context.Customers.AnyAsync()) return;

        var customers = new List<Customer>
        {
        new Customer
        {
            Name = "John",
            LastName = "Doe",
            Email = "john.doe@mail.com",
            Phone = "123456789",
            Address = "Fake Street 123",
            City = "Fake City",
            Country = "Fake Country",
            ZipCode = "1234",
            Company = "Fake Company",
            JobTitle = "Fake Job Title"
        }
        };

        await context.Customers.AddRangeAsync(customers);
        await context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
