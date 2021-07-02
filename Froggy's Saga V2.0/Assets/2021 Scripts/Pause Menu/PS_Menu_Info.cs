using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PS_Menu_Info : PauseScreen_Menus
{
    public Image playerImage;
    private Animator chararcterAnimator;
    public Text characterNameField;
    public Text damageField;
    public Text generalField;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInfoScreen(FindObjectOfType<Player>().gameObject);
        chararcterAnimator = GetComponent<Animator>();
    }

    public void UpdateInfoScreen(GameObject playerObject)
    {
        Player generalVars = playerObject.GetComponent<Player>();
        Player_Movement movementVars = playerObject.GetComponent<Player_Movement>();
        Attack_Type_Player attackVars = playerObject.GetComponent<Attack_Type_Player>();
        characterNameField.text = playerObject.name;

        generalField.text = string.Format("Health: {0}hp\n" +
            "\nWalk Speed: {1}\n" +
            "\nSprint Multiplier: {2}x\n", generalVars.fullHealth, movementVars.HORIZONTALFORCE, movementVars.sprintSpeed / movementVars.HORIZONTALFORCE);

        damageField.text = string.Format("Attack Type: {0}\n" +
            "\nDamage: {1}\n" +
            "\nCritical Chance: {2}%\n" +
            "\nCritical Multiplier: {3}x",attackVars.getAttackName(),attackVars.damage,attackVars.critChance,attackVars.critMultiplier);
    }

    private void UpdateCharaterImage(string characterName)
    {
        switch (characterName)
        {
            case "Sr. Fox":
                break;
            case "Future Soldier":
                break;
            case "Light Bandit":
                break;
            case "Heavy Bandit":
                break;
            case "Player Object":
                break;
                
        }
    }

    private void UpdateCharacterImage()
    {

    }
}

