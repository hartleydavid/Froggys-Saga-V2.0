using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //Componets needed
    private GameObject player;
    private UI_Health_Bar healthBar;
    private UI_Life_Counter lifeCounter;
    //private GameSettings GS;
    public Image brightnessImage;

    private Vector3 spawnPoint;
    //private LevelTransition transition;

    //Level Bounds - Varies per Level!!
    //Hence the public, it has to be public to be dynamic per level
    public double LOWERLIMIT = 0;
    public double UPPERLIMIT = 0;
    public double LEFTLIMIT = 0;
    public double RIGHTLIMIT = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Start of Level -- Always at origin
        spawnPoint = new Vector3(0, 0, 0); //default point
        //transition = GameObject.Find("Level Transition").GetComponent<LevelTransition>();
        player = FindObjectOfType<Player>().gameObject;

        healthBar = FindObjectOfType<UI_Health_Bar>();
        lifeCounter = FindObjectOfType<UI_Life_Counter>();
        UpdateGameGraphics(player);

        GameSettings tempGS = FindObjectOfType<GameSettings>();
        tempGS.SetBrightnessImage(brightnessImage);
        tempGS.SetNameOfCharacter(player.name);
    }

    private void UpdateGameGraphics(GameObject characterSelected)
    {
        FindObjectOfType<CameraFollow>().UpdatePlayer(characterSelected);
        healthBar.CharacterChange(characterSelected);
        lifeCounter.CharacterChange(characterSelected);
    }

    //This method handles when the player gets a game over and gives them a gameover screen 
    public void GameOver()
    {
        //transition.LoadLevel("GameOver");
        Debug.Log("Game over!");
    }

    /* Changes the players Spawn location when a Check point
     * is crossed.
     * @param Vector3 spawnPoint: the position of the check point that was achieved
     */
    public void CheckPoint(Vector3 spawnPoint)
    {
        this.spawnPoint = spawnPoint;
        //Have to set this to 0 (z normally at -0.1)
        //This will prevent animation blinking
        this.spawnPoint.z = 0;
    }

    /* When the player dies, they have to respawn, this method does just that
     * 
     */
    public void Respawn()
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        player.transform.position = spawnPoint;// player.GetComponent<PlayerMovement>().preTakeOff;
        //Transition!!!
    }

    public GameObject GetPlayersCharacter()
    {
        return player;
    }

    /* Method updates the UI whenever the player has a change in their health bar. 
     * Either taking damage or healing
     */
    public void PlayerHealthUpdate(float newHealthCount)
    {
        healthBar.UpdateInfo(newHealthCount);
    }

    /* Method for when the player dies in the game
     * Will update the UI with the new lifes left and health of the player
     */
    public void PlayerDeath(int lifesLeft, float fullHealth)
    {
        lifeCounter.UpdateInfo(lifesLeft);
        PlayerHealthUpdate(fullHealth);
    }
}