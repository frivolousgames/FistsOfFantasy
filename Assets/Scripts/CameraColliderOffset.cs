using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderOffset : MonoBehaviour {

    public Camera cam;

    Vector3 viewPort;
    Transform newPosition;

    [SerializeField]
    private float offset = 20f;

    private void LateUpdate()
    {
        transform.position = new Vector3(cam.transform.position.x, transform.position.y, transform.position.z);
        
       
    
    }
}
