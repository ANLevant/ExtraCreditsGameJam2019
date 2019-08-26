using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamScript : MonoBehaviour {

	public PlayerScript player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(player.transform.position, transform.position) > 8){
			Destroy(transform.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerScript>().isJumping){
			Destroy(transform.gameObject);
		}
	}
}
