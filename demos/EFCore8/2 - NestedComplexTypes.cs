using System.ComponentModel.DataAnnotations.Schema;

namespace TaleLearnCode.NewHorizons.EFCore8.NestedComplexTypes;

[ComplexType]
public record Address(string Line1, string? Line2, string City, string Country, string PostCode);

[ComplexType]
public record PhoneNumber(int CountryCode, long Number);

[ComplexType]
public record Contact
{
	public required Address Address { get; init; }
	public required PhoneNumber HomePhone { get; init; }
	public required PhoneNumber WorkPhone { get; init; }
	public required PhoneNumber MobilePhone { get; init; }
}

public class Customer
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required Contact Contact { get; set; }
	public List<Order> Orders { get; } = new();
}

public class Order
{
	public int Id { get; set; }
	public required string Contents { get; set; }
	public required PhoneNumber ContactPhone { get; set; }
	public required Address ShippingAddress { get; set; }
	public required Address BillingAddress { get; set; }
	public Customer Customer { get; set; } = null!;
}

internal class NestedComplexTypes
{
}
