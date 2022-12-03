using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachChildren : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.transform != transform.parent)
        {
            if (other.gameObject.tag == "Shot" ||
            other.gameObject.tag == "Block")
            {
                transform.DetachChildren();
            }
        }
        
    }

    private void Start()
    {
        if(this.gameObject.name == "Mic Shot Anim")
        {
            StartCoroutine("TimeDetach");

        }
    }

    IEnumerator TimeDetach()
    {
        yield return new WaitForSeconds(.9f);
        transform.DetachChildren();
    }
}
