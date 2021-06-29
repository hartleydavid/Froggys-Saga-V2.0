using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen_Menus : MonoBehaviour
{
    public RectTransform rectTransform;
    public Animator animator;
    public PauseScreen paused;
    private bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        //paused = FindObjectOfType<PauseScreen>();
        //Start off screen!
        rectTransform.offsetMax = new Vector2(1617.25f, -181.3221f);//max
        rectTransform.offsetMin = new Vector2(2024.75f, 0f); //min
        isOpen = false;
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
    public void Transition(string trigger)
    {
        //Play the animation
        animator.SetTrigger(trigger);
        //Sets the animators Param for when you close the tab to transition to empty state
        bool isOpen = trigger.Equals("Open") ? OnScreen() : OffScreen();
        animator.SetBool("IsOpen", isOpen);
    }

    private bool OnScreen()
    {
        rectTransform.offsetMax = new Vector2(0f, -181.3221f);//max
        rectTransform.offsetMin = new Vector2(407.5f, 0f);//min
        return true;
    }

    private bool OffScreen()
    {
        rectTransform.offsetMax = new Vector2(1617.25f, -181.3221f);//max
        rectTransform.offsetMin = new Vector2(2024.75f, 0f); //min
        return false;
    }

    public void OpenMenu()
    {
        if (isOpen) return; //if its open you cant open it again, exit case prevents animation replay               
        //UpdateInfo(FindObjectOfType<GameManager>().GetPlayersCharacter());
        Transition("Open");
        //paused.Transition(rectTransform, animator, "Open");// close tab
        isOpen = true; //paused.CloseAllTabs();
    }

    //Closes the settings tab in the pause Screen
    public void CloseMenu()
    {
        if (!isOpen) return; //if its closed you cant close it again, exit case prevents animation replay
        //paused.Transition(rectTransform, animator, "Close");// close tab
        Transition("Close");
        isOpen = false;
    }

}
