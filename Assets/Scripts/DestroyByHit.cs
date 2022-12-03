using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByHit : MonoBehaviour {

    GameObject player;
    Animator playerAnims;
    AnimatorStateInfo animInfo;

    private void Awake()
    {
        player = transform.parent.gameObject;
        playerAnims = player.GetComponent<Animator>();
    }

    private void Update()
    {
        animInfo = playerAnims.GetCurrentAnimatorStateInfo(0);

        if(animInfo.tagHash != Animator.StringToHash("LaserFace"))
        {
            Debug.Log("Laser");
            Destroy(gameObject);
        }

    }
}
