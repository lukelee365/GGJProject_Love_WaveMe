using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerGenerator : MonoBehaviour {
	public GameObject stranger;
	public int Row;
	public int Grid;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < Row; i++) {
			float newX = transform.position.x + i * 1.2f;
			for (int j = 0; j < Grid; j++) {
				float newZ = transform.position.z + j * 1.2f;
				GameObject newStranger = (GameObject)Instantiate (stranger, new Vector3 (newX, stranger.transform.position.y, newZ), Quaternion.identity); 
				newStranger.transform.parent = stranger.transform.parent;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
