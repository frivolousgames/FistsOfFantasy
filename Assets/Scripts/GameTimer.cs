using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Text gameTimerText;

    float timer;
    public static int timeInt;

    private void Start()
    {
        timer = 90;
        gameTimerText.text = timer.ToString();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        timeInt = (int)timer;
        if(PlayerHealth.isDead != true)
        {
            gameTimerText.text = timeInt.ToString();
        }
        
        
        if(timer < 1)
        {
            gameTimerText.text = "Time Up";
        }

    }
}
