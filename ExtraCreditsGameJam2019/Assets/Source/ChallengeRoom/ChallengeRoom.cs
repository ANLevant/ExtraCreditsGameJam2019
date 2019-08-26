using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChallengeRoom : MonoBehaviour {

	public GameObject keyToSpawn;
	public PlayerScript player;
	bool isFinished;
	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
		if(FinishCondition() && !isFinished){
			Vector3 spawnPosition = player.transform.position;
			spawnPosition.y -= 2;
			Instantiate(keyToSpawn, spawnPosition, Quaternion.identity);
			isFinished = true;
		}
	}

	public abstract bool FinishCondition();
}
