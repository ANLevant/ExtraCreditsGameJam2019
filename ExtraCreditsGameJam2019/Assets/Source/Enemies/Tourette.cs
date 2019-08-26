using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourette : EnemyBaseScript {

	public Sprite  Damage1;
	private GameObject enemySprite;
    // Update is called once per frame
	new void Start(){
		base.Start();
		enemySprite = transform.Find("Enemy").gameObject;
	}
    new void Update () {
		base.Update();
		if(hitPoints == 1){
			enemySprite.GetComponent<SpriteRenderer>().sprite = Damage1;
		}
		RotateTowards();
	}
}