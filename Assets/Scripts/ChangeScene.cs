﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public float loadDelay = 0;
    public string sceneName;

    public void LoadScene()
    {
        //disable current scene and load selected scene after time loadDelay 
        UnityEngine.EventSystems.EventSystem.current.enabled = false;
        Invoke("StartLoadScene", loadDelay);
    }

    void StartLoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

