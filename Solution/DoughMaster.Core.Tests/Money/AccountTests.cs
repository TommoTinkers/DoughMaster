using DoughMaster.Core.Money;
using DoughMaster.Core.Money.Functions;
using FluentAssertions;
using NUnit.Framework;

namespace DoughMaster.Core.Tests.Money;

[TestFixture]
public class AccountTests
{
	[Test]
	public void A_New_Account_Has_A_Balance_Of_Zero()
	{
		//var account = Account.Empty;

		AccountFunctions.Balance().Should().Be(0);
	}

	[Test]
	public void An_Account_With_A_Single_Income_Transaction_Has_A_Positive_Balance([Values]IncomeType type, [Random(1ul, ulong.MaxValue, 10)] ulong value)
	{
		//var account = Account.Empty;
		//account = account.Post(new IncomeTransaction(value, type));
		
		//Todo: Finish this test when the collection 'add' function is done.
	}
}