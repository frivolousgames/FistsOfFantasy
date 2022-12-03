using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDistance : MonoBehaviour {

    int theDistance;
    Vector2 forward;
    int layerMask;
    RaycastHit2D hit;

    public static bool isRange = false;
    public static bool isFar = false;
    public static bool isNear = false;
    public static bool isBehind = false;

    private void Awake()
    {
        isRange = false;
        isFar = false;
        isNear = false;
        isBehind = false;
    }

    private void FixedUpdate()
    {
        

        forward = transform.TransformDirection(Vector2.right * 10);

        Debug.DrawRay(transform.position, forward *20, Color.red);

        layerMask = 1 << LayerMask.NameToLayer("FlipCollider");

        hit = Physics2D.Raycast(transform.position, forward, Mathf.Infinity, layerMask);
        
        theDistance = (int)hit.distance;
        //print("Distsnce : " + theDistance);

        if (hit.distance == 0)
        {
            isRange = false;
            isFar = false;
            isNear = false;
            isBehind = true;
            Debug.Log("Behind");
        }

        if (theDistance >= 10 && theDistance < 100)
        {
            isRange = true;
            isFar = false;
            isNear = false;
            isBehind = false;

            //Debug.Log("Range");
        }

        if (theDistance < 10 && theDistance > 3)
        {
            isFar = true;
            isRange = false;
            isNear = false;
            isBehind = false;

            //Debug.Log("Far");

        }

        if (theDistance <= 2 && theDistance > 0)
        {
            isNear = true;
            isRange = false;
            isFar = false;
            isBehind = false;

            //Debug.Log("Near");

        }

    }

    
}
