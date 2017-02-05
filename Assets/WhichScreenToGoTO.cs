using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WhichScreenToGoTO : MonoBehaviour {
	public int index;
	public int index2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PressButtonFirst(){
		SceneManager.LoadScene (index, LoadSceneMode.Single);
	}
	public void PressButtonSecond(){
		SceneManager.LoadScene (index2, LoadSceneMode.Single);
	}
}
