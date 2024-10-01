using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : IdentityDbContext<Customer>
{
	public RepositoryContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
    }

	public DbSet<Brand>? Brands { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Color>? Colors { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<Product>? Products { get; set; }

}
