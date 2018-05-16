using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callButtonFunc : MonoBehaviour
{

    public GuiManager gManager;

    public void playButton()
    {
        gManager.PlayButton();
    }

    public void soundButton()
    {
        gManager.SoundButton();
    }
}
