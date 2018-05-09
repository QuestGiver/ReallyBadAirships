using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform par;

    private float timer;
    public float fireRate;
    public float speed;
    public bool player;
    public float horizontalSpawnOffset = 1f;
    public float verticalSpawnOffset = 0f;
    public float lifetime = 3;

    public void Start()
    {
        timer = fireRate;
        if (gameObject.tag == "Player")
            player = true;
        else
            player = false;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }

    public void shoot()
    {
        if (timer < 0)
        {
            GameObject spawnedBullet = Instantiate(bullet,par.transform.position + new Vector3(horizontalSpawnOffset,0,verticalSpawnOffset),gameObject.transform.rotation);

            spawnedBullet.GetComponent<Rigidbody>().velocity = new Vector3(speed * Time.deltaTime, 0, 0);

            if(player)
                spawnedBullet.GetComponent<BulletScript>().target = "enemy";
            else
                spawnedBullet.GetComponent<BulletScript>().target = "Player";
            timer = fireRate;
            Destroy(spawnedBullet, lifetime);
        }
    }

}
