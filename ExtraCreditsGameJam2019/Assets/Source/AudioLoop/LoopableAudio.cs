using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopableAudio : MonoBehaviour {


	AudioSource myAudio;
	/**Perfect looping points for different songs:
	* Smooth: 6 - 66 */
	public float loopStart, loopEnd;
	
	// Use this for initialization
	void Start(){
		myAudio = GetComponent<AudioSource>();
		myAudio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (myAudio.isPlaying && myAudio.time >= loopEnd) {
			myAudio.time = loopStart;
		}		
	}
}
