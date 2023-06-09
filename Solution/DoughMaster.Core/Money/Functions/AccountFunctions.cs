using System.Numerics;
using TommoLib.Funky.Collections;

namespace DoughMaster.Core.Money.Functions;

public static class AccountFunctions
{
	public static Account Post(this Account account, Transaction transaction) => new(Transactions: account.Transactions.Add(transaction));

	public static BigInteger Balance(this Account account) => account.Transactions.Items.Aggregate(BigInteger.Zero,
		(runningTotal, nextTransaction) => nextTransaction switch
		{
			IncomeTransaction  => runningTotal + 1,
			_ => runningTotal - 1
	
		});
}