using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopableAudio : MonoBehaviour {


	AudioSource audioSouce;
	public List<AudioClip> audioClips;
	public List<string> audioClipNames;
	public List<int> loopStartPoints;
	public List<int> loopEndPoints;
	Dictionary<AudioClip, int[]> timeLoops = new Dictionary<AudioClip, int[]>();
	Dictionary<string, AudioClip> audioClipsByName = new Dictionary<string, AudioClip>();
	/**Perfect looping points for different songs:
	* Smooth: 6 - 66 */
	float loopStart, loopEnd;
	
	// Use this for initialization
	void Start(){
		for(int i = 0; i < audioClips.Count; i++){
			audioClipsByName.Add(audioClipNames[i], audioClips[i]);
			int[] timeLoop = new int[2];
			timeLoop[0] = loopStartPoints[i];
			timeLoop[1] = loopEndPoints[i];
			timeLoops.Add(audioClips[i], timeLoop);
		}
		audioSouce = GetComponent<AudioSource>();
		audioSouce.Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (audioSouce.isPlaying && audioSouce.time >= loopEnd) {
			audioSouce.time = loopStart;
		}		
	}

	public void ChangeMusic(string clipName){
		AudioClip audioClip = audioClipsByName[clipName];
		int[] timeLoop = timeLoops[audioClip];

		loopStart = timeLoop[0];
		loopEnd = timeLoop[1];

		if(audioSouce.clip != audioClip){
			audioSouce.clip = audioClip;
			audioSouce.Play();
		}
		
	}
}
