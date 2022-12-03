using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicToss : MonoBehaviour {

    Rigidbody2D rb;

    Vector2 tossAngle;
    public float tossPower;

    float micRotate;
    float detachTime;

    public GameObject hitBurst;
    public Transform hitBurstSpawn;

	void Start ()
    {
        
        rb = GetComponent<Rigidbody2D>();
        if (transform.parent != null)
        {
            if (transform.parent.localScale.x > 0)
            {
                tossAngle = new Vector2(1f, .5f);
                rb.AddForce(tossAngle * tossPower, ForceMode2D.Impulse);
                Debug.Log("Normal");
            }
            else
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                tossAngle = new Vector2(-1f, .5f);
                rb.AddForce(tossAngle * tossPower, ForceMode2D.Impulse);
            }
        }

        StartCoroutine(SpawnHitBurst());
    }
	

	void Update ()
    {
        //micRotate = Mathf.MoveTowards (-90, -180, 1f * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(0, 0, micRotate);

        detachTime++;
        if(transform.parent != null)
        {
            if (detachTime > 1)
            {
                transform.parent = null;
            }
        }

        
    }

    IEnumerator SpawnHitBurst()
    {
        yield return new WaitForSeconds(1.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CapsuleCollider2D>().enabled = false;
        Instantiate(hitBurst, hitBurstSpawn.position, new Quaternion(0, 0, 0, 0));
    }
}
