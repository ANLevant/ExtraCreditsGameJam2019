using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToMainMenu : MonoBehaviour {

	void Start () {
		StartCoroutine(ToMainMenu() );
	}

	IEnumerator ToMainMenu(){
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene(2);
	}

	private void Update() {
		if(Input.anyKey){
			ToMainMenu();
		}
	}

	void ToMainMenuImmidiatley(){
		SceneManager.LoadScene(2);
	}
	
}
