namespace DoughMaster.Core.Money;

public abstract record Transaction(Coins Amount);

public sealed record IncomeTransaction(Coins Amount) : Transaction(Amount);
public sealed record ExpenseTransaction(Coins Amount) : Transaction(Amount);