using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Menu_Settings : PauseScreen_Menus
{
    private GameSettings GS;
    public AudioSource music;

    private void Start()
    {
        GS = FindObjectOfType<GameSettings>();
    }

    //Mutes the backgroud music
    public void MuteMusic()
    {
        GS.SetVolume(0f);
        music.volume = 0f;
    }

    //Sets the music voulme to the highest level
    public void FullVolume()
    {
        GS.SetVolume(1f);
        music.volume = 1f;
    }

    //Lowers the Volume level by 10%
    public void LowerVolume()
    {
        float newVolume = music.volume > 0 ? music.volume - .1f : 0f;
        music.volume = newVolume;
        GS.SetVolume(newVolume);
    }

    //Adjusts the brightness level based on where the slider is located
    public void AdjustBrightness(float newValue)
    {
        GS.SetBrightness(newValue);
    }
}
