using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSpearHit : MonoBehaviour {

    bool spearHit = false;
    Animator anim;
    AnimatorStateInfo animInfo;

    Rigidbody2D rb;
    

    bool recoil = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.parent != this.transform.parent)
        {
            if(other.gameObject.tag == "HitCollider" || other.gameObject.tag == "Shot")
            {
                spearHit = true;
                rb.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            }
        }
    }

    private void Awake()
    {
        
    }

    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        rb = transform.parent.GetComponent<Rigidbody2D>();
        
        
        
    }

    private void Update()
    {
        

        anim.SetBool("SpearHit", spearHit);
        animInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (spearHit == true)
        {
            
            
            spearHit = false;
            this.gameObject.SetActive(false);
        }

        SpearTimeOut();

        
    }

    private void FixedUpdate()
    {
        

    }

  
        

    public void SpearTimeOut()
    {
        if(this.gameObject.activeInHierarchy == true)
        {
            if (animInfo.tagHash == Animator.StringToHash("Spear"))
            {
                StartCoroutine("TimeOut");
            }
        }
        
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(2f);
        spearHit = true;
    }

}
