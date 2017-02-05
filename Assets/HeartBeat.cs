using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour {
	private AudioSource heartBeatAudioSource;
	private GameObject heart;
	private Animator heartAnim;
	public float heartBeatTime;
	public float minHearRate;
	public float maxHeartRate;
	public float maxDistBetweenTwo;
	private GameObject girl;
	// Use this for initialization
	void Start () {
		girl = GameObject.Find ("Rose");
		heart = GameObject.FindGameObjectWithTag ("Heart");
		AudioSource[] audioSources = GameObject.Find("AudioManager").GetComponents<AudioSource> ();
		heartBeatAudioSource = audioSources [2];
		heartAnim = heart.GetComponent<Animator> ();
		StartCoroutine("HeartBeatFrequnecy");
	}
	
	// Update is called once per frame
	void Update () {
		ControlhearBeatTime ();
	}


	public float DistBetween(){
		return Vector3.Distance (transform.position,girl.transform.position);
	}

	// control the Time Frequency
	public void ControlhearBeatTime(){
		float dist;
		if (DistBetween() >= maxDistBetweenTwo) {
			dist = maxDistBetweenTwo;
		} else {
			dist = DistBetween ();
		}
		float r = Remap (dist/ maxDistBetweenTwo, 0, 1, minHearRate, maxHeartRate);
		heartBeatTime = r;

	}
	//ReMapValuefrom A range to another
	float Remap (float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	IEnumerator HeartBeatFrequnecy() {
		float i = 0;
		while (true) {
			yield return new WaitForSeconds(heartBeatTime);

			heartAnim.SetTrigger ("HeartBeats");
			heartBeatAudioSource.Play ();

		

		}

	}
}
