using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public float moveSpeed = 2f;
    float minX;
    float maxX;

    private Camera mainCamera;
    private float rightScreenEdge;
    private float leftScreenEdge;
    private float playerSpriteHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        // Initialise mainCamera variable with the game's current main camera
        mainCamera = Camera.main;

        // Find the point in game world where the right screen edge touches
        Vector2 screenTopRightCorner = new Vector2(Screen.width, Screen.height);
        Vector2 topRightCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenTopRightCorner);
        rightScreenEdge = topRightCornerInWorldSpace.x;

        // Find the point in game world where the left screen edge touches
        Vector2 screenBottomLeftCorner = new Vector2(0f, 0f);
        Vector2 bottomLeftCornerInWorldSpace = mainCamera.ScreenToWorldPoint(screenBottomLeftCorner);
        leftScreenEdge = bottomLeftCornerInWorldSpace.x;

        // Calculate the value of the player sprite's half-width
        playerSpriteHalfWidth = playerSprite.bounds.size.x * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ////call when player has not won or lost
        if (GameManager.playGame)
        {
            float hlInput = Input.GetAxis("Horizontal");
            float rightLimit = rightScreenEdge - playerSpriteHalfWidth;
            float leftLimit = leftScreenEdge + playerSpriteHalfWidth;
            Vector2 currentPos = transform.position;

            if (hlInput > 0f && transform.position.x < rightLimit)
            {

                Vector2 newPos = currentPos + new Vector2(1f, 0f);

                transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
            }
            else if (hlInput < 0f && transform.position.x > leftLimit)
            {
                //Vector2 currentPos = transform.position;
                Vector2 newPos = currentPos - new Vector2(1f, 0f);

                transform.position = Vector2.MoveTowards(currentPos, newPos, moveSpeed * Time.deltaTime);
            }
        }
    }

}
