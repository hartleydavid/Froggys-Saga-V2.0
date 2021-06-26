using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    public Image pauseScreenImage;
    
    private readonly float PAUSED_ALPHA = 0.65f;
    private bool isPaused;
    

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        //pauseScreenImage.
        ChangeAplhaValue(0);
        gameObject.SetActive(false);

    }

    public void Pause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            Resume();
        }
    }

    private void ChangeAplhaValue(float newAlphaValue)
    {
        var tempColor = pauseScreenImage.color;
        tempColor.a = newAlphaValue;
        pauseScreenImage.color = tempColor;
    } 

    /* Deals when the game is being paused
     * Sets the time scale to 0, which esentially freezes time
     * and puts up the pause UI
     */
    private void PauseGame()
    {
        isPaused = true;
        //lifes.SetActive(false);
        //health.SetActive(false);
        Time.timeScale = 0;
        ChangeAplhaValue(PAUSED_ALPHA);
        gameObject.SetActive(isPaused);
        //pauseMenu.SetActive(true);
    }

    /* Resumes the game after the game had been paused
     * Sets the scale back to 1 or normal time
     * and takes down the UI Panel
     */
    public void Resume()
    {
        isPaused = false;
        //CloseAllTabs();
        //pauseMenu.SetActive(false);
        Time.timeScale = 1;
        ChangeAplhaValue(0);
        gameObject.SetActive(isPaused);
        //lifes.SetActive(true);
        //health.SetActive(true);
    }
}
