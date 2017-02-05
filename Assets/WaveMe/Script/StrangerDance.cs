using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerDance : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		InvokeRepeating ("RandomDance",0f,3f);
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void RandomDance(){
		int r = Random.Range (0, 5);
		anim.SetInteger ("Dance", r);
	}

}
