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
        Time.timeScale = 0;
        ChangeAplhaValue(PAUSED_ALPHA);
        gameObject.SetActive(isPaused);
    }

    /* Resumes the game after the game had been paused
     * Sets the scale back to 1 or normal time
     * and takes down the UI Panel
     */
    private void Resume()
    {
        isPaused = false;
        CloseAllTabs();
        Time.timeScale = 1;
        ChangeAplhaValue(0);
        gameObject.SetActive(isPaused);

    }

    public void ButtonResume()
    {
        Resume();
        //Give functionality back to the controller
        FindObjectOfType<Controller>().SetIsPaused(isPaused);
    }

    //Closes the Settings menue screen currently
    private void CloseAllTabs()
    {
        //FindObjectOfType<PS_Menu_Settings>().MenuEvent("Close", false);
    }
}
