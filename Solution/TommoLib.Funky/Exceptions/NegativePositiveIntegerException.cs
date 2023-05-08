using System.Numerics;

namespace TommoLib.Funky.Exceptions;

public sealed class NegativePositiveIntegerException : Exception
{
	public NegativePositiveIntegerException(BigInteger negativeValue) : base(Messages.NegativePositiveIntegerMessage(negativeValue))
	{
	}
}