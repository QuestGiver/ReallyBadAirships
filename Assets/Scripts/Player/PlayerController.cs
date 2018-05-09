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

        Vector3 moveHorizontal = Vector3.zero;
        Vector3 moveVertical = Vector3.zero;

        //if (transform.position.x < Mathf.Clamp(10, 20, 20))
        //    moveHorizontal = transform.right * Xmove;
        //if(transform.position.z < Mathf.Clamp(10, 20, 20))
        //    moveVertical = transform.forward * Zmove;

        moveHorizontal = transform.right * Xmove;
        moveVertical = transform.forward * Zmove;

        Vector3 velocity = (moveHorizontal + moveVertical) * speed;

        motor.Move(velocity);

        if (Input.GetMouseButton(0))
        {
            if (CommonAccessibles.CurrentGameState == CommonAccessibles.GameState.FIGHTMODE)
            {
                gun.par = this.transform;
                gun.shoot();
            }
        }
	}
}
