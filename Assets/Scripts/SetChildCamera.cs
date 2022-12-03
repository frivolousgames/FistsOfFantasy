using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildCamera : MonoBehaviour {

    GameObject cam;

    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        this.transform.parent = cam.transform;
    }
}
