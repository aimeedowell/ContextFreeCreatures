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

    public static void EndOfLevelLine(string level, string status, string numberOfNodesUsed, string timeTaken, string stars)
    {
        // status = Failed or Completed Successfully
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Level ended" + "," + level + "," + status + "," + timeTaken + "," + numberOfNodesUsed + "," + "Stars: " + "," + stars );
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

    public static void GameQuit()
    {
        int noOfStars = StaticVariables.Level1Stars + StaticVariables.Level2Stars + StaticVariables.Level3Stars +
                StaticVariables.Level4Stars + StaticVariables.Level5Stars + StaticVariables.Level6Stars + 
                StaticVariables.Level7Stars + StaticVariables.Level8Stars + StaticVariables.Level9Stars +
                StaticVariables.Level10Stars;
        string playerLevel = StaticVariables.PlayerSkillLevel.ToString();

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
        {
            file.WriteLine(DateTime.Now.TimeOfDay.ToString() + "," + "Game Closed " + "," + "Player Skill Level" + "," + playerLevel + "," + "Total No of Stars" + "," + noOfStars.ToString());
        }
    }
}
