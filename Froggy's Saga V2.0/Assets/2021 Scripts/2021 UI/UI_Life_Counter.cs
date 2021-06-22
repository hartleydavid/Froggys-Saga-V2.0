using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Life_Counter : UI
{
    public override void CharacterChange(GameObject player)
    {

    }

    public override void UpdateInfo(float value)
    {

    }

    /*private List<CharacterUI> characterInfo;
    private GameObject lifeNumber;

    public Sprite knight_Sprite;
    public Sprite sr_Fox_Sprite;
    public Sprite heavy_Bandit_Sprite;
    public Sprite light_Bandit_Sprite;
    public Sprite future_Soldier_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        characterInfo = new List<CharacterUI>();
        FillList(characterInfo);

        lifeNumber = GameObject.Find("Lifes");
    }

    public void UpdateLifeNumber(float lifes)
    {
        lifeNumber.GetComponent<Text>().text = "x " + lifes;
    }

    public void UpdateUI(string characterName)
    {
        //For each character
        foreach (CharacterUI info in characterInfo)
        {
            //if the one we're looking for
            if (info.GetName().Contains(characterName))
            {
                //Update the UI
                SetLifeSprite(info);
                return;
            }
        }
    }

    private void SetLifeSprite(CharacterUI info)
    {
        GetComponent<Image>().sprite = info.GetImage();//change image
        //Set transforms -- For the Image
        GetComponent<RectTransform>().anchoredPosition = new Vector3(info.GetX(), info.GetY());
        //Set size
        GetComponent<RectTransform>().sizeDelta = new Vector2(info.GetWidth(), info.GetHeight());
        //Move counter as well
        lifeNumber.GetComponent<RectTransform>().anchoredPosition = new Vector3(info.GetNumX(), info.GetNumY());
    }

    //Fills list with the coords. and scaling for each players UI
    private void FillList(List<CharacterUI> characters)
    {
        characters.Add(new CharacterUI("Player_Knight", 92.3f, -60.2f, 256f, 184f, knight_Sprite, 140.4f, -60.2f));
        characters.Add(new CharacterUI("Sr_Fox", 48f, -16f, 171.5f, 123f, sr_Fox_Sprite, 163.5f, -44.75f));
        characters.Add(new CharacterUI("Heavy_Bandit", 64.41f, -36.8f, 167f, 120f, heavy_Bandit_Sprite, 167.4f, -44.75f));
        characters.Add(new CharacterUI("Light_Bandit", 64.41f, -36.8f, 167f, 120f, light_Bandit_Sprite, 167.4f, -44.75f));
        characters.Add(new CharacterUI("Future_Soldier", 31.4f, -38.3f, 320f, 230f, future_Soldier_Sprite, 167.5f, -54.9f));
    }

    //Sets the Activeness of the components
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        lifeNumber.SetActive(isActive);
    }*/
}
