using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralBullet : MonoBehaviour {

	float xOscilation;
	float circleSpeed = 7f;
	private float spiralTurnVariable = 1;
	Rigidbody2D rigidBody2D;

	Renderer bulletRenderer;

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		bulletRenderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!bulletRenderer.isVisible){
			Destroy(this.gameObject.transform.parent.gameObject);
		}
		rigidBody2D.velocity = new Vector3(Mathf.Cos(spiralTurnVariable * circleSpeed)*(circleSpeed+xOscilation), Mathf.Sin(spiralTurnVariable * circleSpeed)*(circleSpeed+xOscilation), 0);

		xOscilation += 0.2f;
		spiralTurnVariable += Time.deltaTime;
	}

}
