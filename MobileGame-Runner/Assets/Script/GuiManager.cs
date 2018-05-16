using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuiManager : MonoBehaviour
{
    #region Singleton GUIManager

    private static GuiManager _instance;

    public static GuiManager Instance
    {

        get
        {

            if (_instance == null)
            {
                GameObject go = new GameObject("GUIManager");
                go.AddComponent<GuiManager>();
            }

            return _instance;

        }

    }


    #endregion

    public AudioSource music;
    public Text musicText;


    void Awake()
    {
        _instance = this;

    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SoundButton()
    {
        Debug.Log("Music Button called");
        music.mute = !music.mute;
        if (music.mute)
        {
            musicText.text = "Music : OFF";
        }
        else
        {
            musicText.text = "Music : ON";
        }
    }



}