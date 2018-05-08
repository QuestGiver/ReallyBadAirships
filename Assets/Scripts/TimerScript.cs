using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

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
        if (timer >= timeLimmit)
        {
            //fightmode start(scene transition)
                //Enable character controller
                //disable build grid
                //initialize score
                //Enable enemy spawner
        }
    }

}
