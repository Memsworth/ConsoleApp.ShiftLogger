using ConsoleTableExt;

namespace ShiftLoggerApp.Services;

public class DisplayService
{
    public void DisplayTable<T>(List<T>? data, string tableName) where T : class
    {
        ConsoleTableBuilder.From(data).WithTitle(tableName).ExportAndWriteLine();
    }

    private record DisplayMenuItem(string Id, string Value);

    public void DisplayMenu()
    {
        var tableData = new List<DisplayMenuItem>
        {
            new("1", "Employees"),
            new("2", "Shifts"),
            new("3", "Display"),
            new("4", "start Shift"),
            new("5", "Exit"),
        };
        ConsoleTableBuilder.From(tableData).WithTitle("Main Menu").ExportAndWriteLine();
    }

    public void DisplaySubMenu(string title)
    {
        var tableData = new List<DisplayMenuItem>
        {
            new("1", "add"),
            new("2", "Edit/Update"),
            new("3", "Delete"),
            new("4", "Back")
        };
        ConsoleTableBuilder.From(tableData).WithTitle(title).ExportAndWriteLine();
    }
}