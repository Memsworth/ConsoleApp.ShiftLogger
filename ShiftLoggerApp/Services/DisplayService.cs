using ConsoleTableExt;

namespace ShiftLoggerApp.Services;

public class DisplayService
{
    public void DisplayTable<T>(List<T>? data, string tableName) where T : class
    {
        ConsoleTableBuilder.From(data).WithTitle(tableName).ExportAndWriteLine();
    }

    public void DisplayMenu()
    {
        var tableData = new List<List<object>>
        {
            new List<object>{ "1", "Employees"},
            new List<object>{ "2", "Shifts"},
            new List<object>{ "3", "Display"},
            new List<object>{ "4", "Start Shift"},
            new List<object>{ "5", "Exit"}
        };
        ConsoleTableBuilder.From(tableData).WithTitle("Main Menu").ExportAndWriteLine();
    }

    public void DisplaySubMenu(string title)
    {
        var tableData = new List<List<object>>
        {
            new List<object>{ "1", "Add"},
            new List<object>{ "2", "Edit/Update"},
            new List<object>{ "3", "Delete"},
            new List<object>{ "4", "Back"}
        };
        ConsoleTableBuilder.From(tableData).WithTitle(title).ExportAndWriteLine();
    }
    
    
}