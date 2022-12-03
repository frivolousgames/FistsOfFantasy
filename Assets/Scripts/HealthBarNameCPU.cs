using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarNameCPU : MonoBehaviour {

    GameObject cpu;
    GameObject player;

    Color color;
    Color shadowColor;
    SpriteRenderer sprite;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        cpu = GameObject.FindGameObjectWithTag("Opponent");
        sprite = cpu.GetComponent<SpriteRenderer>();
        color = sprite.color;
        
        shadowColor = new Color(.8f, 1f, 1f, .8f);
       
        if (cpu.name == player.name)
        {
            GetComponent<Text>().text = "Shadow " + cpu.name;
            color = shadowColor;
            sprite.color = color;
        }
        else
        {
            GetComponent<Text>().text = cpu.name;
        }
        
    }
}
