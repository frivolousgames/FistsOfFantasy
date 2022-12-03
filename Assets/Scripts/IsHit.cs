using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHit : MonoBehaviour {

    public static bool isHit = false;
    Animator anim;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "HitCollider" && other.transform.parent != this.transform.parent)
        {
            //isHit = true;
            //GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);

        }
    }

    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("IsHit", isHit);
    }
}
