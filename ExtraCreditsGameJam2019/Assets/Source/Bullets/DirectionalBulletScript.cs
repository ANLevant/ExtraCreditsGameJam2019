using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBulletScript : BulletBaseScript {
	public float speed;
	public float off;
	public PlayerScript player;
	
	new public void Start(){
		base.Start();
		RotateTowards();
	}
	// Update is called once per frame
	new public void Update () {
		base.Update();
		base.rigidBody2D.velocity = transform.up*speed;
	}

	protected void RotateTowards(){
		var offset = -90f;
     	Vector2 direction = player.transform.position - transform.position;
    	direction.Normalize();
    	float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
    	transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}
}