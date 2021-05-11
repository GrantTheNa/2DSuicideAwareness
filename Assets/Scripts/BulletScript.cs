﻿using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public float lifetime = 100f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//when the bullet collides with something
	void OnCollisionEnter(Collision other){
		//check if the object it collides with has the tag "Shootable"
		if(other.gameObject.tag == "Shootable"){
			//destroy the shootable object
			SoundManager.PlaySound("Destroy");
			Destroy(other.gameObject);
			//destroy the bullet
			Destroy(gameObject);
		}
		
	}


	//when the bullet is first activated this awake function gets called
	void  Awake ()
	{
		//destroy the bullet after 1 seconds
		Destroy(gameObject, lifetime);
	}
}
