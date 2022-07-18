using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBlur : MonoBehaviour
{
    bool hasBlurred = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf && !hasBlurred)
        {
            this.GetComponent<Krivodeling.UI.Effects.UIBlur>().BeginBlur(2);
            hasBlurred = true;
        }
        else if (!this.gameObject.activeSelf && hasBlurred)
        {
            hasBlurred = true;
        }
    }
}
