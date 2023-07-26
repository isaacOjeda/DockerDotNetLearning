using DockerDotNetLearning.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DockerDotNetLearning.Api.Infrastructure.Persistence;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
}