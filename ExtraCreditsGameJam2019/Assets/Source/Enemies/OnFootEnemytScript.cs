using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFootEnemytScript : EnemyBaseScript {
	float speed = 1f;
	// Use this for initialization
	new public void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	new public void Update () {
		base.Update();
		base.RotateTowards();
		if(Vector2.Distance(player.transform.position, transform.position) > 3){
			base.rigidBody2D.velocity = transform.up*speed;
		}
		else{
			base.rigidBody2D.velocity = Vector2.zero;
		}
	}
}
