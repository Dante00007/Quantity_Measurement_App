// See https://aka.ms/new-console-template for more information

using QuantityMeasurementAppConsole.Menu;
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.ShowMenu();
    }
}