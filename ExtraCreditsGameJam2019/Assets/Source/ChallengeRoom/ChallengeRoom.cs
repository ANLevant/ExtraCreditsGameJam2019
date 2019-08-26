using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChallengeRoom : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
		if(FinishCondition()){
		}
	}

	public abstract bool FinishCondition();
}
