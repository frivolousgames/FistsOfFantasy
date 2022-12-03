using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpGrounded : MonoBehaviour {

    public LayerMask ground;
    GameObject player;
    Collider2D col1;
    public Collider2D col2;

    public GameObject blood;
    public Vector3 bloodOffset;
    GameObject shadow;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Opponent");
        col1 = GetComponent<Collider2D>();
        shadow = player.transform.Find("Shadow").gameObject;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            //player.GetComponentInChildren<PolygonCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().isKinematic = true;
            player.GetComponent<SpriteRenderer>().sortingOrder = -3;
        }

        if(other.gameObject.name == "Ground")
        {
            col2.enabled = true;
            StartCoroutine(BloodWait());
            Destroy(shadow);
        }
    }

    void Blood()
    {
        Instantiate(blood, transform.position + bloodOffset, transform.rotation, null);
    }

    IEnumerator BloodWait()
    {
        yield return new WaitForSeconds(.2f);
        Blood();
    }
}
