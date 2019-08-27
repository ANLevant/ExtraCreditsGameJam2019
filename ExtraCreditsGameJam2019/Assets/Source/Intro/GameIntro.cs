using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameIntro : MonoBehaviour {

	private static int MAIN_MENU_SCENE_NUMBER = 1;

	private int sceneNumber = MAIN_MENU_SCENE_NUMBER;

	// Use this for initialization
	void Start () {
		if( sceneNumber == MAIN_MENU_SCENE_NUMBER){
			StartCoroutine(ToMainMenu() );
		}
	}

	IEnumerator ToMainMenu(){
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene(1);
	}
	
}
