using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Life_Counter : UI
{
    public Text lifeCounter;
    public GameObject lifeImageObject;
    public RectTransform counterTransform;
    public Sprite[] sprites;//= new Image[5];
    
    public override void CharacterChange(GameObject character)
    {
        //Switch case for the name of the players object, set the life icon and counter accordingly
        switch (character.name)
        {
            case "Player Object"://TEMP NAME!!!!
                UpdateLifeSpriteIcon(sprites[0], 92.3f, -60.2f, 256f, 184f, 140.4f, -60.2f);
                break;
            
            case "Sr. Fox":
                UpdateLifeSpriteIcon(sprites[1], 48f, -16f, 171.5f, 123f, 163.5f, -44.75f);
                break;

            case "Heavy Bandit":
                UpdateLifeSpriteIcon(sprites[2], 64.41f, -36.8f, 167f, 120f, 167.4f, -44.75f);
                break;

            case "Light Bandit":
                UpdateLifeSpriteIcon(sprites[3], 64.41f, -36.8f, 167f, 120f, 167.4f, -44.75f);            
                break;

            case "Future Soldier":
                UpdateLifeSpriteIcon(sprites[4],  31.4f, -38.3f, 320f, 230f, 167.5f, -54.9f);
                break;

        }    
    
        UpdateInfo(character.GetComponent<Player>().lifes);

    }


    public override void UpdateInfo(float value)
    {
        lifeCounter.text = "x " + value;
    }

    private void UpdateLifeSpriteIcon(Sprite newCharacter, float xPosition, float yPosition, float width, float height, float counterXPosition, float counterYPosition)
    {
        RectTransform lifeIconTransform = lifeImageObject.GetComponent<RectTransform>();
        lifeImageObject.GetComponent<Image>().sprite = newCharacter;//change image
        //Set transforms -- For the Image
        lifeIconTransform.anchoredPosition = new Vector3(xPosition, yPosition);
        //Set size
        lifeIconTransform.sizeDelta = new Vector2(width, height);
        //Move counter as well
        counterTransform.anchoredPosition = new Vector3(counterXPosition, counterYPosition);
    }


    //Sets the Activeness of the components
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        //lifeNumber.SetActive(isActive);
    }
   
}
