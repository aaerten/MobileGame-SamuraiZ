using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrassSpawner : MonoBehaviour
{
    public Transform Grass;
    public float spawnRate = 1;
    public float randomDelay = 1;

    private float nextSpawn = 0;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            Instantiate(Grass, gameObject.transform.position, Quaternion.identity);
            nextSpawn = Time.time + spawnRate + Random.Range(0, randomDelay);
        }
    }
}

