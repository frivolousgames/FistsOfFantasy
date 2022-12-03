using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseSprite : MonoBehaviour {

    private void Start()
    {
        if (transform.parent != null)
        {
            if (transform.parent.localScale.x < 0)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
