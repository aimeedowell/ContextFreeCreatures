using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSolutions : MonoBehaviour
{
    private List<string> level1Sol = new List<string> {"Blue", "Green", "Purple", "Green", "Blue"};
    private int bestNumOfNodesLev1 = 3;
    private float averageTimeLev1 = 30f;

    private List<List<string>> allSolutions = new List<List<string>>();
   
    

    public bool IsAnswerCorrect(List<GameObject> elements)
    {
        // Test from Level selection page 
        switch(StaticVariables.Level) 
        {
            case 1:
                return CheckListMatchesAnswer(elements, level1Sol);
            case 2:
                return false;
            default:
                return false;
        }
    }

    public int GetNumberOfStars(float timeElapsed, int numberOfNodesUsed)
    {
        switch(StaticVariables.Level) 
        {
            case 1:
                return CalculateStars(timeElapsed, averageTimeLev1, numberOfNodesUsed, bestNumOfNodesLev1);
            case 2:
                return 3;
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
