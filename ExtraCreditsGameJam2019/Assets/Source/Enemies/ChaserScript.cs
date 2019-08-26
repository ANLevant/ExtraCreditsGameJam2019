using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : EnemyBaseScript {

	float speed = 7f;
	// Update is called once per frame
	new public void Update () {
		base.Update();
		RotateTowards();

		if(Vector2.Distance(player.transform.position, transform.position) > 3){
			base.rigidBody2D.velocity = Vector2.MoveTowards(transform.position, player.transform.position, speed);
		}
		base.rigidBody2D.velocity = transform.right * 5f;
	}

	public override IEnumerator Fire(){
		if(base.timeCounter <= 0){
			base.isFiring = true;
			for(int i = 0; i < bulletCount; i++){
				Vector3 firstBulletPosition = transform.position + transform.up;
				firstBulletPosition.x -= 0.5f;
				Vector3 secondBulletPosition = transform.position + transform.up;
				Vector3 thirdBulletPosition = transform.position + transform.up;
				thirdBulletPosition.x += 0.5f;

				DirectionalBulletScript firstBullet = Instantiate(bullet, firstBulletPosition, Quaternion.Euler(0,0,45)).transform.Find("BulletSprite").GetComponent<DirectionalBulletScript>();
				firstBullet.player = player;
				firstBullet.off = -45;
				DirectionalBulletScript secondBullet = Instantiate(bullet, secondBulletPosition, Quaternion.identity).transform.Find("BulletSprite").GetComponent<DirectionalBulletScript>();
				secondBullet.player = player;
				DirectionalBulletScript thirdBullet = Instantiate(bullet, thirdBulletPosition, Quaternion.Euler(0,0,-45)).transform.Find("BulletSprite").GetComponent<DirectionalBulletScript>();
				thirdBullet.player = player;
				thirdBullet.off = 45;

				WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(0.1f);
				yield return waitForSecondsRealtime;
			}
			base.isFiring = false;
			base.timeCounter = fireRate;
		}
		base.timeCounter -= Time.deltaTime;

	}

}
