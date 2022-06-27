using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleContents : MonoBehaviour
{
    public List<GameObject> ruleImages;
    public GameObject creatureImage;
    
    public List<GameObject> GetRuleImages()
    {
        return ruleImages;  
    }

    public GameObject GetCreatureImage()
    {
        return creatureImage;
    }
}
