using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachFromParent : MonoBehaviour {

    int detachTime;
    public int threshold;

    private void Update()
    {
        detachTime++;
        if(transform.parent != null)
        {
            if (detachTime > threshold)
            {
                transform.parent = null;
            }
            
        }
        
    }
}
