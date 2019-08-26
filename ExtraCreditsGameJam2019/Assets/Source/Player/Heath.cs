using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Heath : MonoBehaviour

{

	public Sprite  Damage2;
	public Sprite  Damage3;
	public int Health =3;

	float speed;
	int damage=1;

	public bool isInSafeLane = false;
	public bool isInFastLane = false;
	Rigidbody2D rigidBody2D;
	public LayerMask safeLaneLayer;
	public LayerMask fastLaneLayer;
	public JamBarScript jamBarScript;
	

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		print(Health);
	}

	void onCollision(Collision _collision){
			if(_collision.gameObject.tag=="Enemy"){
					print("au");
			}
	}
	// Update is called once per frame
	void Update () {
		if(Health == 2){
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Damage3;
	
		}
		if(Health == 3){
			this.gameObject.GetComponent<SpriteRenderer>().sprite = Damage2;
	
		}
	}

}
