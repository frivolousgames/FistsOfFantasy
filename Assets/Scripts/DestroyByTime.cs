using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

    public float seconds;

    private void Update()
    {

        Destroy(this.gameObject, seconds);
    }
}
