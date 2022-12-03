using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderStop : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HitCollider" && other.transform.parent != transform.parent)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
