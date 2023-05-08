using DoughMaster.Core.Money;
using FluentAssertions;
using NUnit.Framework;

namespace DoughMaster.Core.Tests.Money;

[TestFixture]
public class CoinsTests
{
	[Test]
	public void Coins_Cannot_Be_Created_With_A_Negative_Value([Random(long.MinValue, -1L, 100)] long negativeValue)
	{
		Action IShouldThrow = () => _ = new Coins(negativeValue);

		IShouldThrow.Should().Throw<Exception>();
	}

	[Test]
	public void Two_Coins_Of_Same_Value_Are_Considered_Equal([Random(1ul, ulong.MaxValue, 100)] ulong value)
	{
		var left = new Coins(value);
		var right = new Coins(value);

		left.Should().Be(right);
	}
}