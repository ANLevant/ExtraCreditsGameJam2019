using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBaseScript : MonoBehaviour {

	protected Rigidbody2D rigidBody2D;

	Renderer bulletRenderer;
	public PlayerScript player;

	// Use this for initialization
	public void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		bulletRenderer = GetComponent<Renderer>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "SafeLane" || other.gameObject.tag == "Enemy"){
			Destroy(this.gameObject.transform.parent.gameObject);
		}
		else if(other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerScript>().isJumping){
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}
	
	// Update is called once per frame
	public void Update () {
		if(!bulletRenderer.isVisible){
			Destroy(this.gameObject.transform.parent.gameObject);
		}
	}

	protected void RotateTowards(){
		var offset = -90f;
     	Vector2 direction = player.transform.position - transform.position;
    	direction.Normalize();
    	float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
    	transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}

}
