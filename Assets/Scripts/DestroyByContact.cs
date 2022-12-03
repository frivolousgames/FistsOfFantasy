using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject blockExplosion;
    Vector3 offset = new Vector3(1f, 0f, 0f);


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shot")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "Block")
        {
            if(other.gameObject.transform.parent.localScale.x > 0)
            {
                offset.x = 1f;
            }
            else
            {
                offset.x = -1f;
            }
            Destroy(gameObject);
            Instantiate(blockExplosion, other.transform.parent.position + offset, other.transform.rotation,other.gameObject.transform.parent);
        }
    }
}
