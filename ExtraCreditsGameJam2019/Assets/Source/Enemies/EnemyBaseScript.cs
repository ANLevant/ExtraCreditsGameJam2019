using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseScript : MonoBehaviour {

	public GameObject bullet;
	public int bulletCount;
	public int hitPoints;
	public float fireRate;
	public PlayerScript player;
	public bool isStatic;
	public List<GameObject> dropableList;

	protected Rigidbody2D rigidBody2D;
	protected float timeCounter;
	protected bool isFiring;

	private bool isInvinsible;
	private float invinsibleCounter;
	private float invinsibilityLapse = 1f;

	// Use this for initialization
	public void Start () {
		rigidBody2D = GetComponent<Rigidbody2D>();
		hitPoints = 3;
	}
	
	// Update is called once per frame
	public void Update () {
		if(hitPoints <= 0)
		{
			Destroy(this.gameObject);
		}
		if(!isFiring){
			StartCoroutine(Fire());
		}
		if(Vector2.Distance(player.transform.position, transform.position) > 10 && !isStatic){
			Destroy(this.gameObject);
		}
		if(isInvinsible){
			invinsibleCounter += Time.deltaTime;
		}
		if(invinsibleCounter >= invinsibilityLapse){
			invinsibleCounter = 0;
			isInvinsible = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Bullet" && !isInvinsible){
			hitPoints--;
			isInvinsible = true;
		}
		else if(other.gameObject.tag == "SafeLane"){
			for(int i = 0; i < dropableList.Count; i++){
				Instantiate(dropableList[i], transform.position, Quaternion.identity);
			}
			Destroy(this.gameObject);
		}
	}

	protected void RotateTowards(){
		var offset = -90f;
     	Vector2 direction = player.transform.position - transform.position;
    	direction.Normalize();
    	float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;       
    	transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}

	public virtual IEnumerator Fire(){
		if(timeCounter <= 0){
			isFiring = true;
			for(int i = 0; i < bulletCount; i++){
				BulletBaseScript firedBullet = Instantiate(bullet, transform.position, Quaternion.identity).transform.Find("BulletSprite").GetComponent<BulletBaseScript>();
				firedBullet.player = player;
				WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(0.1f);
				yield return waitForSecondsRealtime;
			}
			isFiring = false;
			timeCounter = fireRate;
		}
		timeCounter -= Time.deltaTime;

	}
}
