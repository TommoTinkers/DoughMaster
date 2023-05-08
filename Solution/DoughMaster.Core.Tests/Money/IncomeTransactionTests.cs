using DoughMaster.Core.Money;
using FluentAssertions;
using NUnit.Framework;

namespace DoughMaster.Core.Tests.Money;

[TestFixture]
public class IncomeTransactionTests
{
	[Test]
	public void A_Transaction_Has_A_Coin_Value_Matching_That_Which_It_Was_Created_With([Values]IncomeType type, [Random(1ul, ulong.MaxValue, 10)] ulong value)
	{
		var transaction = new IncomeTransaction(value);

		transaction.Amount.Value.Value.Should().Be(value);
	}

	[Test]
	public void Two_Transactions_Created_The_Same_Way_Are_Considered_Equal([Values] IncomeType type,
		[Random(1ul, ulong.MaxValue, 10)] ulong value)
	{
		var left = new IncomeTransaction(value);
		var right = new IncomeTransaction(value);

		left.Should().Be(right);
	}
}