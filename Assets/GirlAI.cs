using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAI : MonoBehaviour {
	public GameObject[] wayPoints;
	public float speed;
	public float roseLeaveDist;
	private GameObject player;
	private int goalIndex;
	private Rigidbody rg; 


	// Use this for initialization
	void Start () {
		rg = GetComponent<Rigidbody> ();
		goalIndex =  0;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//Get to Way Point
		Chasing();
		NextWayPoints ();
		
	}
	/// <summary>
	/// Nexts the way points.
	/// </summary>
	void NextWayPoints(){
		float distBetwenPlayer = Vector3.Distance (player.transform.position, transform.position);
		//Player Approach
		if (distBetwenPlayer<=roseLeaveDist&&goalIndex<wayPoints.Length-1) {
			goalIndex++;	
		}

	}
	/// <summary>
	/// Chasing the goal.
	/// </summary>
	void Chasing(){
		float distBetweenwayPoint = Vector3.Distance(transform.position,wayPoints[goalIndex].transform.position);
		if (distBetweenwayPoint < 1) {
			rg.Sleep ();
			rg.WakeUp ();
		} else {
			Vector3 forceDir = wayPoints[goalIndex].transform.position - transform.position;
			Vector3.Normalize (forceDir);
			rg.AddForce (forceDir * speed, ForceMode.Acceleration);
		}
	}


}
