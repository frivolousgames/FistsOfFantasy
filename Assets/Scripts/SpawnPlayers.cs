using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

    //Charcters

    public GameObject wood;
    public GameObject chris;
    public GameObject phil;
    public GameObject bethany;
    public GameObject brad;

    GameObject clone;

    public Transform playerStartPosition;

    Vector3 woodStartPosition;
    Vector3 chrisStartPosition;
    Vector3 philStartPosition;
    Vector3 bethanyStartPosition;
    Vector3 bradStartPosition;

    //Backgrounds

    public GameObject clubCafe;
    public GameObject clubCafeMoon;

    public GameObject artsFest;
    public GameObject artsFestMoon;

    Vector3 bgStartPosition;
    Vector3 moonStartPosition;

    public GameObject cam;

    private void Awake()
    {
        SpawnPlayer();
    }

    void Start () {
        woodStartPosition = new Vector3(-4.53f, -1.83f);
        chrisStartPosition = new Vector3(-4.53f, -2f);
        philStartPosition = new Vector3(-4.53f, -1.41f);
        bethanyStartPosition = new Vector3(-4.53f, -2.12f);
        bradStartPosition = new Vector3(-4.53f, -1.93f);

        bgStartPosition = new Vector3(0.21f, 4.26f, 0);
        moonStartPosition = new Vector3(0f, 2.04f, -10);
    }

	void Update () {

    }

    void SpawnPlayer()
    {
        if(GameManager.wood == true)
        {
            playerStartPosition.position = woodStartPosition;
            Instantiate(wood, playerStartPosition);
            clone = GameObject.FindGameObjectWithTag("Player");
            clone.name = "Jordan";
        }

        if (GameManager.chris == true)
        {
            playerStartPosition.position = chrisStartPosition;
            Instantiate(chris, playerStartPosition);
            clone = GameObject.FindGameObjectWithTag("Player");
            clone.name = "Chris";
        }

        if (GameManager.phil == true)
        {
            playerStartPosition.position = philStartPosition;
            Instantiate(phil, playerStartPosition);
            clone = GameObject.FindGameObjectWithTag("Player");
            clone.name = "Phil";
        }

        if (GameManager.bethany == true)
        {
            playerStartPosition.position = bethanyStartPosition;
            Instantiate(bethany, playerStartPosition);
            clone = GameObject.FindGameObjectWithTag("Player");
            clone.name = "Bethany";
        }

        if (GameManager.brad == true)
        {
            playerStartPosition.position = bradStartPosition;
            Instantiate(brad, playerStartPosition);
            clone = GameObject.FindGameObjectWithTag("Player");
            clone.name = "Brad";
        }
    }
    
    void SpawnBg()
    {
        if (GameManager.artsFest == true)
        {
            Instantiate(artsFest, bgStartPosition, Quaternion.identity, null);
            Instantiate(artsFestMoon, moonStartPosition, Quaternion.identity, cam.transform);
        }

        
    }
}
