using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawn : MonoBehaviour {

    public GameObject bottle;
    bool spawn = true;
    

    void Start()
    {
        if (transform.parent != null)
        {
            if (transform.parent.localScale.x > 0)
            {
                transform.position = new Vector2(transform.parent.position.x - 12f, transform.parent.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.parent.position.x + 12f, transform.parent.position.y);
            }
        }

        StartCoroutine(BottleSpawner());
        
    }

    private void Update()
    {
        DestroyThis();
        
    }

    void DestroyThis()
    {
        if (OpponentController.isOppFinisher == true)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator BottleSpawner()
    {
        while(spawn == true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(bottle, this.transform.position, this.transform.rotation, this.transform.parent);
        }
        
    }

}
