using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

static public class DataToCSV
{
    public static void AddNewLevelLine(string timestamp, string title, string level)
    {
        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AimeeLog.csv");
        // Credit youtube man
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(timestamp + "," + title + "," + level);
        }
    }
}
