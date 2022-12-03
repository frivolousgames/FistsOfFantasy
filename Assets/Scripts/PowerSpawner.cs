using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSpawner : MonoBehaviour {

    public List<GameObject> powers;

    public GameObject bees;
    public GameObject rain;
    public GameObject bottles;
    public GameObject electricity;
    

    public GameObject beehiveIcon;
    public GameObject cloudIcon;
    public GameObject thumbIcon;
    public GameObject shockIcon;

    GameObject beehiveRect;
    GameObject cloudRect;
    GameObject shockRect;
    GameObject thumbRect;

    public GameObject hornetText;
    public GameObject rainText;
    public GameObject groundText;
    public GameObject hecklerText;

    public GameObject bottleCollider;

    GameObject player;
    GameObject opponent;

    GameObject randomPower;

    public GameObject canvas;

    

    private void Awake()
    {
        powers = new List<GameObject>();
        
    }

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        opponent = GameObject.FindGameObjectWithTag("Opponent");

        powers.Add(bees);
        powers.Add(rain);
        powers.Add(bottles);
        powers.Add(electricity);
        
    }

    private void Update()
    {
        PowerChoose(PowerUpAccept.acceptor);
    }



    void PowerChoose(string acceptor)
    {
        
        if(acceptor != null)
        {
            randomPower = powers[Random.Range(0, powers.Count)];
            
            Instantiate(randomPower, GameObject.FindGameObjectWithTag(acceptor).transform.position, Quaternion.Euler(Vector3.zero), GameObject.FindGameObjectWithTag(acceptor).transform);
            if(randomPower == bees)
            {
                Instantiate(hornetText, canvas.transform);
                beehiveRect = Instantiate(beehiveIcon, canvas.transform);
                randomPower = null;
                if (GameObject.FindGameObjectWithTag(acceptor) == player)
                {
                    beehiveRect.GetComponent<RectTransform>().localPosition = new Vector3(-455f, 500f, 0f);
                }
                else
                {
                    beehiveRect.GetComponent<RectTransform>().localPosition = new Vector3(447f, 500f, 0f);
                }
            }
            if (randomPower == rain)
            {
                Instantiate(rainText, canvas.transform);
                cloudRect = Instantiate(cloudIcon, canvas.transform);
                randomPower = null;
                if (GameObject.FindGameObjectWithTag(acceptor) == player)
                {
                    cloudRect.GetComponent<RectTransform>().localPosition  = new Vector3(-459f, 498f, 0f);
                }
                else
                {
                    cloudRect.GetComponent<RectTransform>().localPosition = new Vector3(452f, 498f, 0f);
                }
            }
            if (randomPower == electricity)
            {
                Instantiate(groundText, canvas.transform);
                shockRect = Instantiate(shockIcon, canvas.transform);
                randomPower = null;
                if (GameObject.FindGameObjectWithTag(acceptor) == player)
                {
                    shockRect.GetComponent<RectTransform>().localPosition = new Vector3(-459f, 492f, 0f);
                }
                else
                {
                    shockRect.GetComponent<RectTransform>().localPosition = new Vector3(452f, 492f, 0f);
                }
            }
            if (randomPower == bottles)
            {
                Instantiate(bottleCollider, GameObject.FindGameObjectWithTag(acceptor).transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag(acceptor).transform);
                Instantiate(hecklerText, canvas.transform);
                thumbRect = Instantiate(thumbIcon, canvas.transform);
                randomPower = null;
                if (GameObject.FindGameObjectWithTag(acceptor) == player)
                {
                    thumbRect.GetComponent<RectTransform>().localPosition = new Vector3(-459f, 492f, 0f);
                }
                else
                {
                    thumbRect.GetComponent<RectTransform>().localPosition = new Vector3(452f, 492f, 0f);
                }
            }
            PowerUpAccept.acceptor = null;
            
        }
    }

 
}
