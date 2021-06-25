using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Health_Bar : UI
{
    private float currentHealth;
    private float fullHealth;
    private float healthRatio;

    public RectTransform healthBar;
  //  public GameObject healthNumbers;
    public Text textbox;

    //Updates the Health bar to represent the current player selected
    public override void CharacterChange(GameObject character)
    {
        Player player = character.GetComponent<Player>();
        currentHealth = fullHealth = player.fullHealth;

        //if (healthRatio != 0 || healthRatio != 1 ) currentHealth = healthRatio * fullHealth;
        UpdateInfo(currentHealth);

    }


    //Updates the health bar to show the current health bar
    public override void UpdateInfo(float updatedHealth)
    {
        healthRatio = updatedHealth / fullHealth;
        currentHealth = updatedHealth;
        healthBar.localScale = new Vector2(healthRatio, 1f);
        textbox.text = currentHealth + "/" + fullHealth;
    }

    //Sets the Activeness of the components
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

}
