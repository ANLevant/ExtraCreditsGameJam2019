using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBulletScript : BulletBaseScript {
	public float speed;
	public float off;
	
	new public void Start(){
		base.Start();
		base.RotateTowards();
	}
	// Update is called once per frame
	new public void Update () {
		base.Update();
		base.rigidBody2D.velocity = transform.up*speed;
	}
}