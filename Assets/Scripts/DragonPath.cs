using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPath : MonoBehaviour {

    public float speed;
    public Animator anim;
    AnimatorStateInfo animInfo;
    public static float t = 0;
    public static bool turningUp = true;

    private void Awake()
    {
        
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        animInfo = anim.GetCurrentAnimatorStateInfo(0);
        FlyDirection(transform.GetChild(0).localScale.x);
        anim.SetBool("turningUp", turningUp);
    }

    void FlyDirection(float x)
    {
        if(animInfo.tagHash != Animator.StringToHash("Back"))
        {
            if (x > 0f)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        if (animInfo.tagHash == Animator.StringToHash("Back"))

        {
            Turn(transform.GetChild(0).localScale.x);
        }
        
    }

    void Turn(float x)
    {
        
        if (x > 0)
        {
            
            t += .25f * Time.deltaTime;
            //Debug.Log("T: " + t);
            transform.Translate(new Vector3(Mathf.Lerp(Vector3.right.x * Time.deltaTime * speed, Vector3.left.x * Time.deltaTime * speed, t), Vector3.up.y * Time.deltaTime * speed));
        }
        else
        {
            
            //Debug.Log("Opp");
            //Debug.Log("T: " + t);
            t += .25f * Time.deltaTime;
            transform.Translate(new Vector3(Mathf.Lerp(Vector3.left.x * Time.deltaTime * speed, Vector3.right.x * Time.deltaTime * speed, t), Vector3.down.y * Time.deltaTime * speed));
        }
    }

    
}
