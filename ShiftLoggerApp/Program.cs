// See https://aka.ms/new-console-template for more information

using ShiftLoggerApp.Services;

Console.WriteLine("Hello, World!");

bool appEnd = false;
var api = new Client("https://localhost:7199/");
var displayService = new DisplayService();

displayService.DisplayMenu();

while (!appEnd)
{
    int choice = int.Parse(Console.ReadLine()!);

    switch (choice)
    {
        case 1:
            displayService.DisplaySubMenu("Employee");
            break;
        case 2:
            displayService.DisplaySubMenu("Shift");
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            return;
    }
}