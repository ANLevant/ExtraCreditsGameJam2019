using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

	void Start()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	private void Awake() {
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Intro");

		if(objects.Length > 1){
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		Debug.Log(scene.name);
		if(scene.name == "MainMenu" || scene.name == "FirstLevel"){
			Destroy(this.gameObject);
		}
	}
}