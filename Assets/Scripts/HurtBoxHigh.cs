using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxHigh : MonoBehaviour {

    public GameObject hurtBoxLow;
    public GameObject fighter;

    int highHit = 0;
    int highHitTotal = 0;
    bool isHighHit = false;
    float seconds;
    

    CapsuleCollider2D hiCol;
    CapsuleCollider2D loCol;

    Animator anim;
    AnimatorStateInfo animInfo;


    private void Start()
    {
        loCol = GetComponent<CapsuleCollider2D>();
        hiCol = hurtBoxLow.GetComponent<CapsuleCollider2D>();
        anim = fighter.GetComponent<Animator>();
        seconds = .1f;
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHighHit == false && hiCol.enabled == true & loCol.enabled == true)
        {
            if (other.transform.parent != this.transform.parent && PlayerHealth.isFalling != true)
            {
                if //(other.gameObject.tag == "FootBox" || other.gameObject.tag == "Keyboard" || other.gameObject.tag == "Shot"
                    (other.gameObject.layer == 11)
                {
                    highHit++;
                    isHighHit = true;
                    hiCol.enabled = false;
                    loCol.enabled = false;
                    if (animInfo.tagHash == Animator.StringToHash("Jump"))
                    {
                        anim.SetTrigger("JumpHit");

                    }
                    else
                    {
                        anim.SetTrigger("HiHit");

                    }
                    
                    StartCoroutine(EnableColliders());
                    
                }

            }
        }

    }

    IEnumerator EnableColliders()
    {
        if(hiCol.enabled == false & loCol.enabled == false)
        {
            yield return new WaitForSeconds(seconds);
            hiCol.enabled = true;
            loCol.enabled = true;
            isHighHit = false;
            seconds = .1f;
        }
    }

    public void PlayerDamage(float playerHealth)
    {

    }
}
