namespace TommoLib.Funky.Exceptions;

public sealed class ZeroPositiveIntegerException : Exception
{
	public ZeroPositiveIntegerException() : base(Messages.ZeroPositiveIntegerMessage)
	{
	}
}