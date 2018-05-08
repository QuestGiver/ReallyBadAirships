using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public string target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == target)
        {
            other.gameObject.GetComponent<GridItem>().OnBulletCollision();
            Destroy(this.gameObject);
        }
    }
}
