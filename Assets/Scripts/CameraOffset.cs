using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOffset : MonoBehaviour {

    public Camera cam;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - cam.transform.position.y, transform.position.z);
    }
}
