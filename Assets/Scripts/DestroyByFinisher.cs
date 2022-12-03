using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByFinisher : MonoBehaviour {

	

	void Update ()
    {
		if(OpponentController.isOppFinisher == true)
        {
            Destroy(gameObject);
        }
	}
}
