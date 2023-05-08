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
	public void Creating_A_Positive_Integer_With_A_Positive_Value_Should_Not_Throw_An_Exception([Random(0ul, ulong.MaxValue, 100)] ulong value)
	{
		Action ShouldNotThrow = () => _ = new PositiveInteger(value);

		ShouldNotThrow.Should().NotThrow();
	}
	
}