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
		var account = new Account();

		account.Balance().Should().Be(0);
	}
}