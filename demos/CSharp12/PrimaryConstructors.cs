namespace TaleLearnCode.NewHorizons.CSharp12;

#region Initialize Property Values

// Before Primary Constructors
public readonly struct Distance
{

	public readonly double Magnitude { get; }

	public readonly double Direction { get; }

	public Distance(double dx, double dy)
	{
		Magnitude = Math.Sqrt(dx * dx + dy * dy);
		Direction = Math.Atan2(dy, dx);
	}

}

/*
 * After Primary Constructors; the code initializes two readonly properties
 * that are computed from primary constructor parameters
*/
public readonly struct Distance12(double dx, double dy)
{
	public readonly double Magnitude { get; } = Math.Sqrt(dx * dx + dy * dy);
	public readonly double Direction { get; } = Math.Atan2(dy, dx);
}

#endregion

#region Create Mutable State

/*
 * You can also use primary constructors when properties are not readonly. In the
 * following example, the Translate method changes the dx and dy components. That
 * requires the Magnitude and Direction properties be computed when accessed.
 * The => operator designates an expression-bodied get accessor, whereas the =
 * operator designates an initializer. This version adds a parameterless
 * constructor to the struct. The parameterless constructor must invoke the
 * primary constructor, so that all the primary constructor parameters are initialized.
 */

public struct MutableDistance12(double dx, double dy)
{

	public readonly double Magnitude => Math.Sqrt(dx * dx + dy * dy);
	public readonly double Direction => Math.Atan2(dy, dx);
	public void Translate(double deltaX, double deltaY)
	{
		dx += deltaX;
		dy += deltaY;
	}
	public MutableDistance12() : this(0, 0) { }


}

#endregion

#region Dependency Injection

// Check out the PrimaryConstructorFunctions project for an example of dependency injection

#endregion

#region Initialize base class

// Consider a hierarchy of classes that represent different account types at a bank.
// The base account would look something like the following code:
public abstract class BankAccount0(string accountId, string owner)
{

	public string AccountId { get; } = accountId;
	public string Owner { get; } = owner;

	public override string ToString() => $"Account Id: {AccountId}, Owner: {Owner}";

}

// Many types require more specific validation on constructor parameters. For example,
// The AccountId property must be exactly 10 digits. The Owner property must not be null
// or whitespace. The following code shows how to use a primary constructor to validate
// the parameters and initialize the base class.
public abstract class BankAccount(string accountId, string owner)
{

	public string AccountId { get; } = ValidAccountNumber(accountId)
		? accountId
		: throw new ArgumentException("Invalid account number", nameof(accountId));

	public string Owner { get; } = string.IsNullOrWhiteSpace(owner)
		? throw new ArgumentException("Invalid owner name", nameof(owner))
		: owner;

	public static bool ValidAccountNumber(string accountId) => accountId?.Length == 10 && accountId.All(c => char.IsDigit(c));

}

// The derived CheckingAccount class has a primary constructor that takes all the
// parameters needed in the base class, and another parameter with a default value.
// The primary constructor calls the base constructor using the
// BankAccount(accountId, owner) syntax. This expression specifies both the type
// for the base class, and the argument for the primary constructor.
public class CheckingAccount(string accountId, string owner, decimal overdraftLimit = 0) : BankAccount(accountId, owner)
{

	public decimal CurrentBalance { get; private set; } = 0;

	public void Deposit(decimal amount)
	{
		if (amount < 0)
			throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
		CurrentBalance += amount;
	}

	public void Withdrawal(decimal amount)
	{
		if (amount < 0)
			throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
		if (CurrentBalance - amount < -overdraftLimit)
			throw new InvalidOperationException("Insufficient funds for the withdrawal");
		CurrentBalance -= amount;
	}

	public override string ToString() => $"Account Id: {AccountId}, Owner: {Owner}, Balance: {CurrentBalance}";

}

// Your derived class is not required to use a primary constructor.  You can
// create a constructor in the derived class that invokes the base class primary
// constructor.
public class LineOfCreditAccount : BankAccount
{

	private readonly decimal _creditLimit;

	public LineOfCreditAccount(string accountId, string owner, decimal creditLimit) : base(accountId, owner)
		=> _creditLimit = creditLimit;

	public decimal CurrentBalance { get; private set; } = 0;

	public void Deposit(decimal amount)
	{
		if (amount < 0)
			throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
		CurrentBalance += amount;
	}

	public void Withdrawal(decimal amount)
	{
		if (amount < 0)
			throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
		if (CurrentBalance - amount < -_creditLimit)
			throw new InvalidOperationException("Insufficient funds for the withdrawal");
		CurrentBalance -= amount;
	}

	public override string ToString() => $"Account Id: {AccountId}, Owner: {Owner}, Balance: {CurrentBalance}";

}

// Potential Concern: It is possible to create multiple copies of a primary
// constructor parameter as it is used in both derived and base classes. The
// following example creates two copies each of the owner and accountId field.
public class SavingsAccount(string accountId, string owner, decimal interestRate) : BankAccount(accountId, owner)
{
	public SavingsAccount() : this("default", "default", 0.01m) { }
	public decimal CurrentBalance { get; private set; } = 0;

	public void Deposit(decimal amount)
	{
		if (amount < 0)
			throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive");
		CurrentBalance += amount;
	}

	public void Withdrawal(decimal amount)
	{
		if (amount < 0)
			throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive");
		if (CurrentBalance - amount < 0)
			throw new InvalidOperationException("Insufficient funds for withdrawal");
		CurrentBalance -= amount;
	}

	public void ApplyInterest() => CurrentBalance *= 1 + interestRate;

	public override string ToString() => $"Account ID: {accountId}, Owner: {owner}, Balance: {CurrentBalance}";
	//public override string ToString() => $"Account ID: {AccountId}, Owner: {Owner}, Balance: {CurrentBalance}";

}

#endregion