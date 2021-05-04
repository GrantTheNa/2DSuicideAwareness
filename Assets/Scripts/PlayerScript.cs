using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	public Animator animator; 

	private CharacterController characterController;

	public float speed = 6;
	public float jumpSpeed = 8;
	public float gravity = 10;

	public float sprintMultiplier = 2;

	public int health = 100;
	public int maxHealth = 100;


	private Vector3 movementVector;

	private bool isOnLadder = false;

	public bool isDead = false;

	// Use this for initialization
	void Start () 
	{

		characterController = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () 
	{

		movementVector.x = Input.GetAxis("Horizontal");
		movementVector.x *= speed;

		if (Input.GetButton("Sprint"))
		{
			//multiply the movement vector with the sprint multiplier
			movementVector.x *= sprintMultiplier;
		}

		if (characterController.isGrounded)
		{
			if (Input.GetButton("Jump")) //if the player pushes jump
			{
				movementVector.y = jumpSpeed;
			}

				//if the player pushes sprint (Note remember to add "Sprint" buttons to the InputManager ie: Edit->ProjectSettings->Input) 


		}

		//check if player health is low and set isDead value
		if(health <= 0)
		{
			isDead = true;
		}
		else
		{
			isDead = false;
		}

		//if the player is within a ladder (if isOnLadder is true, they are within a ladder trigger)
		if (isOnLadder) 
		{
		//enable vertical movement
			movementVector.y = Input.GetAxis("Vertical");
			movementVector.y *= speed;

			movementVector.x = Input.GetAxis("Horizontal");
			movementVector.x *= speed;
		}

	movementVector.y -= gravity * Time.deltaTime;
	characterController.Move(movementVector * Time.deltaTime);
	}

	void OnTriggerEnter(Collider C)
	{
		//Check if player started touching the ladder
		if (C.gameObject.layer == LayerMask.NameToLayer ("Ladder")) {
			isOnLadder = true;
		}

	}

	void OnTriggerExit(Collider C)
	{
		//Check if player stopped touching the ladder
		if (C.gameObject.layer == LayerMask.NameToLayer ("Ladder")) {
			isOnLadder = false;
		}
		
	}


}
