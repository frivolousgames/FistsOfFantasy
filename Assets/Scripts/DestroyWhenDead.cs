using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDead : MonoBehaviour {

    private void Update()
    {
        if(PlayerHealth.isDead == true)
        {
            Destroy(this.gameObject);
        }
    }
}
