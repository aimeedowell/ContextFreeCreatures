using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

static public class DataToCSV
{
    static string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "AimeeLog.csv");
    public static void AddNewLevelLine(string level)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Start of level: " + "," + level);
        }
    }

    public static void EndOfLevelLine(string level, string status, string numberOfNodesUsed, string timeTaken)
    {
        // status = Failed or Completed Successfully
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level ended" + "," + level + "," + status + "," + timeTaken + "," + numberOfNodesUsed);
        }
        CoinUpdateLine(level);
    }

    static void CoinUpdateLine(string level)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level ended:" + "," + level + "," + "Coin total: " + "," + StaticVariables.CoinCount.ToString());
        }
    }

    public static void EndWordUpdateLine(string level, List<string> endword)
    {
        string newString = "";
        for (int i = 0; i < endword.Count; i++)
        {
            newString += endword[i];
            newString += ",";
        }
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level:" + "," + level + "," + "Rule added" + "," + "Updated end word:" + "," + newString);
        }
    }

    public static void StartNodeToffeeLine(string level, List<string> endword)
    {
        string newString = "";
        for (int i = 0; i < endword.Count; i++)
        {
            newString += endword[i];
            newString += ",";
        }
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level:" + "," + level + "," + "Start Node Toffee Applied" + "," + "Updated end word:" + "," + newString);
        }
    }

    public static void RestartBonBonLine(string level)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level:" + "," + level + "," + "Restart Bon Bon Applied");
        }
    }

    public static void DelayTruffleLine(string level)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level:" + "," + level + "," + "Delay Truffle Applied");
        }
    }
}
