using DoughMaster.Console.Views;

var view = new MakingPizzaView() as View;


while (true)
{
	view = view.Display();
}