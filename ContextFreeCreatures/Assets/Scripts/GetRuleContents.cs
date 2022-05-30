using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRuleContents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetContents()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject child = this.gameObject.transform.GetChild(i).gameObject;
            switch (child.name)
            {
                case "Green":
                    Debug.Log("Contains Green");
                    break;
                case "Blue":
                    Debug.Log("Contains Blue");
                    break;
                case "Purple":
                    Debug.Log("Contains Purple");
                    break;
                case "Red":
                    Debug.Log("Contains Red");
                    break;
                case "Yellow":
                    Debug.Log("Contains Yellow");
                    break;
                case "Pink":
                    Debug.Log("Contains Pink");
                    break;   
                case "Node":
                    Debug.Log("Contains Node");
                    break;    
                default:
                    break;                                                      
            }
        }
    }
}
