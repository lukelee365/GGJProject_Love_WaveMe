using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TimeManager : MonoBehaviour {
	public float timeLimitInSecond;
	public GameObject roseHeart;

	private float colorChangeStep;

	public float timeStart = 0;

	// Use this for initialization
	void Start () {
		timeStart = Time.time;
		colorChangeStep = 1/timeLimitInSecond;
		InvokeRepeating ("fadeHeart", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;

		float timeDifference = currentTime - timeStart;

		if (timeDifference >= timeLimitInSecond) {
			GetComponent<LoseConditionManager> ().GameOver ();
		}

//		Debug.Log (roseHeart.GetComponent<SpriteRenderer>().material.color);

	}

	void fadeHeart() {
		float r = roseHeart.GetComponent<SpriteRenderer> ().material.color.r;
		float g = roseHeart.GetComponent<SpriteRenderer> ().material.color.g;
		float b = roseHeart.GetComponent<SpriteRenderer> ().material.color.b;
		float a = roseHeart.GetComponent<SpriteRenderer> ().material.color.a;

		if (a >= 0) {
			a -= colorChangeStep;
		}

		roseHeart.GetComponent<SpriteRenderer> ().material.color = new Color (r, g, b, a);
	}

//	public IEnumerator FadeSprite(SpriteRenderer target, float duration, Color color)
//	{
//		if (target==null)
//			yield break;
//
//		float alpha = target.material.color.a;
//
//		float t=0f;
//		while (t<1.0f)
//		{
//			if (target==null)
//				yield break;
//
//			Color newColor = new Color(color.r, color.g, color.b, Mathf.SmoothStep(alpha,color.a,t));
//			target.material.color=newColor;
//
//			t += Time.deltaTime / duration;
//
//			yield return null;
//
//		}
//		Color finalColor = new Color(color.r, color.g, color.b, Mathf.SmoothStep(alpha,color.a,t));
//		target.material.color=finalColor;
//	}
}
