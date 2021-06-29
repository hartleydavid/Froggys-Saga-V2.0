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

    /* Transitions the current tab in the pause screen, that being info, settings, Hub world and quit
     * Polymorphic so any one of these "tabs" can use the method 
     * @param RectTransform rect: The rectangle Transform of the tab to be transitioned.
     *                            --MUST be a Full Screen stretch transform to allow the method to work--
     * @param Animator animator: The animator the Tab uses for its transition
     * @param Vector2 max: the Right and Top coords for the transform to move to, must be ~new Vector2(-right, -top);
     * @param Vector2 min: The left and bottom coords for the transform to move to, must be ~new Vector2(left, bottom);
     * @param string trigger: The name of the Trigger to set to allow for the correct animation 
     *                        Two options: "Open" which opens the tab and "Close" which puts the tab away
     *                        The Triggers for the animator Parameters must be called this
     */
    public void Transition(RectTransform rect, Animator animator, string trigger)
    {

        //Play the animation
        animator.SetTrigger(trigger);
        //Sets the animators Param for when you close the tab to transition to empty state
        bool isOpen = trigger.Equals("Open") ? OnScreen(rect) : OffScreen(rect);
        animator.SetBool("IsOpen", isOpen);
    }

    private bool OnScreen(RectTransform rect)
    {
        rect.offsetMax = new Vector2(0f, -181.3221f);//max
        rect.offsetMin = new Vector2(407.5f, 0f);//min
        return true;
    }

    private bool OffScreen(RectTransform rect)
    {
        rect.offsetMax = new Vector2(1617.25f, -181.3221f);//max
        rect.offsetMin = new Vector2(2024.75f, 0f); //min
        return false;
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
        //CloseAllTabs();
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
}
