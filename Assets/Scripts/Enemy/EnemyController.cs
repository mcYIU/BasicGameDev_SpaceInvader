using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;
    public float moveDistance;
    public float timeStep;
    private bool isMovingRight = true;

    // Use this for initialization
    void Start()
    {
        // Call the MoveEnemies function every timeStep interval
        InvokeRepeating("MoveEnemies", timeStep, timeStep);

    }

    void MoveEnemies()
    {
        //call when player has not won or lost
        if (GameManager.playGame)
        {
            if (isMovingRight)
            {
                //change position rightward with moveDistance
                float newPositionX = transform.position.x + moveDistance; 
                transform.position = new Vector2(newPositionX, transform.position.y);
                //move leftward when hitting the right scene border
                if (newPositionX >= maxPosX)
                {
                    isMovingRight = false;
                }
            }
            else
            {
                //change position leftward with moveDistance
                float newPositionX = transform.position.x - moveDistance;
                transform.position = new Vector2(newPositionX, transform.position.y);
                //move rightward when hitting the left scene border
                if (newPositionX <= minPosX)
                {
                    isMovingRight = true;
                }
            }
        }
    }


    void Update()
    {

    }

}