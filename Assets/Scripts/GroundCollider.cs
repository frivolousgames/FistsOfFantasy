using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider : MonoBehaviour {
    BoxCollider2D col;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update ()
    {
		if(transform.localPosition.y > 0)
        {
            col.enabled = false;
        }
        else
        {
            col.enabled = true;

        }
    }
}
