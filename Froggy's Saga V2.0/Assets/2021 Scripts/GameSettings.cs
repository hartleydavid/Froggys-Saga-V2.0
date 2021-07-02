using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    private string nameOfCharacter;
    public float brightness;
    private float volume;

    public Image brightnessLayer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        brightness = 1f;
        volume = 1f;
        ///Read System save file to set these values based on a save file!
    }

    public float GetBrightness(){ return brightness; }

    public float GetVolume() { return volume; }

    public void SetVolume(float newVolume)
    {
        volume = newVolume;
    }

    public void SetBrightness(float newValue)
    {
        //Set the color of the cover Image to be itself with a changing alpha value
        //Being the inverse value it allows for the alpha to have darkened versions of the screen
        //Alpha value is from 0 to 1, 0 being completely transparent and 1 being full Opacity
        brightness = newValue;
        brightnessLayer.color = new Color(brightnessLayer.color.r, brightnessLayer.color.g, brightnessLayer.color.b, brightness / 10);

    }

    public void SetBrightnessImage(Image brightnessLayer)
    {
        this.brightnessLayer = brightnessLayer;
        SetBrightness(brightness);
    }

    public void SetNameOfCharacter(string nameOfNewCharacter)
    {
        nameOfCharacter = nameOfNewCharacter;
    }

    public string GetNameOfCharacter() { return nameOfCharacter; }
}

