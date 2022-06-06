using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSolutions : MonoBehaviour
{
    private List<string> level1Sol = new List<string> {"Blue", "Green", "Purple", "Green", "Blue"};

    private List<List<string>> allSolutions = new List<List<string>>();
    // Start is called before the first frame update

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
