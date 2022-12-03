using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public float speed;
    int detachTime;
    public int detachWait = 1;

    private void Start()
    {
        if (transform.parent != null)
        {
            if (transform.parent.localScale.x > 0)
            {
                GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void Update()
    {
        detachTime++;
        if(detachTime > detachWait)
        {
            transform.parent = null;
        }

        if(PlayerHealth.isDead == true)
        {
            speed = speed / 2;
        }
    }

    void SpeedUp()
    {
        speed = 5;
    }
}
