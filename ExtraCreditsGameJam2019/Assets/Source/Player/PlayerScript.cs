using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public LoopableAudio loopableAudio;
	public Sprite  Damage3;
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
	private bool isStuck;
	private List<GameObject> foundKeys;

	// Use this for initialization
	void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();	
		playerSprite = transform.Find("PlayerSprite").gameObject;
		foundKeys = new List<GameObject>();
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
			speed = 5f;
			loopableAudio.ChangeMusic("ChallengeRoomMusic");
		}
		else{
			SceneManager.LoadScene(2, LoadSceneMode.Single);
		}

		if(isStuck){
			speed = -10f;
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
		if(Input.GetButton("Jump") && !isJumping){
			StartCoroutine(Jump());
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag=="Door"){
			isStuck = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag=="Bullet" && !isJumping && !isInvinsible){
			health--;
			isInvinsible = true;
		}
		else if(other.gameObject.tag=="Jam" && !isJumping){
			Heal(0.3);
		}
		else if(other.gameObject.tag=="Door"){
			DoorScript doorScript = other.gameObject.GetComponent<DoorScript>();
			bool hasKey = false;
			if(doorScript != null){
				for(int i = 0; i < foundKeys.Count; i++){
					KeyScript keyScript = foundKeys[i].GetComponent<KeyScript>();
					if(doorScript.keyColorToOpen == keyScript.color){
						hasKey = true;
						Destroy(keyScript.gameObject);
					}
				}

				if(hasKey){
					doorScript.Open();
				}
				else{
					isStuck = true;
				}
			}
		}

		if(health == 3){
			playerSprite.GetComponent<SpriteRenderer>().sprite = Damage3;
		}
		if(health == 2){
			playerSprite.GetComponent<SpriteRenderer>().sprite = Damage2;
		}
		if(health == 1){
			playerSprite.GetComponent<SpriteRenderer>().sprite = Damage1;
		}
		if(health == 0 ){
			SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
	}

	void Heal(double healAmmount){
		health = 3;
		jamBarScript.SetSize((float)(jamBarScript.actualSize+healAmmount));
	}

	public IEnumerator Jump(){
		isJumping = true;
		WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(0.1f);
		yield return waitForSecondsRealtime;
		GetComponent<Animator>().SetBool("isJumping", true);
	}
	public void FinishJump(){
		GetComponent<Animator>().SetBool("isJumping", false);
		isJumping = false;
	}

	public void AddKey(GameObject key){
		foundKeys.Add(key);
	}
}
