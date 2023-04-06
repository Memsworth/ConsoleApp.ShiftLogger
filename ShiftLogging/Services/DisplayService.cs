using ConsoleTableExt;

namespace ShiftLogging.Services;

public static class DisplayService
{
    private static void DisplayTable<T>(List<T>? data, string tableName) where T : class?
    {
        ConsoleTableBuilder.From(data).WithTitle(tableName).ExportAndWriteLine();
    }
    
    private record DisplayMenuItem(string Id, string Value);

    public static void DisplayMenu()
    {
        var tableData = new List<DisplayMenuItem>()
        {
            new("1", "Start Shift"),
            new("2", "End Shift"),
        };
        DisplayTable(tableData, "Shift Console");
    }
}