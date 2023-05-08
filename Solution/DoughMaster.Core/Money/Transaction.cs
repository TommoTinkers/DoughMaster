namespace DoughMaster.Core.Money;

public abstract record Transaction(Coins Amount);

public sealed record IncomeTransaction(Coins Amount) : Transaction(Amount);