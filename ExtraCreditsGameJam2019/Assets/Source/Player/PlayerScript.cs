using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public LoopableAudio loopableAudio;
	public Sprite  Damage2;
	public Sprite  Damage1;
	public int health =3;
	public bool isInSafeLane;
	public bool isInFastLane;
	public bool isInChallengeRoom;
	public bool isJumping;
	public LayerMask safeLaneLayer;
	public LayerMask fastLaneLayer;
	public LayerMask challengeRoomLayer;
	public JamBarScript jamBarScript;

	private float speed;
	private Rigidbody2D rigidBody2D;
	private GameObject playerSprite;
	private bool isInvinsible;
	private float invinsibleCounter;
	private float invinsibilityLapse = 1f;

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();	
		playerSprite = transform.Find("PlayerSprite").gameObject;	
	}

	void FixedUpdate() {

		isInSafeLane = Physics2D.Raycast(transform.position, transform.up, 0.1f, safeLaneLayer).collider != null;
		isInFastLane = Physics2D.Raycast(transform.position, transform.up, 0.1f, fastLaneLayer).collider != null;
		isInChallengeRoom = Physics2D.Raycast(transform.position, transform.up, 0.1f, challengeRoomLayer).collider != null;
		
		if(isInSafeLane)
		{
			speed = 2f;
			loopableAudio.ChangeMusic("SafeLaneMusic");
		}
		else if(isInFastLane)
		{
			speed = 5f;
			loopableAudio.ChangeMusic("FastLaneMusic");
		}
		else if(isInChallengeRoom){
			loopableAudio.ChangeMusic("ChallengeRoomMusic");
		}
		else{
			speed = 0f;
		}

		if(isInvinsible){
			invinsibleCounter += Time.deltaTime;
		}

		if(invinsibleCounter >= invinsibilityLapse){
			invinsibleCounter = 0;
			isInvinsible = false;
		}

		rigidBody2D.velocity = transform.up * speed;	
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButton("Horizontal")){
			transform.Rotate(0,0, -5f*Input.GetAxis("Horizontal"));
		}
		if(Input.GetButton("Jump")){
			isJumping = true;
			GetComponent<Animator>().SetBool("isJumping", true);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Bullet" && ! isJumping && !isInvinsible){
			health--;
			isInvinsible = true;
		}
		if(health == 2){
			playerSprite.GetComponent<SpriteRenderer>().sprite = Damage2;
	
		}
		if(health == 1){
			playerSprite.GetComponent<SpriteRenderer>().sprite = Damage1;
		}
		if(health == 0 ){
			//game over
		}
	}

	void Heal(double healAmmount){
		jamBarScript.SetSize((float)(jamBarScript.actualSize+healAmmount));
	}

	public void FinishJump(){
		GetComponent<Animator>().SetBool("isJumping", false);
		isJumping = false;
		Heal(0.5);
	}
}
