using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    float maxScreenSize = 9.5f;
    float minScreenSize = 6.45f;

    Vector3 maxBgHeight = new Vector3(0f, 4.1f, -10f);
    Vector3 minBgHeight = new Vector3(0f, 1.1f, -10f);

    public Camera cam;

    Vector3 wallLeftMaxLeft = new Vector3(-26.9f, -5.7f, 8.5f);
    Vector3 wallLeftMaxRight = new Vector3(-11f, -5.7f, 8.5f);

    Vector3 wallRightMaxRight = new Vector3(28.3f, -5.7f, 8.5f);
    Vector3 wallRightMaxLeft = new Vector3(-11f, -5.7f, 8.5f);


}
