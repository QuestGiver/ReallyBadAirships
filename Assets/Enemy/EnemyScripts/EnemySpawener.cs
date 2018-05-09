using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawener : MonoBehaviour
{
    public GunScript gunScript;
    // Update is called once per frame
    void Update()
    {
        gunScript.verticalSpawnOffset = Random.Range(-6, 6);
        gunScript.shoot();
    }
}
