using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour {

	public GameObject bullet;
	public int bulletCount;
	public int hitPoints;

	public float fireRate;
	private float timeCounter;
	public PlayerScript playerScript;

	private bool isFiring;

	// Use this for initialization
	public void Start () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
	}
	
	// Update is called once per frame
	public void Update () {
		if(!isFiring){
			StartCoroutine(Fire());
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
