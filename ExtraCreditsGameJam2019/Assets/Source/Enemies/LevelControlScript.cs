using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelControlScript : MonoBehaviour {

	private static Dictionary<float, EnemyBaseScript> ENEMY_PERCENTAGE_RATE;
	// Use this for initialization
	public List<EnemyBaseScript> enemyLists;
	public PlayerScript player;
	private bool isSpawning;
	void Start () {
		ENEMY_PERCENTAGE_RATE = new Dictionary<float, EnemyBaseScript>();

		for(int i = 0; i < enemyLists.Count; i++){
			ENEMY_PERCENTAGE_RATE.Add(1/(i+1), enemyLists[i]);
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if(!isSpawning && player.isInFastLane){
			StartCoroutine(SpawnEnemy());
		}
	}

	private IEnumerator SpawnEnemy(){
		isSpawning = true;
		WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(1f);
		yield return waitForSecondsRealtime;
		if(PercentageUniformProbability() < 0.2){
			float enemyToGeneratePercentageRange = PercentageUniformProbability();
			for(int i = 0; i < ENEMY_PERCENTAGE_RATE.Count; i++){
				float key = ENEMY_PERCENTAGE_RATE.Keys.ElementAt(i);
				if(enemyToGeneratePercentageRange <= key){
					Vector3 startingPosition = player.transform.position;
					startingPosition = startingPosition + (player.transform.up*7);
					Instantiate(ENEMY_PERCENTAGE_RATE[key], startingPosition, Quaternion.identity).player = player;
					
				}
			}
		}
		isSpawning = false;
	}

	private float PercentageUniformProbability(){
		System.Random rand = new System.Random();
		float generatedNumber = rand.Next(0,100);
		return generatedNumber/100;
	}
}
