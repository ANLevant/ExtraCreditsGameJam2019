using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseScript : MonoBehaviour {

	public Rigidbody2D rigidBody2D;

	Renderer bulletRenderer;

	// Use this for initialization
	public void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		bulletRenderer = GetComponent<Renderer>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "SafeLane" || other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}
	
	// Update is called once per frame
	public void Update () {
		if(!bulletRenderer.isVisible){
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}

}
