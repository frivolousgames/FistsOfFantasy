using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStop : MonoBehaviour {

    Collider2D col;
    public LayerMask wallLayer;
    bool isAtBorder;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = transform.parent.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(isAtBorder == true)
        {
            col.isTrigger = false;
        }
        else
        {
            col.isTrigger = true;

        }
       
    }

    private void FixedUpdate()
    {
        isAtBorder = Physics2D.IsTouchingLayers(col, wallLayer);
        
    }


}
