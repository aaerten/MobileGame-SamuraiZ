using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainSpawner : MonoBehaviour {

  
    public Transform MountainB;
    public Transform MountainM;
    public Transform MountainS;
    public Transform clouds;

    public Quaternion target;

    public float spawnRate = 1;
    public float randomDelay = 1;

    private int n;
    private float nextSpawn = 0;

    private void Start()
    {
        target.Set(0, 180, 0,1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "MountainB")
        {
            Instantiate(MountainB, new Vector3(16.59f, -3.62f, -0.3f), target);
        }
        else if (collision.gameObject.tag == "MountainM")
        {
            Instantiate(MountainM, new Vector3(15.3f, -3.85f, 2.12f), target);
        }
        else if (collision.gameObject.tag == "MountainS")
        {
            Instantiate(MountainS,new Vector3(10.78f, -4.04f, 1.25f), target);
        }

        else if (collision.gameObject.tag == "clouds")
        {
            Instantiate(clouds, new Vector3(19.8f, 3.132311f, 3.11f), Quaternion.identity);
        }

    }
}
