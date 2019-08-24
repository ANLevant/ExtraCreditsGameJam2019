using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	float speed;
	float jamBar = 1f;
	bool isInSafeLane = false;
	bool isInFastLane = false;
	Rigidbody2D rigidBody2D;
	public LayerMask safeLaneLayer;
	public LayerMask fastLaneLayer;
	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		
	}

	void FixedUpdate() {

		isInSafeLane = Physics2D.Raycast(transform.position, transform.up, 30f, safeLaneLayer).collider != null;
		isInFastLane = Physics2D.Raycast(transform.position, transform.up, 30f, fastLaneLayer).collider != null;
		
		if(isInSafeLane)
		{
			Debug.Log("Is in safe lane");
			speed = 2f;
		}
		else if(isInFastLane)
		{
			Debug.Log("Is in fast lane");
			speed = 5f;
		}
		else{
			Debug.Log("Outside the map");
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
			Debug.Log("Jumping!");
			GetComponent<Animator>().SetBool("isJumping", true);
		}
	}

	public void FinishJump(){
		GetComponent<Animator>().SetBool("isJumping", false);
	}
}
