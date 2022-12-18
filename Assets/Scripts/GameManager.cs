using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool playGame = true;
    public static bool loseGame = false;
    public static int numOfEnemy = 27;

    public AudioClip winSound;
    public AudioClip loseSound;
    public GameObject winImage;
    public GameObject loseImage;
    private bool isPlayed = false;

    public string sceneName;

    AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    void Update()
    {
        //player wins when the game is running and all enemies are killed
        if(numOfEnemy == 0 && playGame)
        {
            playGame = false;
            GameWin();
        }
        //player loses when the game is running and loseGame is set true 
        if(loseGame && playGame)
        {
            playGame = false;
            GameLose();
        }
    }

    void GameWin()
    {
        //winImage is shown and winSound is played once
        winImage.SetActive(true);
        if (!isPlayed)
        {
            AS.PlayOneShot(winSound);
            isPlayed = true;
        }
        //call function Restart after 4 sec
        Invoke("Restart",4.0f);
    }

    void GameLose()
    {
        //loseImage is shown and loseSound is played once
        loseImage.SetActive(true);
        if (!isPlayed)
        {
            AS.PlayOneShot(loseSound);
            isPlayed = true;
        }
        //call function Restart after 4 sec
        Invoke("Restart", 4.0f);
    }

    public void Restart()
    {
        //load Start scene
        SceneManager.LoadScene(sceneName);
        //reset all variables and objects as game starts
        winImage.SetActive(false);
        loseImage.SetActive(false);
        loseGame = false;
        playGame = true;
        isPlayed = false;
        numOfEnemy = 27;
    }

}
