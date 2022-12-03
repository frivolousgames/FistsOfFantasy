using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAccept : MonoBehaviour {

    CircleCollider2D col;
    public Animator anim;
    AnimatorStateInfo animInfo;
    public static string acceptor;
    
    GameObject[] players;

    

    private void Awake()
    {
        acceptor = null;
        col = this.gameObject.GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        DestroyPU();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        players = GameObject.FindGameObjectsWithTag("PUCollider");

        foreach(GameObject p in players)
        {
            if (other.gameObject == p)
            {
                col.enabled = false;
                anim.SetTrigger("Accepted");
                if(other.transform.parent.tag == "Player")
                {
                    acceptor = "Opponent";
                }
                else
                {
                    acceptor = "Player";
                }
            }
        }
    }

    

    public void DestroyPU()
    {
        if(animInfo.tagHash == Animator.StringToHash("Empty"))
        {
            if (col.enabled == true)
            {
                col.enabled = false;
            }
            Destroy(this.gameObject);
        }
        if(OpponentController.isOppFinisher == true)
        {
            Destroy(this.gameObject);
        }
    }

}
