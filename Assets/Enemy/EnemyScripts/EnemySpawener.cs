using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawener : MonoBehaviour
{
    public GunScript gunScript;
    public GameObject enemyObj;
    public float spawnRate;
    // Use this for initialization
    void Start()
    {
        gunScript.bullet = enemyObj;
        gunScript.fireRate = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
