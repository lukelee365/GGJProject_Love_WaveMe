using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour {

	public GameObject checkPoint;
	public GameObject player;
	// Use this for initialization
	void Start () {
		StartCoroutine (Respawn(0f));
		//player.transform.position = checkPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void StoreCheckPoint(GameObject cp){
		checkPoint = cp;
	}

	/// <summary>
	/// Respawn Player
	/// </summary>
	/// <param name="t">T.</param>
	public IEnumerator Respawn(float t){
		yield return new WaitForSeconds (t);
		player.transform.position = checkPoint.transform.position;

	}
}
