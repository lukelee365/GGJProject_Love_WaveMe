using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		audioSources = GetComponents<AudioSource> ();

		AudioSource rainAudioSource = audioSources [0];
		rainAudioSource.PlayDelayed (2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
