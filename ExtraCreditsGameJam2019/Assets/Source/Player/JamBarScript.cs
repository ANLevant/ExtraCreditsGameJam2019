
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class JamBarScript : MonoBehaviour {

	private Transform bar;
	public double actualSize = 1f;
	private float timeMeasure = 0f;

	// Use this for initialization
	private void Start () {
		bar = transform.Find("Bar");
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate() {
		timeMeasure += Time.deltaTime;
		if(actualSize <= 0){
			SceneManager.LoadScene(2, LoadSceneMode.Single);
		}
		if(actualSize > 0 && timeMeasure > 2){
			SetSize((float)Math.Round(actualSize - 0.05, 2));
			timeMeasure = 0;
		}
	}

	public void SetSize(float sizeNormalized){
		if(sizeNormalized <= 1f){
			if(actualSize > sizeNormalized){
				bar.Translate(0.106f ,0, 0);
			}
			else{
				double difference = sizeNormalized - actualSize;
				bar.Translate((float)((difference/0.05)*-0.106) ,0, 0);
			}
			actualSize = sizeNormalized;
			bar.localScale = new Vector3((float)actualSize, 1f);
		}
		else{
			actualSize = 1f;
			bar.localScale = new Vector3((float)actualSize, 1f);
			bar.localPosition = new Vector3(-2.5f , 0, 0);
		}
	}
}
