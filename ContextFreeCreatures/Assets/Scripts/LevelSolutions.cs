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
    private List<string> level2Sol = new List<string> {"Green", "Green", "Dirt", "Yellow", "Yellow"};
    private int bestNumOfNodesLev2 = 3;
    private float averageTimeLev2 = 20f;

    // Level 3
    private List<string> level3Sol = new List<string> {"Red", "Blue", "Dirt", "Red", "Blue", "Blue"};
    private int bestNumOfNodesLev3 = 4;
    private float averageTimeLev3 = 20f;

    // Level 4
    private List<string> level4Sol = new List<string> {"DarkBlue", "DarkBlue", "Yellow", "Yellow", "Yellow", "Yellow"};
    private int bestNumOfNodesLev4 = 2;
    private float averageTimeLev4 = 20f;



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
                StaticVariables.Level1Stars = stars;
                return stars;
            case 2:
                stars = CalculateStars(timeElapsed, averageTimeLev2, numberOfNodesUsed, bestNumOfNodesLev2);
                StaticVariables.Level2Stars = stars;
                return stars;
            case 3:
                stars = CalculateStars(timeElapsed, averageTimeLev3, numberOfNodesUsed, bestNumOfNodesLev3);
                StaticVariables.Level3Stars = stars;
                return stars;
            case 4:
                stars = CalculateStars(timeElapsed, averageTimeLev4, numberOfNodesUsed, bestNumOfNodesLev4);
                StaticVariables.Level4Stars = stars;
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
