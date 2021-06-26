using UnityEngine;

public class Controller : MonoBehaviour
{
    bool isPaused;
    bool canClimb;
    bool canDrop;

    private Player_Movement movement;
    public Attack_Type_Player attackType;
    public PauseScreen pauseScreen;


    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Player_Movement>();
        isPaused = false;
    }

    /*Update is called 60 frames per second
     * This is better for player input as FixedUpdate will run
     * about 100fps (or a fixed frame rate), which looses extra frames of input
     * either too many frames or too little frames
     * Which caused problems with the double jumping specifically
     */
    void Update()
    {

        if (!isPaused)
        {
            Movement();
            Attack();
            
        }
        Pause();

    }

    private void Movement()
    {
        //Left/Right movement
        //Pressing the "A" key
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            //Move to the left
            movement.BasicMovement(-1f);
        }
        //Pressing the "D" key
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            //Move to the right
            movement.BasicMovement(1f);

        }
        //Idling
        else
        {
            movement.BasicMovement(0f);

        }

        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movement.AdvancedMovement(true);
        }
        else
        {
            movement.AdvancedMovement(false);
        }

        //Jumping
        //can jump? - If your on the ground and space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.Jumping(true);
        }
        else
        {
            movement.Jumping(false);
        }

        //Climbing
        if (Input.GetKey("w") && canClimb)
        {
            movement.Climb();
        }
        else
        {
            canClimb = false;
        }

        //Dropping Down Platforms
        if (Input.GetKey("s"))
        {
            canDrop = true;
        }
        else
        {
            canDrop = false;
        }
    }

    private void Attack()
    {
        //If the player can attack, Left Click!
        //If has a sword
        if (Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.LeftShift))
        {
            attackType.Attack();
        }
        
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.Pause();
            isPaused = !isPaused;
        }
    }

    public void SetCanClimb(bool boolean)
    {
        canClimb = boolean;
    }

    public bool GetCanDrop()
    {
        return canDrop;
    }
}
