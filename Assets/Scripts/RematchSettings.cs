using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RematchSettings : MonoBehaviour {

    public GameObject blinkScreen;
    Animator blinkAnim;
    Button button;
    ColorBlock bColor;

    public static bool isClicked;

    private void Awake()
    {
        button = GetComponent<Button>();
        blinkAnim = blinkScreen.GetComponent<Animator>();
    }

    private void Update()
    {
        if(isClicked == true)
        {
            button.interactable = false;
        }
    }

    public void ButtonClicked()
    {
        if(isClicked == false)
        {
            isClicked = true;
            blinkAnim.SetTrigger("Blink");
            bColor = button.colors;
            bColor.disabledColor = button.colors.pressedColor;
            button.colors = bColor;
        }
    }

    
}
