using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public float speed;

    void Start()
    {

    }

    void Update()
    {
        //call when player has not won or lost
        if (GameManager.playGame)
        {
            //move downward with speed per game time
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            //destroy itself when player wins or loses
            Destroy(gameObject);
        }
    }

        void OnBecameInvisible()
    {
        //destroy itself when reaching out of game camera
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //call when hitting player
        if (collision.tag == "Player")
        {
            //player loses
            GameManager.loseGame = true;
        }

    }

}

