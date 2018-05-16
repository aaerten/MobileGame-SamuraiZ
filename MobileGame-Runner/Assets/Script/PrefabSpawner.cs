using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PrefabSpawner : MonoBehaviour
{
    public Transform Rock;
    public Transform Ghost;
    public float spawnRate = 1;
    public float randomDelay = 1;

    private int n;
    private float nextSpawn = 0;

    void Update()
    {
        
        if (Time.time > nextSpawn)
        {
        

            if (n < 5)
            {
                Instantiate(Rock, Rock.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(Ghost, Ghost.transform.position, Quaternion.identity);
            }

            n = Random.Range(0, 10);
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }
    }
}

