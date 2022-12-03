using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarName : MonoBehaviour {

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Text>().text = player.name;
    }

}
