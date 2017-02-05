using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseConditionManager : MonoBehaviour {
	public int idexOfScene;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void GameOver() {
		Debug.Log ("Game Over");
		GetComponent<TimeManager> ().timeStart = Time.time;
		SceneManager.LoadScene (idexOfScene, LoadSceneMode.Single);
	}
}
