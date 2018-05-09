using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawener : MonoBehaviour
{
    public GunScript gunScript;
    public float verticalOffsetRange;
    // Update is called once per frame
    void Update()
    {
        gunScript.verticalSpawnOffset = Random.Range(-verticalOffsetRange, verticalOffsetRange);
        gunScript.shoot();
    }
}
