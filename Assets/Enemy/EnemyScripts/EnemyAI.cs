using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject bullet;
    public Transform player;
    private float timer;
    public float fireRate;
    public float speed;
    public float horizontalSpawnOffset = -1f;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    }

    void Shoot()
    {
        if (timer < fireRate)
        {
            GameObject spawnedBullet = Instantiate(bullet, transform.position + new Vector3(horizontalSpawnOffset, 0, 0), gameObject.transform.rotation);

            spawnedBullet.GetComponent<Rigidbody>().velocity = ((transform.position - player.position).normalized * speed) * Time.deltaTime;

            timer = 0;
            Destroy(spawnedBullet, 5);


            if (player)
                spawnedBullet.GetComponent<BulletScript>().target = "enemy";
            else
                spawnedBullet.GetComponent<BulletScript>().target = "player";
            timer = fireRate;
            Destroy(spawnedBullet, 3);
        }
    }
}
