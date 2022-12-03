using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseScaleX : MonoBehaviour {

    public void ChangeScale()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.y);
        DragonPath.t = 0;
        if(DragonPath.turningUp == true)
        {
            DragonPath.turningUp = false;
        }
        else
        {
            DragonPath.turningUp = true;
        }
    }
}
