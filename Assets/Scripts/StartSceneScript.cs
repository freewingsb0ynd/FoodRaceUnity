﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneScript : MonoBehaviour
{
    public AudioSource backgroundMusic;
    private void Start()
    {
        if (backgroundMusic.enabled)
        {
            backgroundMusic.Play();
        }
    }


    public void LoadPathScene()
    {
        TKSceneManager.ChangeScene("Path Scene");
    }

}
