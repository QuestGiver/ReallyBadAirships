﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadByName(string name)
    {
        SceneManager.LoadScene(name,LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
