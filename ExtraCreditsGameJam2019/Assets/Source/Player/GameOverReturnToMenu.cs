using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverReturnToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	private void Update() {
		if(Input.anyKey){
			ToGame();
		}
	}

	void ToGame(){
		SceneManager.LoadScene(3);
	}
}
