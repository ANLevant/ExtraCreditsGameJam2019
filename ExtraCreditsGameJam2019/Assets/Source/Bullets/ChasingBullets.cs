using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBullets : BulletBaseScript {
	public float speed;

	// Use this for initialization
	new public void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	new public void Update () {
		base.Update();
		base.RotateTowards();
		base.rigidBody2D.velocity = transform.up*speed;
	}
}
