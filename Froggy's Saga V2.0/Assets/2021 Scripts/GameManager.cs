using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Componets needed
    private GameObject player;

    //private List<GameObject> characters = new List<GameObject>();
    //public GameObject Player_Knight;
    //public GameObject Sr_Fox;
    //public GameObject Light_Bandit;
    //public GameObject Heavy_Bandit;
    //public GameObject Future_Soldier;

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
        //FillList(characters);

        //Start of Level -- Always at origin
        spawnPoint = new Vector3(0, 0, 0); //default point
        //transition = GameObject.Find("Level Transition").GetComponent<LevelTransition>();
        //player = SetPlayer(FindObjectOfType<CharacterSettings>().GetPlayer());
        player = FindObjectOfType<Player>().gameObject;
        UpdateGameGraphics(player);
    }

    /*private GameObject SetPlayer(GameObject player)
    {
        GameObject playerSelected = new GameObject();

        foreach (GameObject character in characters)
        {
            character.SetActive(false);
            if (character.name.Equals(player.name))
            {
                playerSelected = character;
                character.SetActive(true);
            }
        }
        return playerSelected;
    }*/

    private void UpdateGameGraphics(GameObject characterSelected)
    {
        FindObjectOfType<CameraFollow>().UpdatePlayer(characterSelected);
        FindObjectOfType<UI_Health_Bar>().CharacterChange(characterSelected);
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



   /* private void FillList(List<GameObject> characters)
    {
        characters.Add(Player_Knight);
        characters.Add(Sr_Fox);
        characters.Add(Light_Bandit);
        characters.Add(Heavy_Bandit);
        characters.Add(Future_Soldier);
    }*/
}