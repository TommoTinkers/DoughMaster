using TommoLib.Funky.Collections;

namespace DoughMaster.Core.Money;

public sealed record Account(Collection<Transaction> Transactions)
{
	public static readonly Account Empty = new(Collection<Transaction>.Empty);
}