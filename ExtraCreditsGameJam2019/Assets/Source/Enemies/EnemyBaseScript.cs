using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseScript : MonoBehaviour {

	public GameObject bullet;
	public int bulletCount;
	public int hitPoints;
	public float fireRate;
	protected float timeCounter;
	protected bool isFiring;
	public PlayerScript player;
	public bool isStatic;
	protected Rigidbody2D rigidBody2D;

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
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Bullet"){
			hitPoints--;
		}
		else if(other.gameObject.tag == "SafeLane"){
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
				Instantiate(bullet, transform.position, Quaternion.identity, transform);
				WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(0.1f);
				yield return waitForSecondsRealtime;
			}
			isFiring = false;
			timeCounter = fireRate;
		}
		timeCounter -= Time.deltaTime;

	}
}
