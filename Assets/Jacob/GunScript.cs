using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    List<GameObject> bullets;
    public int count;

    private float timer;
    public float fireRate;
    public float speed;

    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            bullets[i] = bullet;
            bullets[i].gameObject.SetActive(false);
            bullets[i].gameObject.transform.parent = this.transform;
        }
        timer = fireRate;
        count = 10;
    }

    private void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if(timer < 0 && Input.GetMouseButton(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject B = bullets[count];
        B.SetActive(true);
        Vector3 shootDir = (Input.mousePosition);
        B.GetComponent<Rigidbody>().velocity = shootDir * speed;
    }
}
