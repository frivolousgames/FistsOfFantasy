using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{

    List<GameObject> cars;
    bool spawn = true;
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public GameObject car5;
    public GameObject car6;

    void Start()
    {
        cars = new List<GameObject>();
        StartCoroutine(CarSpawner());
        cars.Add(car1);
        cars.Add(car2);
        cars.Add(car3);
        cars.Add(car4);
        cars.Add(car5);
        cars.Add(car6);
    }

    void Update()
    {
        if(OpponentController.isOppFinisher == true)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator CarSpawner()
    {
        while (spawn == true)
        {
            yield return new WaitForSeconds(Random.Range(5, 9));
            Instantiate(cars[Random.Range(0, cars.Count)], transform.position, Quaternion.identity, transform);
        }
    }
}
