using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public float speed;

    private PlayerMotor motor;

	void Start ()
    {
        motor = GetComponent<PlayerMotor>();
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
	}
}
