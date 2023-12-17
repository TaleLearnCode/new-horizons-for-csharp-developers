using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaleLearnCode.NewHorizons.EFCore8;

[ComplexType]  // This can also be specified in OnModelCreating --> modelBuilder.Entity<Customer>().ComplexProperty(c => c.Address);	
public class Address
{
	public required string Line1 { get; set; }
	public string? Line2 { get; set; }
	public required string City { get; set; }
	public required string Country { get; set; }
	public required string PostalCode { get; set; }
}

public class Order
{
	public int Id { get; set; }
	public required string Contents { get; set; }
	public required Address ShippingAddress { get; set; }
	public required Address BillingAddress { get; set; }
	public Customer Customer { get; set; } = null!;
}

public class Customer
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required Address Address { get; set; }
	public List<Order> Orders { get; } = new();
}

public class ValueObjectsUsingComplexTypesContext : DbContext
{
	public ValueObjectsUsingComplexTypesContext() { }
	public DbSet<Customer> Customers { get; set; } = null!;
	public DbSet<Order> Orders { get; set; } = null!;
}

public class ValueObjectsUsingComplexTypes
{

	public static async Task DemoAsync()
	{
		ValueObjectsUsingComplexTypesContext context = new();

		// Create and save a customer with their address
		Customer customer = new()
		{
			Name = "Willow",
			Address = new() { Line1 = "Barking Gate", City = "Walpole St Peter", Country = "UK", PostalCode = "PE14 7AV" }
		};
		context.Add(customer);
		await context.SaveChangesAsync();

		/* This results in the following row being inserted into the database:
		 * 
		 * INSERT INTO [Customers] ([Name], [Address_City], [Address_Country], [Address_Line1], [Address_Line2], [Address_PostCode])
		 * OUTPUT INSERTED.[Id]
		 * VALUES (@p0, @p1, @p2, @p3, @p4, @p5);
		 */

		// Notice that the complex types do not get their own tables.  Instead they are
		// saved inline to columns of the Customers table.  This matches the table sharing
		// behavior of owned types.



		// Let's say we want to ship an order to a customer and use the customer's address
		// as both the default billing and shipping address. The natural way to do this is
		// to copy the Address object from the Customer into the Order.
		customer.Orders.Add(
		new Order { Contents = "Tesco Tasty Treats", BillingAddress = customer.Address, ShippingAddress = customer.Address, });
		await context.SaveChangesAsync();

		/* With complex types, this works as expected, and the address is inserted into the Orders table:
		 * 
		 * INSERT INTO [Orders] ([Contents], [CustomerId],
		 * [BillingAddress_City], [BillingAddress_Country], [BillingAddress_Line1], [BillingAddress_Line2], [BillingAddress_PostCode],
		 * [ShippingAddress_City], [ShippingAddress_Country], [ShippingAddress_Line1], [ShippingAddress_Line2], [ShippingAddress_PostCode])
		 * OUTPUT INSERTED.[Id]
		 * VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11);
		 */

	}




	// In the example we just saw, we ended up with the same Address instance used
	// in three places.  This is allowed and odes not cause any issues for EF Core
	// when using complex types.  However, sharing instances of the same reference
	// type means that if a property value on the instance is modified, then that
	// change will be reflected in all three usages.

	// Immutable record version of the Address class
	[ComplexType]
	public record Address(string Line1, string? Line2, string City, string Country, string PostCode);



}