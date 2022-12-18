using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public AudioSource shootSound;
    public float shootInterval = 0.5f;
    float nextShootTime = 0;

    void Start()
    {

    }

    void Update()
    {
        //call when player has not won or lost
        if (GameManager.playGame)
        {
            if (Time.time >= nextShootTime && Input.GetButtonDown("Jump"))
            {
                //spawn player's projectile with time interval by pressing Jump and play shootSound 
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                shootSound.Play();
                nextShootTime = Time.time + shootInterval;
            }
        }
    }

}
