﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public Text text;
    public float timeLimmit = 30;
    float timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        text.text = "Time Left: " + (30 -(timer % 60)).ToString();
        if (timer >= timeLimmit)
        {
            SceneManager.LoadScene("FightPhase", LoadSceneMode.Single);
            //fightmode start(scene transition)
            //Enable character controller
            //disable build grid
            //initialize score
            //Enable enemy spawner
        }
    }

}