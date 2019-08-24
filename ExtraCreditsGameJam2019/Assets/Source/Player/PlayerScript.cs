using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	float speed;
	bool isInSafeLane = false;
	Rigidbody2D rigidBody2D;
	public LayerMask safeLaneLayer;
	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		
	}

	void FixedUpdate() {

		isInSafeLane = Physics2D.Raycast(transform.position, Vector2.down, 10f, safeLaneLayer).collider != null;
		
		if(isInSafeLane)
		{
			Debug.Log("Is in safe lane");
			speed = 2f;
		}
		else
		{
			Debug.Log("Is outside safe lane");
			speed = 5f;
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
