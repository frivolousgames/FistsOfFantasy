using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraRaycasts : MonoBehaviour
{
    Camera cam;
    Rect pixelRect;

    int rightDistance;
    int leftDistance;
    int upDistance;
    int downDistance;

    Vector2 right;
    Vector2 left;
    Vector2 up;
    Vector2 down;

    int layerMask;
    RaycastHit2D hitRight;
    RaycastHit2D hitLeft;
    RaycastHit2D hitUp;
    RaycastHit2D hitDown;

    Vector3 rightOffset;
    Vector3 leftOffset;
    Vector3 upOffset;
    Vector3 downOffset;

    public float rightSpawn;
    public float leftSpawn;
    public float upSpawn;
    public float downSpawn;

    BoxCollider2D leftCol;
    BoxCollider2D rightCol;
    BoxCollider2D upCol;
    BoxCollider2D downCol;

    Transform lefty;


    private void Start()
    {
        cam = GetComponentInParent<Camera>();

    }

    private void FixedUpdate()
    {
        pixelRect = cam.pixelRect;

        rightOffset = cam.ScreenToWorldPoint(new Vector3(pixelRect.width, pixelRect.height / 2, transform.position.z));
        leftOffset = cam.ScreenToWorldPoint(new Vector3(0f, pixelRect.height / 2, transform.position.z));
        upOffset = cam.ScreenToWorldPoint(new Vector3(pixelRect.width / 2, pixelRect.height, transform.position.z));
        downOffset = cam.ScreenToWorldPoint(new Vector3(pixelRect.width / 2, 0f, transform.position.z));

        right = transform.TransformDirection(Vector2.right);
        left = transform.TransformDirection(Vector2.left);
        up = transform.TransformDirection(Vector2.up);
        down = transform.TransformDirection(Vector2.down);

        Debug.DrawRay(rightOffset, right, Color.green);
        Debug.DrawRay(leftOffset, left, Color.green);
        Debug.DrawRay(upOffset, up, Color.green);
        Debug.DrawRay(downOffset, down, Color.green);

        layerMask = 1 << LayerMask.NameToLayer("Border");

        hitRight = Physics2D.Raycast(rightOffset, right, .5f, layerMask);
        hitLeft = Physics2D.Raycast(leftOffset, left, .5f, layerMask);
        hitUp = Physics2D.Raycast(upOffset, up, .5f, layerMask);
        hitDown = Physics2D.Raycast(downOffset, down, .5f, layerMask);




        rightDistance = (int)hitRight.distance;

        Debug.Log("Left " + hitLeft.point.x);
        Debug.Log("Cam X " + cam.ScreenToWorldPoint(transform.position));
        
        if(hitLeft.distance == 0)
        {
            //lefty.position = new Vector3(cam.ScreenToWorldPoint(transform.position).x, transform.position.y, transform.position.z);
            //cam.transform.position = lefty.position;
        }
    }
}
