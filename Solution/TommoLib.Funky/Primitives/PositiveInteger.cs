using System.Numerics;
using TommoLib.Funky.Exceptions;

namespace TommoLib.Funky.Primitives;

public sealed record PositiveInteger
{
	public readonly BigInteger Value;

	public PositiveInteger(BigInteger value)
	{
		if (value == 0)
		{
			throw new ZeroPositiveIntegerException();
		}

		if (value < 0)
		{
			throw new NegativePositiveIntegerException(value);
		}

		Value = value;
	}

	public static PositiveInteger operator +(PositiveInteger left, PositiveInteger right) => new PositiveInteger(left.Value + right.Value);
}