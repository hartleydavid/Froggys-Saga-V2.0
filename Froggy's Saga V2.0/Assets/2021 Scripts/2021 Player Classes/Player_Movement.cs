using UnityEngine;

/* PlayerMovement deals with the functionality of the "controller" that the user will play with
 * Gives the "W, A, S, D" functionality to move the player respectively 
 * along with a double jump capability pressing the Space bar
 * The class has all the player Components needed along with Constants used with movement
 */
public class Player_Movement : MonoBehaviour
{
    //Player Components
    private Rigidbody2D rb2d;
    private SpriteRenderer sp;
    private Animator animator;
    private EdgeCollider2D edgeCollider2D;

    //Constants 
    //All Default values
    public float HORIZONTALFORCE;
    public float JUMPFORCE = 5f;//Default is 5
    public float sprintSpeed;
    private float characterWalkingSpeed;

    private bool isGrounded;
    private bool canDoubleJump;

    private void Start()
    {
        //Get the compononets for the Player
        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        edgeCollider2D = GetComponent<EdgeCollider2D>();
        // set the ground check collider to be a trigger
        edgeCollider2D.isTrigger = true; //this makes it so it's not a solid object, but rather a invisible line
        characterWalkingSpeed = HORIZONTALFORCE;

    }


    public void Jumping(bool jumped)
    {
        //Jumping
        //can jump? - If your on the ground
        if (GroundCheck() && jumped)
        {
            Jump();
        }
        //AFTER KEY IS RELEASED!!!!!!!!
        else
        {
            if (canDoubleJump && jumped)
            {
                //can't triple jump out of a double jump!
                canDoubleJump = false;
                Jump();
            }
        }
        JumpAnimation();
    }

    private void JumpAnimation()
    {
        animator.SetFloat("Jumping", rb2d.velocity.y);
        animator.SetBool("IsJumping", !isGrounded);
    }

    public void BasicMovement(float direction)
    {
        //If Moving right
        if (direction == -1)
        {
            //Rotate Player Object rather than flip the Sprite -- Face left
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }// If moving left
        else if (direction != 0)
        {
            //Rotate Player Object rather than flip the Sprite -- Face right
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
        //GameObject.Find("Cam Bounds").transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        rb2d.velocity = new Vector2(direction * HORIZONTALFORCE, rb2d.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
    }

    public void AdvancedMovement(bool isSprinting)
    {
        if (isSprinting)
        {
            HORIZONTALFORCE = sprintSpeed;
            animator.SetBool("Sprinting", true);
        }
        else
        {
            HORIZONTALFORCE = characterWalkingSpeed;
            animator.SetBool("Sprinting", false);
        }
    }

    /*  This method handles the jump movement in the game
     *  Gets called when space is pressed and gives the player an upward velocity
     *  And updates the Players animation
     */
    public void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, JUMPFORCE);
        JumpAnimation();
    }

    /* Method that handles the Player climbing up objects
     * Specifically ladders and Vines? idk about that one
     * All characters climb at the same speed 
     */
    public void Climb()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 3f);
        //Climbing Animation?
    }

    /*This method handles doing the groundcheck for the jumping algorithm
     * It tests if the players collider collides with the platform to determine wether it's grounded or not
     * @return: Returns true if the player is grounded
     *          False if the player is in the air
     */
    private bool GroundCheck()
    {
        bool gc = edgeCollider2D.IsTouchingLayers(1 << LayerMask.NameToLayer("Platform"));
        if (gc)
        {
            isGrounded = true;
            canDoubleJump = true;
            //preTakeOff = transform.position;
        }
        else
        {
            isGrounded = false;
        }

        return gc;
    }


}