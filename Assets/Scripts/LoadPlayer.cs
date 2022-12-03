using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadPlayer : MonoBehaviour {

    public Text playerText;
    GameObject player;

    private void Awake()
    {
        
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(GameManager.player);
        SetActivePlayer();
    }
    private void Update()
    {
        Debug.Log("Player " + player);
    }

    void SetActivePlayer()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        playerText.text = GameManager.player;
    }
}
