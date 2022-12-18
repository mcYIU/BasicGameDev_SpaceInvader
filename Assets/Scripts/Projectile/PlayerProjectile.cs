using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
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
            //move upward with speed per game time
            transform.Translate(Vector2.up * speed * Time.deltaTime);
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
        //call when hitting enemy
        if (collision.tag == "Enemy")
        {
            //destroy itself and object collided
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

    }
}
