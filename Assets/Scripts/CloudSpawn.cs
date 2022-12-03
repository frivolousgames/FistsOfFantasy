using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {

	

	void Start ()
    {
		if(transform.parent != null)
        {
            if(transform.parent.localScale.x > 0)
            {
                transform.position = new Vector2(transform.parent.position.x - .29f, transform.parent.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.parent.position.x + .29f, transform.parent.position.y);
            }
        }
    }

    private void Update()
    {
        DestroyThis();
    }

    void DestroyThis()
    {
        if(OpponentController.isOppFinisher == true)
        {
            Destroy(this.gameObject);
        }
    }

}
