using TommoLib.Funky.Collections;
using static System.Linq.Enumerable;

namespace DoughMaster.Core.Money;

public sealed record Account(Collection<Transaction> Transactions)
{
	public static readonly Account Empty = new Account(new Collection<Transaction>(Empty<Transaction>()));
}