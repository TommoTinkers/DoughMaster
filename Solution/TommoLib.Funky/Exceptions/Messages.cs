using System.Numerics;

namespace TommoLib.Funky.Exceptions;

public static class Messages
{
	public const string ZeroPositiveIntegerMessage = "A PositiveInteger cannot be created with a value of 0";

	public static string NegativePositiveIntegerMessage(BigInteger negativeValue) =>
		$"A PositiveInter cannot be created with a negative value. Value used {negativeValue}";
}