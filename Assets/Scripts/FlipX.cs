using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipX : MonoBehaviour {

    public static bool isPast = false;

    private void Update()
    {
        //Debug.Log("Is Past" + " " + isPast);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "FlipCollider")
        {
            isPast = true;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("EnableCollider");
            
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<BoxCollider2D>().enabled = true;


    }
}
