using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(GunScript))]
public class PlayerController : MonoBehaviour
{
    public float speed;

    private PlayerMotor motor;
    private GunScript gun;

	void Start ()
    {
        motor = GetComponent<PlayerMotor>();
        gun = GetComponent<GunScript>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float Xmove = Input.GetAxis("Horizontal");
        float Zmove = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * Xmove;
        Vector3 moveVertical = transform.forward * Zmove;

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;

        motor.Move(velocity);

        if (Input.GetMouseButton(0))
        {
            gun.par = this.transform;
            gun.shoot();
        }
	}
}
