using System.Numerics;

namespace DoughMaster.Core.Money.Functions;

public static class AccountFunctions
{
	public static Account Post(this Account account, Transaction transaction) => account;
	public static BigInteger Balance(this Account account) => 0;
}