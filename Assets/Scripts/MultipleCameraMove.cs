using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleCameraMove : MonoBehaviour {

    List<Transform> targets = new List<Transform>();

    public Vector3 offset;
    float startingSize;

    Vector3 velocity;
    public float smoothTime = .5f;

    Camera cam;

    float camSize;
    float camVelocity;

    Transform player1;
    Transform player2;

    float maxScreenSize = 9.5f;
    float minScreenSize = 6.5f;

    float maxY = 4.1f;
    float minY = 1.1f;

    float maxSizeY;

    float bgX;
    float bgY;

    float bgMinX;
    float bgMaxX;

    float bgMinY;
    float bgMaxY;

    float bgWidth;
    float bgHeight;

    GameObject background;

    Vector3 clampedSize;

    Rect bgRect;

    public static float centerPoint;

    private void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player").transform;
        player2 = GameObject.FindGameObjectWithTag("Opponent").transform;

        targets.Add(player1);
        targets.Add(player2);

        cam = GetComponent<Camera>();
        startingSize = cam.orthographicSize;

        background = GameObject.FindGameObjectWithTag("Background");

        //bgX
        //bgY
        bgRect = background.GetComponent<SpriteRenderer>().sprite.textureRect;
        bgMinX = bgRect.xMin;
        bgMaxX = bgRect.xMax;
        bgMinY = bgRect.yMin;
        bgMaxY = bgRect.yMax;
        bgWidth = bgRect.width;
        bgHeight = bgRect.height;
    }

    private void Update()
    {
        //Debug.Log(bgRect.left);
       // Debug.Log(cam.ViewportToWorldPoint(transform.position));
        ClampCamera();
        centerPoint = GetCenterPoint().x;
    }

    private void LateUpdate()
    {
        
        SetCamSize();
        SetCamPosition();
        //cam.rect = new Rect(Mathf.Clamp(cam.rect.x, bgMinX, bgMaxX), Mathf.Clamp(cam.rect.y, bgMinY, bgMinY), bgWidth, bgHeight);
        ClampCamera();
    }

    Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for(int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
        
    }

    void SetCamSize()
    {
        camSize = (targets[0].position - targets[1].position).magnitude - startingSize;
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, camSize, ref camVelocity, smoothTime);
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minScreenSize, maxScreenSize);
        //transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
    }

    void SetCamPosition()
    {
        if (targets.Count == 0)
            return;
        Vector3 centerpoint = GetCenterPoint();
        Vector3 newPosition = centerpoint + offset;

        

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, Time.deltaTime);

        //transform.position = new Vector3(transform.position.x, maxSizeY, transform.position.z);
        

    }

    void ClampCamera()
    {
        /*clampedSize = cam.transform.position;
        clampedSize.x = Mathf.Clamp(cam.ViewportToWorldPoint(transform.position).x, -360f, 360f);
        clampedSize.y = Mathf.Clamp(cam.ViewportToWorldPoint(transform.position).y, 80, 200);
        cam.transform.position = new Vector3(clampedSize.x, clampedSize.y, cam.transform.position.z);
        //Mathf.Clamp(cam.ViewportToWorldPoint(transform.position).x, -360f, 360f);
        //= Mathf.Clamp(clampedSize.x, -360f, 360f);
        //= clampedSize;*/
        maxSizeY = cam.orthographicSize - 5.4f;
        clampedSize = cam.ViewportToWorldPoint(new Vector3(transform.position.x, maxSizeY, transform.position.z));
        clampedSize = new Vector3(Mathf.Clamp(clampedSize.x, -360, 360), clampedSize.y, 0f);
        //ampedSize.x = Mathf.Clamp(clampedSize.x, -360, 360);
        //clampedSize.y =  maxSizeY;
        

        transform.position = cam.WorldToViewportPoint(new Vector3(clampedSize.x, transform.position.y, transform.position.z));
        transform.position = new Vector3(transform.position.x, maxSizeY, transform.position.z);
    }
}
