using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip killSound;
    public AudioClip enemyShootSound;
    public GameObject enemyProjectile;
    public float startDelay = 0.5f;
    public float spawnInterval = 0.2f;

    void Start()
    {
        //attack with time startDelay and time spawnInterval
        InvokeRepeating("Attack", startDelay, spawnInterval);
    }

    void Update()
    {
             
    }

    private void Attack()
    {
        //call when player has not won or lost
        if (GameManager.playGame)
        {
            //chance of attack is 1 per 50 frames
            if (Random.Range(0f, 50f) < 1)
            {
                //spawn enemy's projectile and play enemyShootSound at enemy's position 
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(enemyShootSound, transform.position);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //call when enemy is hit by player's projectile
        if (collision.tag == "PlayerProjectile")
        {
            //play killSound at enemy's position and deduct number of enemies in GameManager
            AudioSource.PlayClipAtPoint(killSound, Vector2.zero);
            GameManager.numOfEnemy--;
        }
        
    }

}
