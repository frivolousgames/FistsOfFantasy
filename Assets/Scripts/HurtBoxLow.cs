using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxLow : MonoBehaviour {

    public GameObject hurtBoxHigh;
    public GameObject fighter;

    int lowHit = 0;
    bool isLowHit = false;
    float seconds;

    CapsuleCollider2D hiCol;
    CapsuleCollider2D loCol;

    Animator anim;
    AnimatorStateInfo animInfo;

    //AnimatorTransitionInfo animInfo;

    private void Start()
    {
        seconds = .1f;
        hiCol = GetComponent<CapsuleCollider2D>();
        loCol = hurtBoxHigh.GetComponent<CapsuleCollider2D>();
        anim = fighter.GetComponent<Animator>();
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isLowHit == false && hiCol.enabled == true & loCol.enabled == true)
        {
            if (other.transform.parent != this.transform.parent && PlayerHealth.isFalling != true)
            {
                if (other.gameObject.layer == 11)
                //(other.gameObject.tag == "FootBox" || other.gameObject.tag == "Keyboard" || other.gameObject.tag == "Shot")
                {
                    lowHit++;
                    isLowHit = true;
                    hiCol.enabled = false;
                    loCol.enabled = false;
                    if (animInfo.tagHash == Animator.StringToHash("Jump"))
                    {
                        anim.SetTrigger("JumpHit");

                    }
                    else
                    {
                        //anim.SetBool("isHighBlocking", false);
                        anim.SetTrigger("LoHit");
                    }
                    
                    StartCoroutine(EnableColliders());
                    
                }
                
            }
        }

    }

    IEnumerator EnableColliders()
    {
        if (hiCol.enabled == false & loCol.enabled == false)
        {
            yield return new WaitForSeconds(seconds);
            hiCol.enabled = true;
            loCol.enabled = true;
            isLowHit = false;
            seconds = .1f;
        }
    }
}
