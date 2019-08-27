using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour {

	public string keyColorToOpen;
	public bool isDoorToNextLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Open(){
		Destroy(transform.gameObject);
		if(isDoorToNextLevel){
			SceneManager.LoadScene(3, LoadSceneMode.Single);
		}
	}
}
