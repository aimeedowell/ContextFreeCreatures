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
    private float averageTimeLev1 = 30f;

    // Level 2
    private List<string> level2Sol = new List<string> {"Green", "Green", "Yellow", "Yellow"};
    private int bestNumOfNodesLev2 = 3;
    private float averageTimeLev2 = 20f;

    // Level 3
    private List<string> level3Sol = new List<string> {"Red", "Blue", "Red", "Blue", "Blue"};
    private int bestNumOfNodesLev3 = 4;
    private float averageTimeLev3 = 20f;

    // Level 4
    private List<string> level4Sol = new List<string> {"DarkBlue", "DarkBlue", "Yellow", "Yellow", "Yellow", "Yellow"};
    private int bestNumOfNodesLev4 = 2;
    private float averageTimeLev4 = 20f;

    // Level 5
    private List<string> level5Sol = new List<string> {"Pink","Purple", "Pink", "Pink", "Purple", "Purple"};
    private int bestNumOfNodesLev5 = 6;
    private float averageTimeLev5 = 20f;

    // Level 6
    private List<string> level6Sol = new List<string> {"Red", "Red", "Red", "Purple", "Red", "Purple", "Purple"};
    private int bestNumOfNodesLev6 = 4;
    private float averageTimeLev6 = 20f;

    private List<string> level7Sol = new List<string> {"Yellow", "Yellow", "Red", "Red", "Orange", "Orange", "Orange", "Orange"};
    private int bestNumOfNodesLev7 = 4;
    private float averageTimeLev7 = 20f;
        



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
