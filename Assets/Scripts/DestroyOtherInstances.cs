using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOtherInstances : MonoBehaviour {

    public static DestroyOtherInstances instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
