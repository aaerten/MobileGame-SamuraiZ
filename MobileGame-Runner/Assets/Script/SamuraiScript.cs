using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SamuraiScript : MonoBehaviour
{

    private Animator myAnimator;
    private float screenCenterX;
    private Collider2D myCollider;
    private Rigidbody2D myRigidBody;
    private float CharacterLifeTime = -1;

    public Transform sword;
    public GameObject swordHit;
    public bool isGrounded;
    public Text startAgain;
    public bool isAlive = true;
    public AudioSource swordSound;
    public float CharacterForce = 650f;


    void Start()
    {
        screenCenterX = Screen.width * 0.5f;
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (CharacterLifeTime == -1)
        {

            if (Input.touchCount > 0)
            {
                Touch firstTouch = Input.GetTouch(0);

                if (Input.touchCount == 1)
                {
                    if (firstTouch.phase == TouchPhase.Began)
                    {
                        if (isGrounded)
                        {
                            if (firstTouch.position.x > screenCenterX)//right
                            {
                                myRigidBody.AddForce(transform.up * CharacterForce);
                                isGrounded = false;
                                myAnimator.Play("JumpAnimation");
                            }
                        }

                        if (firstTouch.position.x < screenCenterX)//left
                        {
                            swordSound.Play();
                            sword.transform.Rotate(0, 0, -90);
                            myAnimator.Play("HitAnimation");
                            swordHit.SetActive(true);
                            StartCoroutine(Example());
                        }

                    }
                }
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidBody.AddForce(transform.up * CharacterForce);
                myAnimator.Play("JumpAnimation");
            }


            if (Input.GetKeyDown(KeyCode.X))
            {
                swordSound.Play();
                sword.transform.Rotate(0, 0, -90);
                //sword.transform.Rotate(0, 0, -180);
                myAnimator.Play("HitAnimation");
                swordHit.SetActive(true);
                StartCoroutine(Example());
            }

            if (Input.GetKeyUp(KeyCode.X))
            {

                myAnimator.Play("RunAnimation");
            }

        }

        else
        {
            if (Time.time > CharacterLifeTime + 2)
            {
                startAgain.GetComponent<Text>().enabled = true;
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Application.LoadLevel(Application.loadedLevel);
                    startAgain.GetComponent<Text>().enabled = false;
                }
                //Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    IEnumerator Example()
    {
        yield return new WaitForSeconds(0.1f);
        sword.transform.Rotate(0, 0, 90);
        swordHit.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            foreach (PrefabSpawner ps in FindObjectsOfType<PrefabSpawner>())
            {
                ps.enabled = false;
            }
            foreach (GrassSpawner gs in FindObjectsOfType<GrassSpawner>())
            {
                gs.enabled = false;
            }
            foreach (Obstacle obstacle in FindObjectsOfType<Obstacle>())
            {
                obstacle.enabled = false;
            }
            foreach (Enemy enemy in FindObjectsOfType<Enemy>())
            {
                enemy.enabled = false;
            }

            CharacterLifeTime = Time.time;
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * CharacterForce);
            myCollider.enabled = false;
            isAlive = false;
        }



        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            foreach (PrefabSpawner ps in FindObjectsOfType<PrefabSpawner>())
            {
                ps.enabled = false;
            }
            foreach (Obstacle obstacle in FindObjectsOfType<Obstacle>())
            {
                obstacle.enabled = false;
            }
            foreach (Enemy enemy in FindObjectsOfType<Enemy>())
            {
                enemy.enabled = false;
            }

            foreach (GrassSpawner gs in FindObjectsOfType<GrassSpawner>())
            {
                gs.enabled = false;
            }
            CharacterLifeTime = Time.time;
            myRigidBody.velocity = Vector2.zero;
            myRigidBody.AddForce(transform.up * CharacterForce);
            myCollider.enabled = false;
            isAlive = false;

        }

        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }

}
