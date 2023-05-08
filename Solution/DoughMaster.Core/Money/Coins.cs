using TommoLib.Funky.Primitives;

namespace DoughMaster.Core.Money;

public sealed record Coins(PositiveInteger Value)
{
	public static implicit operator Coins(ulong value) => new(new PositiveInteger(value));
};