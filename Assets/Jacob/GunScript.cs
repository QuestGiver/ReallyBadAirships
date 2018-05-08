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

    public void Start()
    {
        timer = fireRate;
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
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = par.transform.forward * 2;
            Vector3 shootDir = (par.transform.right);
            spawnedBullet.GetComponent<Rigidbody>().velocity = shootDir * speed * Time.deltaTime;
            timer = fireRate;
            Destroy(spawnedBullet, 3);
        }
    }
}
