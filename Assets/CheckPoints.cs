using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour {

	private GameObject gameManger;
	private RespawnPlayer gMScript;
	public float timeToRespawn;

	void Start(){
		gameManger = GameObject.FindGameObjectWithTag ("GameManager");
		gMScript = gameManger.GetComponent<RespawnPlayer> ();
	}

	void OnTriggerEnter(Collider coll){
		//Debug.Log (coll.name);
		if (gMScript != null) {
			if (coll.tag == "CheckPoints") {
				gMScript.StoreCheckPoint (coll.gameObject);
			}
			if (coll.tag == "KillZone") {
				StartCoroutine (gMScript.Respawn (timeToRespawn));
			}
		}
		
	}
}
