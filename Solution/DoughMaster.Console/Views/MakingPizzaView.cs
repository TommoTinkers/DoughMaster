using Spectre.Console;

namespace DoughMaster.Console.Views;

public sealed class MakingPizzaView : View
{
	
	public override View Display()
	{
		var table = new Table();

		table.AddColumns(Copy.StatusBar.CoinsHeader);
		table.AddColumns(Copy.StatusBar.RemainingTimeHeader);

		const int money = 0;
		const int timeLeft = 0;

		table.AddRow(money.ToString(), timeLeft.ToString());
		AnsiConsole.Write(table);
		
		System.Console.ReadKey(true);

		return this;
	}
}