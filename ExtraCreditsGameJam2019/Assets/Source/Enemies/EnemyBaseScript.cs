using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour {

	public GameObject bullet;
	public int bulletCount;
	public int hitPoints;
	public float fireRate;
	private float timeCounter;
	private bool isFiring;
	public PlayerScript player;
	public bool isStatic;

	// Use this for initialization
	public void Start () {
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
		Debug.Log("Collide! "+other.gameObject.tag);
		if(other.gameObject.tag == "Bullet"){
			hitPoints--;
		}
	}

	IEnumerator Fire(){
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
