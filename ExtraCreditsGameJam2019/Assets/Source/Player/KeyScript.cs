using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

	public string color;
	private bool isGrabbed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerScript>().isJumping){
			transform.parent = other.transform;
			other.gameObject.GetComponent<PlayerScript>().AddKey(gameObject);
			isGrabbed = true;
		}
	}
}
