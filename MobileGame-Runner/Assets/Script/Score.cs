using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Score : MonoBehaviour
{

    public Canvas canvas;
    public Text scoreT;
    public Text scoreH;
    public float score = 0;
    public float highscore = 0;
    public SamuraiScript life;
    public GameObject ghostScore;
    public Vector3 ghostScoreTrans;
    public ParticleSystem skeletonHeads;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("High Score");
        Scene scene = SceneManager.GetActiveScene();
        ghostScoreTrans = new Vector3(0, 14, 0);


        if (scene.name == "Menü")
        {
            scoreH.text = "High Score : " + highscore.ToString("F2");
            scoreH.GetComponent<Text>().enabled = true;
        }
    }

    void Update()
    {

        if (life.isAlive == false)
        {
            scoreH.GetComponent<Text>().enabled = true;
            scoreH.text = "High Score : " + highscore.ToString("F2");
        }

        if (score > highscore && life.isAlive == false)
        {
            highscore = score;
            PlayerPrefs.SetFloat("High Score", highscore);
        }

        scoreT.text = "Score : " + score.ToString("F1");

        if (this.transform.parent.GetComponent<SamuraiScript>().isAlive == true)
        {
            scoreCont();
        }
    }

    public void scorePlus()
    {
        if (this.transform.parent.GetComponent<SamuraiScript>().isAlive == true)
        {
            score = score + 20;
        }

    }

    public void scoreCont()
    {
        score = score + 0.05f;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ghost")
        {
            scorePlus();
            ghostScore.SetActive(true);
            ghostScore.transform.DOMove(new Vector2(ghostScore.transform.position.x, ghostScore.transform.position.y + 10), 1).SetRelative();
            StartCoroutine(Waiting());
            skeletonHeads.Play();
        }
        
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        ghostScore.SetActive(false);
        ghostScore.transform.position = ghostScoreTrans;
        skeletonHeads.Stop();
    }
}
