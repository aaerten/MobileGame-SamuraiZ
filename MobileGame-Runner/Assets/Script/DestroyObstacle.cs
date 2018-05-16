using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MountainB" || collision.gameObject.tag == "MountainM" || collision.gameObject.tag == "MountainS" || collision.gameObject.tag == "clouds")
        {

        }
        else
        {
            Destroy(collision.gameObject);
        }

    }
}
