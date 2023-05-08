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

	public static PositiveInteger operator +(PositiveInteger left, PositiveInteger right) => new(left.Value + right.Value);
	public static implicit operator BigInteger(PositiveInteger value) => value.Value;
	public static implicit operator PositiveInteger(int value) => new(new BigInteger(value));
	public static implicit operator PositiveInteger(uint value) => new(new BigInteger(value));
	public static implicit operator PositiveInteger(long value) => new(new BigInteger(value));
	public static implicit operator PositiveInteger(ulong value) => new(new BigInteger(value));
}