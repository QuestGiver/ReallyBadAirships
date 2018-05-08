using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawener : MonoBehaviour
{
    public GunScript gunScript;
    // Update is called once per frame
    void Update()
    {
        gunScript.shoot();
    }
}
