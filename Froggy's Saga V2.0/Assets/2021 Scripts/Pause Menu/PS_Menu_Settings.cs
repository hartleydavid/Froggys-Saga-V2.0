using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS_Menu_Settings : PauseScreen_Menus
{
    private GameSettings GS;
    private AudioSource music;

    private void Start()
    {
        GS = FindObjectOfType<GameSettings>();

    }

    public void MuteMusic()
    {
        GS.SetVolume(0f);
        music.volume = 0f;
        
    }

    public void FullVolume()
    {
        GS.SetVolume(1f);
        music.volume = 1f;
    }

    public void LowerVolume()
    {
        float newVolume = music.volume > 0 ? music.volume - .1f : 0f;
        music.volume = newVolume;
        GS.SetVolume(newVolume);
    }

    public void AdjustBrightness(float newValue)
    {
        //brightness.color = new Color(brightness.color.r, brightness.color.g, brightness.color.b, newValue / 10);
        GS.SetBrightness(newValue / 10);
    }
}
