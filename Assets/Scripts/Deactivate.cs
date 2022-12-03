using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour {

    public void DeactivateObject()
    {
        if(this.gameObject.activeInHierarchy == true)
        {
            this.gameObject.SetActive(false);
        }
       
    }
}
