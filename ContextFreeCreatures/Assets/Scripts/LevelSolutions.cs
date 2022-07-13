using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSolutions : MonoBehaviour
{
    // Tutorial
    private List<string> tutorialSol = new List<string> {"DarkBlue", "Red"};

    // Level 1
    private List<string> level1Sol = new List<string> {"Blue", "Green", "Purple", "Green", "Blue"};
    private int bestNumOfNodesLev1 = 3;
    private float averageTimeLev1 = 50f;

    // Level 2
    private List<string> level2Sol = new List<string> {"Green", "Green", "Yellow", "Yellow"};
    private int bestNumOfNodesLev2 = 3;
    private float averageTimeLev2 = 40f;

    // Level 3
    private List<string> level3Sol = new List<string> {"Red", "Blue", "Red", "Blue", "Blue"};
    private int bestNumOfNodesLev3 = 4;
    private float averageTimeLev3 = 40f;

    // Level 4
    private List<string> level4Sol = new List<string> {"DarkBlue", "DarkBlue", "Yellow", "Yellow", "Yellow", "Yellow"};
    private int bestNumOfNodesLev4 = 2;
    private float averageTimeLev4 = 30f;

    // Level 5
    private List<string> level5Sol = new List<string> {"DarkBlue", "DarkBlue", "DarkBlue", "Blue", "DarkBlue", "Blue", "Blue"};
    private int bestNumOfNodesLev5 = 4;
    private float averageTimeLev5 = 40f; 

    // Level 6
    private List<string> level6Sol = new List<string> {"Yellow", "Yellow", "Red", "Red", "Orange", "Orange", "Orange", "Orange"};
    private int bestNumOfNodesLev6 = 7;
    private float averageTimeLev6 = 40f;

   // Level 7
    private List<string> level7Sol = new List<string> {"Pink","Purple", "Pink", "Pink", "Purple", "Purple"};
    private int bestNumOfNodesLev7 = 6;
    private float averageTimeLev7 = 50f;

    // Level 8
    private List<string> level8Sol = new List<string> {"Blue", "Blue", "Blue", "Orange", "Blue", "Orange", "Blue"};
    private int bestNumOfNodesLev8 = 9;
    private float averageTimeLev8 = 40f;


    // Level 9
    private List<string> level9Sol = new List<string> {"Green", "Green", "Yellow", "Yellow"};
    private int bestNumOfNodesLev9 = 7;
    private float averageTimeLev9 = 40f;

   // Level 10
    private List<string> level10Sol = new List<string> {"Pink", "Red", "Pink", "Purple", "Pink"};
    private int bestNumOfNodesLev10 = 8;
    private float averageTimeLev10 = 40f;

   // Level 11
    private List<string> level11Sol = new List<string> {"Red", "Blue", "Red", "Red", "Blue"};
    private int bestNumOfNodesLev11 = 6;
    private float averageTimeLev11 = 50f;

   // Level 12
    private List<string> level12Sol = new List<string> {"Purple", "Purple", "Green", "Purple", "Green", "Purple", "Green", "Purple"};
    private int bestNumOfNodesLev12 = 6;
    private float averageTimeLev12 = 50f;

   // Level 13
    private List<string> level13Sol = new List<string> {"Blue", "Orange", "Green", "Orange", "Blue", "Blue", "Blue", "Orange"};
    private int bestNumOfNodesLev13 = 8;
    private float averageTimeLev13 = 70f;

   // Level 14
    private List<string> level14Sol = new List<string> {"DarkBlue", "Green", "Green", "Red", "Red", "Red", "Purple", "Purple"};
    private int bestNumOfNodesLev14 = 10;
    private float averageTimeLev14 = 70f;
        
   // Level 15
    private List<string> level15Sol = new List<string> {"Pink", "Pink", "Purple", "Purple", "Purple", "Yellow", "Yellow"};
    private int bestNumOfNodesLev15 = 8;
    private float averageTimeLev15 = 70f;
        



    public bool IsAnswerCorrect(List<GameObject> elements)
    {
        // Test from Level selection page 
        switch(StaticVariables.Level) 
        {
            case 0:
                return CheckListMatchesAnswer(elements, tutorialSol);
            case 1:
                return CheckListMatchesAnswer(elements, level1Sol);
            case 2:
                return CheckListMatchesAnswer(elements, level2Sol);
            case 3:
                return CheckListMatchesAnswer(elements, level3Sol);
            case 4:
                return CheckListMatchesAnswer(elements, level4Sol);
            case 5:
                return CheckListMatchesAnswer(elements, level5Sol);
            case 6:
                return CheckListMatchesAnswer(elements, level6Sol);
            case 7:
                return CheckListMatchesAnswer(elements, level7Sol);
            case 8:
                return CheckListMatchesAnswer(elements, level8Sol);
            case 9:
                return CheckListMatchesAnswer(elements, level9Sol);
            case 10:
                return CheckListMatchesAnswer(elements, level10Sol);
            case 11:
                return CheckListMatchesAnswer(elements, level11Sol);
            case 12:
                return CheckListMatchesAnswer(elements, level12Sol);
            case 13:
                return CheckListMatchesAnswer(elements, level13Sol);
            case 14:
                return CheckListMatchesAnswer(elements, level14Sol);
            case 15:
                return CheckListMatchesAnswer(elements, level15Sol);
            default:
                return false;
        }
    }

    public int GetNumberOfStars(float timeElapsed, int numberOfNodesUsed)
    {
        int stars = 0;
        switch(StaticVariables.Level) 
        {
            case 0:
                return 3;
            case 1:
                stars = CalculateStars(timeElapsed, averageTimeLev1, numberOfNodesUsed, bestNumOfNodesLev1);
                if (StaticVariables.Level1Stars != 3)
                    StaticVariables.Level1Stars = stars;
                return stars;
            case 2:
                stars = CalculateStars(timeElapsed, averageTimeLev2, numberOfNodesUsed, bestNumOfNodesLev2);
                if (StaticVariables.Level2Stars != 3)
                    StaticVariables.Level2Stars = stars;
                return stars;
            case 3:
                stars = CalculateStars(timeElapsed, averageTimeLev3, numberOfNodesUsed, bestNumOfNodesLev3);
                if (StaticVariables.Level3Stars != 3)
                    StaticVariables.Level3Stars = stars;
                return stars;
            case 4:
                stars = CalculateStars(timeElapsed, averageTimeLev4, numberOfNodesUsed, bestNumOfNodesLev4);
                if (StaticVariables.Level4Stars != 3)
                    StaticVariables.Level4Stars = stars;
                return stars;
            case 5:
                stars = CalculateStars(timeElapsed, averageTimeLev5, numberOfNodesUsed, bestNumOfNodesLev5);
                if (StaticVariables.Level5Stars != 3)
                    StaticVariables.Level5Stars = stars;
                return stars;
            case 6:
                stars = CalculateStars(timeElapsed, averageTimeLev6, numberOfNodesUsed, bestNumOfNodesLev6);
                if (StaticVariables.Level6Stars != 3)
                    StaticVariables.Level6Stars = stars;
                return stars;
            case 7:
                stars = CalculateStars(timeElapsed, averageTimeLev7, numberOfNodesUsed, bestNumOfNodesLev7);
                if (StaticVariables.Level7Stars != 3)
                    StaticVariables.Level7Stars = stars;
                return stars;
            case 8:
                stars = CalculateStars(timeElapsed, averageTimeLev8, numberOfNodesUsed, bestNumOfNodesLev8);
                if (StaticVariables.Level8Stars != 3)
                    StaticVariables.Level8Stars = stars;
                return stars;
            case 9:
                stars = CalculateStars(timeElapsed, averageTimeLev9, numberOfNodesUsed, bestNumOfNodesLev9);
                if (StaticVariables.Level9Stars != 3)
                    StaticVariables.Level9Stars = stars;
                return stars;
            case 10:
                stars = CalculateStars(timeElapsed, averageTimeLev10, numberOfNodesUsed, bestNumOfNodesLev10);
                if (StaticVariables.Level10Stars != 3)
                    StaticVariables.Level10Stars = stars;
                return stars;
            case 11:
                stars = CalculateStars(timeElapsed, averageTimeLev11, numberOfNodesUsed, bestNumOfNodesLev11);
                if (StaticVariables.Level11Stars != 3)
                    StaticVariables.Level11Stars = stars;
                return stars;
            case 12:
                stars = CalculateStars(timeElapsed, averageTimeLev12, numberOfNodesUsed, bestNumOfNodesLev12);
                if (StaticVariables.Level12Stars != 3)
                    StaticVariables.Level12Stars = stars;
                return stars;
            case 13:
                stars = CalculateStars(timeElapsed, averageTimeLev13, numberOfNodesUsed, bestNumOfNodesLev13);
                if (StaticVariables.Level13Stars != 3)
                    StaticVariables.Level13Stars = stars;
                return stars;
            case 14:
                stars = CalculateStars(timeElapsed, averageTimeLev14, numberOfNodesUsed, bestNumOfNodesLev14);
                if (StaticVariables.Level14Stars != 3)
                    StaticVariables.Level14Stars = stars;
                return stars;
            case 15:
                stars = CalculateStars(timeElapsed, averageTimeLev15, numberOfNodesUsed, bestNumOfNodesLev15);
                if (StaticVariables.Level15Stars != 3)
                    StaticVariables.Level15Stars = stars;
                return stars;
            default:
                return 3;
        }
    }

    private int CalculateStars(float timeElapsed, float averageLevTime, int numberOfNodesUsed, int bestNumOfNodesLev)
    {
        if (timeElapsed <= averageLevTime && numberOfNodesUsed <= bestNumOfNodesLev)
            return 3;
        else if (timeElapsed <= averageLevTime || numberOfNodesUsed <= bestNumOfNodesLev)
            return 2;
        else
            return 1;
    }

    private bool CheckListMatchesAnswer(List<GameObject> elements, List<string> level)
    {
        if (elements.Count == level.Count)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (!elements[i].gameObject.name.Contains(level[i]))
                    return false;
            }
            return true;
        }
        return false;
    }
}
