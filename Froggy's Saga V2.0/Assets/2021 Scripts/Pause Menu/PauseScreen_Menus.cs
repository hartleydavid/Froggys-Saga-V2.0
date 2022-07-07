using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen_Menus : MonoBehaviour
{
   // public RectTransform rectTransform;
    public Animator animator;
    public PauseScreen paused;

    private bool isOpen;


    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    public void OnClickEvent()
    {
        if (!isOpen)
        {
            MenuEvent("Open", true);
            //paused.CloseAllTabs();
        }
        else
        {
            MenuEvent("Close", false);
        }
        isOpen = !isOpen;
    }


    public void MenuEvent(string triggerKey, bool booleanKey)
    {
        animator.SetTrigger(triggerKey);
        animator.SetBool("IsOpen", booleanKey);
    }
}
