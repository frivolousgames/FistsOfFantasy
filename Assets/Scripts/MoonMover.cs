using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMover : MonoBehaviour {

    Transform cam;
    float offsetX;
    public float moveDegree = 3f;

    private void Start()
    {
        cam = transform.parent;
    }

    private void Update()
    {
        offsetX = cam.position.x - 10;

        transform.position = new Vector3(cam.position.x / moveDegree, transform.position.y, transform.position.z);
    }
}
