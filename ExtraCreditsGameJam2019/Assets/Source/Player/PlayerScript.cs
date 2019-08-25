﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	float speed;
	public bool isInSafeLane = false;
	public bool isInFastLane = false;
	Rigidbody2D rigidBody2D;
	public LayerMask safeLaneLayer;
	public LayerMask fastLaneLayer;
	public JamBarScript jamBarScript;
	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();		
	}

	void FixedUpdate() {

		isInSafeLane = Physics2D.Raycast(transform.position, transform.up, 0.1f, safeLaneLayer).collider != null;
		isInFastLane = Physics2D.Raycast(transform.position, transform.up, 0.1f, fastLaneLayer).collider != null;
		
		if(isInSafeLane)
		{
			speed = 2f;
		}
		else if(isInFastLane)
		{
			speed = 5f;
		}
		else{
			speed = 0f;
		}

		rigidBody2D.velocity = transform.up * speed;	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Horizontal")){
			transform.Rotate(0,0, -5f*Input.GetAxis("Horizontal"));
		}
		if(Input.GetButton("Jump")){
			GetComponent<Animator>().SetBool("isJumping", true);
		}
	}

	void Heal(double healAmmount){
		jamBarScript.SetSize((float)(jamBarScript.actualSize+healAmmount));
	}

	public void FinishJump(){
		GetComponent<Animator>().SetBool("isJumping", false);
		Heal(0.5);
	}
}