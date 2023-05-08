using System.Numerics;
using TommoLib.Funky.Exceptions;

namespace TommoLib.Funky.Primitives;

public sealed record PositiveInteger
{
	public PositiveInteger(BigInteger Value)
	{
		if (Value == 0)
		{
			throw new ZeroPositiveIntegerException();
		}

		if (Value < 0)
		{
			throw new NegativePositiveIntegerException(Value);
		}
	}
}