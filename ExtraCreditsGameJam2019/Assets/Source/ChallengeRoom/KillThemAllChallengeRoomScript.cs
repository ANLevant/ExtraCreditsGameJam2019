using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThemAllChallengeRoomScript : ChallengeRoom {

	// Use this for initialization
	public new void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public new void Update () {
		base.Update();
	}

	public override bool FinishCondition(){
		if(transform.childCount == 0){
			Debug.Log("Finished!");
			return true;
		}
		else{
			return false;
		}
	}
}
