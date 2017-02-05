using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeOut : MonoBehaviour {

	public float fadeOutTime;
	public AudioSource heartBeatSound;
	// Use this for initialization
	void Start () {
		StartCoroutine(FadeTextToZeroAlpha(fadeOutTime, gameObject.GetComponentInChildren<Text>()));
		StartCoroutine(FadeImgToZeroAlpha(fadeOutTime,GetComponent<Image>() ));
		StartCoroutine(FadeAudioToOne(fadeOutTime,heartBeatSound));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator FadeTextToZeroAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}

	public IEnumerator FadeAudioToOne(float t, AudioSource i)
	{
		i.volume = 0;
		while (i.volume < 1.0f)
		{
			i.volume = i.volume+(Time.deltaTime / t);
			yield return null;
		}
	}
	public IEnumerator FadeImgToZeroAlpha(float t, Image i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
		while (i.color.a > 0.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
			yield return null;
		}
	}
}
