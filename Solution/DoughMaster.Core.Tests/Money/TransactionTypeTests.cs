using DoughMaster.Core.Money;
using FluentAssertions;
using NUnit.Framework;

namespace DoughMaster.Core.Tests.Money;

[TestFixture]
public class TransactionTypeTests
{
	[Test]
	public void There_Must_Be_At_Least_One_Income_Type()
	{
		Enum.GetValues<IncomeType>().Length.Should().BePositive();
	}

	[Test]
	public void There_Must_Be_At_Least_One_Expense_Type()
	{
		Enum.GetValues<ExpenseType>().Length.Should().BePositive();
	}
}