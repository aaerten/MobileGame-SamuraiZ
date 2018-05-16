using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    public Animator myAnim;
    public float speed = 5;
    public GameObject sword;

    

    void Update()
    {
        myAnim = GetComponent<Animator>();
        sword = GameObject.Find("Sword");
        transform.position += Vector3.left * speed * Time.deltaTime;
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }



}
