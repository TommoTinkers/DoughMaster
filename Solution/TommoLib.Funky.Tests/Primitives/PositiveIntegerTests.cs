using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using TommoLib.Funky.Exceptions;
using TommoLib.Funky.Primitives;

namespace TommoLib.Funky.Tests.Primitives;

[TestFixture]
public class PositiveIntegerTests
{
	[Test]
	public void Creating_A_Positive_Integer_With_A_Value_Of_Zero_Throws_A_Zero_Positive_Integer_Exception()
	{
		Action ShouldThrow = () => _ = new PositiveInteger(0u);

		ShouldThrow.Should().ThrowExactly<ZeroPositiveIntegerException>()
			.WithMessage(Messages.ZeroPositiveIntegerMessage);
	}

	[Test]
	public void Creating_A_Positive_Integer_With_A_Negative_value_Throws_A_Negative_Positive_Integer_Exception([Random(long.MinValue, -1L, 100)] long negativeValue)
	{
		Action ShouldThrow = () => _ = new PositiveInteger(negativeValue);

		ShouldThrow.Should().ThrowExactly<NegativePositiveIntegerException>().WithMessage(Messages.NegativePositiveIntegerMessage(negativeValue));
	}
	
	[Test]
	public void Creating_A_Positive_Integer_With_A_Positive_Value_Should_Not_Throw_An_Exception([Random(1ul, ulong.MaxValue, 100)] ulong value)
	{
		Action ShouldNotThrow = () => _ = new PositiveInteger(value);

		ShouldNotThrow.Should().NotThrow();
	}

	[Test]
	public void Two_Positive_Integers_Created_With_The_Same_Value_Are_Equal([Random(1ul, ulong.MaxValue, 100)] ulong value)
	{
		var left = new PositiveInteger(value);
		var right = new PositiveInteger(value);

		left.Should().Be(right);
	}

	[Test]
	public void Two_Positive_Integers_Created_With_Different_Values_Are_Not_Equal([Random(1ul, ulong.MaxValue, 10)] ulong leftValue, [Random(1ul, ulong.MaxValue, 10)] ulong rightValue)
	{
		if (leftValue == rightValue)
		{
			Assert.Pass();
		}
		
		var left = new PositiveInteger(leftValue);
		var right = new PositiveInteger(rightValue);

		left.Should().NotBe(right);
	}

	[Test]
	public void Value_Should_Be_The_Same_As_The_Value_It_Was_Created_With([Random(1ul, ulong.MaxValue, 100)] ulong value)
	{
		var positiveInteger = new PositiveInteger(value);

		positiveInteger.Value.Should().Be(value);
	}

	[Test]
	public void Adding_Two_Positive_Integers_Gives_Same_Result_As_Adding_The_Two_Inputs([Random(1ul, ulong.MaxValue/2, 10)] ulong leftValue, [Random(1ul, ulong.MaxValue/2, 10)] ulong rightValue)
	{
		var expected = leftValue + rightValue;

		var actual = new PositiveInteger(leftValue) + new PositiveInteger(rightValue);

		actual.Value.Should().Be(expected);
	}
}