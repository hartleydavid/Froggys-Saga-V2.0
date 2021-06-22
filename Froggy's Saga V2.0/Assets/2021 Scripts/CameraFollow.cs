using UnityEngine;

/* CameraFollow class makes it so the camera will follow the player and stop
 * follow when the camera reaches a out of bound coord. point. 
 * The camera stops following with respect to the line met
 * Left or right- camera only goes up and down
 * Up or down - camera only goes left and right
 * Corners - camera doesn't follow unless one Transform check is inside the lines
 * 
 * Has four transforms representing their respective side to check if that motion needs to be stopped 
 * with the camera following along with the camera thats following the player
 */ 
public class CameraFollow : MonoBehaviour
{
    //The player Object
    private GameObject player;

    //3D vector 
    private Vector3 distance; // for the Z-coords. (And camera displacement)

    //Private Fields for the current levels playable bounds
    private double LOWERLIMIT;
    private double UPPERLIMIT;
    private double LEFTLIMIT;
    private double RIGHTLIMIT;

    //The current position of all the cameras perimeter. One for the top, bottom, left, and right
    private double lowerCameraBound;
    private double upperCameraBound;
    private double leftCameraBound;
    private double rightCameraBound;

    // Start is called before the first frame update
    void Start()
    {
        //get the game manager
        GameManager manager = FindObjectOfType<GameManager>();
        //Get the levels bounds from the game manager
        LOWERLIMIT = manager.LOWERLIMIT;
        UPPERLIMIT = manager.UPPERLIMIT;
        LEFTLIMIT = manager.LEFTLIMIT;
        RIGHTLIMIT = manager.RIGHTLIMIT;
        //find the starting distance between the camera and the player
        //This is the camera displacement that I liked the best
        distance = new Vector3(0.7f, -0.3f, -10.0f);
    }

    //Adjust the Screen Check transforms so it'll work the same with any screen size
    //And is used to set the Player it follows!
    public void UpdatePlayer(GameObject player)
    {
        this.player = player;
        AdjustBoundChecks();
    }

    // Update is called many times per frame
    //This FixedUpdate checks for if the camera is still inside the levels bounds
    void FixedUpdate()
    {
        float zAxis = player.transform.position.z + distance.z;//The Z-axis is the same no matter what case
        //If the camera is in the corner of the screen
        if (HorizontalScreenCheck() && VerticalScreenCheck())
        {
            //freeze the x and y positions
            transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);   
        }
        //If the camera is at the left or right camera limit
        else if (VerticalScreenCheck() || InverseVerticalScreenCheck())
        {
            //freeze the x position
            transform.position = new Vector3(transform.position.x,
                                                player.transform.position.y + distance.y, zAxis);
        }
        //If the camera is at the upper and lower camera limit
        else if (HorizontalScreenCheck())
        {
            //freeze the y position
            transform.position = new Vector3(player.transform.position.x + distance.x,
                                                 transform.position.y, zAxis);
        }
        else //camera is not at any bounds 
        {          
            //follow the player
            transform.position = player.transform.position + distance;
        }
        //Always adjust the camera bounds as the player is always moving
        AdjustBoundChecks();
    }

    /* This adjusts the boundChecks to be always at the edges of the camera
     * Gets the Cameras height and width and moves each point respectively to be in place
     */
    private void AdjustBoundChecks()
    {
        //The main camera being used
        Camera cam = Camera.main;
        //Players postion to shorten most of the code
        Vector3 playerPosition = player.transform.position;
        //Camera's Height and Width
        float cameraHeight = cam.orthographicSize; //orthographicSize is 1/2 of the height
        float cameraWidth = cameraHeight * cam.aspect; // .aspect is the Camera's (width/height), mult. by height to get width

        //Fixes the Screen Check transforms postion to be at the cameras perimeter no matter the size of the camera
        lowerCameraBound = playerPosition.y - cameraHeight + distance.y;
        upperCameraBound = playerPosition.y + cameraHeight + distance.y;
        leftCameraBound = playerPosition.x - cameraWidth - distance.x;
        rightCameraBound = playerPosition.x + cameraWidth + distance.x; 
    }

    //If the left passes the right threshold and vise versa
    private bool InverseVerticalScreenCheck()
    {
        return lowerCameraBound >= RIGHTLIMIT || rightCameraBound <= LEFTLIMIT;
    }

    /*This method checks if the camera's left and right bounds cross the limit threshold 
     * @return: True if bound crosses the limit
     *          False if the bounds are within the limit threshold
     */
    private bool VerticalScreenCheck()
    {
        return leftCameraBound <= LEFTLIMIT || rightCameraBound >= RIGHTLIMIT;
    }

    /*This method checks if the camera's upper and lower bounds cross the limit threshhold 
     *@return: True if bound crosses the limit
     *         False if the bounds are within the limit threshold
     */
    private bool HorizontalScreenCheck()
    {
        return lowerCameraBound <= LOWERLIMIT || upperCameraBound >= UPPERLIMIT;
    }
}
