using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PS_Menu_Info : PauseScreen_Menus
{
    public RectTransform playerImageTransform;
    public Animator chararcterAnimator;
    public Text characterNameField;
    public Text damageField;
    public Text generalField;

    // Start is called before the first frame update
    void Start()
    {
        //chararcterAnimator = GetComponent<Animator>();
        UpdateInfoScreen(FindObjectOfType<Player>().gameObject); ///TEMP Call
    }

    public void UpdateInfoScreen(GameObject playerObject)
    {
        AdjustCharacterNameandImage(playerObject.name);


        UpdateCharacterInfo(playerObject.GetComponent<Player>(), playerObject.GetComponent<Player_Movement>(), 
            playerObject.GetComponent<Attack_Type_Player>());
        
    }

    private void UpdateCharacterInfo(Player generalStats, Player_Movement movementStats, Attack_Type_Player attackStats)
    {
        generalField.text = string.Format("Health: {0}hp\n" +
            "\nWalk Speed: {1}\n" +
            "\nSprint Multiplier: {2}x\n", generalStats.fullHealth, movementStats.HORIZONTALFORCE, movementStats.sprintSpeed / movementStats.HORIZONTALFORCE);

        damageField.text = string.Format("Attack Type: {0}\n" +
            "\nDamage: {1}\n" +
            "\nCritical Chance: {2}%\n" +
            "\nCritical Multiplier: {3}x", attackStats.getAttackName(), attackStats.damage, attackStats.critChance, attackStats.critMultiplier);


    }


    private void AdjustCharacterNameandImage(string characterName)
    {
        characterNameField.text = characterName;//Change the name initally
        //Find the characters field positioning info
        switch (characterName)
        {
            case "Player Object": //Main character!
                UpdateCharacterImage(440.5f, 231f, -7f, 407f, -36f, 44f, "Heavy");
                break;
            case "Sr. Fox":
                //UpdateCharacterImage(563.1541f, 563.1541f, 35f, 555f, -23.596f, 77.161);
                break;
            case "Light Bandit":
                //UpdateCharacterImage(484.15f, 484.15f, 32f, 539, 0f, 61.2f, 2);
                break;
            case "Heavy Bandit":
                //UpdateCharacterImage(484.15f, 484.15f, 32f, 539, -2.5f, 61f, 3);
                break;
            case "Future Soldier":
                //UpdateCharacterImage(348f, 348f, -34.5f, 441.5f, 0f, 50f, 4);
                break;

        }
    }

    private void UpdateCharacterImage(float imageL, float imageR, float imageT, float imageB, float nameX, float nameY, string animatorNum)
    {
        //Set transforms -- For the Image
        playerImageTransform.offsetMax = new Vector2(-imageR,-imageT);
        playerImageTransform.offsetMin = new Vector2(imageL, imageB);

        chararcterAnimator.SetTrigger(animatorNum);
        chararcterAnimator.SetFloat("New Float",20);

        //chararcterAnimator.SetFloat("characterValue", animatorNum);
        Debug.Log("Test  - " + animatorNum );

        characterNameField.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(nameX, nameY);
    }
}

