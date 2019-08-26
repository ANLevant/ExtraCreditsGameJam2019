using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralBullet : BulletBaseScript {
	float xOscilation;
	float circleSpeed = 7f;
	private float spiralTurnVariable = 1;
	// Use this for initialization
	new public void Start () {
    	base.Start();
	}	
	// Update is called once per frame
	new public void Update () {
		base.Update();
		base.rigidBody2D.velocity = new Vector3(Mathf.Cos(spiralTurnVariable * circleSpeed)*(circleSpeed+xOscilation), Mathf.Sin(spiralTurnVariable * circleSpeed)*(circleSpeed+xOscilation), 0);

		xOscilation += 0.3f;
		spiralTurnVariable += Time.deltaTime;
	}
}
