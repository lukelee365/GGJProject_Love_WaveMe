using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour {
	public Transform goal;

	public Transform player;
	public Transform rose;

	// Boundary coordination
	public float minX = -20;
	public float minZ = -20;
	public float maxX = 20;
	public float maxZ = 20;

	public float step;

	public float minimumDistanceToPush = 15f;
	public float distanceToPush = 5f;

	// Use this for initialization
	void Start () {

		// Change Direction Randomly every 3 seconds
		InvokeRepeating("ChangeDirection", 0, 3);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 destination = new Vector3 (goal.position.x, transform.position.y, goal.position.z);
		transform.position = Vector3.MoveTowards (transform.position, destination, step * Time.deltaTime);
	}

	void ChangeDirection() {
		float distanceBetweenPlayers = player.GetComponent<PlayerMovement> ().DistBetween ();

		float distanceToPlayer = DistanceBetween (transform, player);

		//Debug.Log (distanceBetweenPlayers);

		if (distanceBetweenPlayers <= minimumDistanceToPush && distanceToPlayer <= distanceToPush) {
			//Debug.Log ("Pushing Away");
			bool isPushingAway = Random.value > 0.8 ? true : false;

			if (isPushingAway) {
				ChangeColor (Color.blue);
				PushPlayerAway ();
			} else {
				ChangeRandomDirection ();
				ChangeColor (Color.gray);
			}
		} else {
			ChangeRandomDirection ();
			ChangeColor (Color.gray);
		}
	}

	void ChangeRandomDirection() {
		// Get coordination of random destination within the bound
		float randomX = Random.Range (minX, maxX);
		float randomZ = Random.Range (minZ, maxZ);

		goal.position = new Vector3 (randomX, 0, randomZ);

	}

	Vector3 DirectionBetween(Transform objectA, Transform objectB) {
		return (objectA.position - objectB.position);
	}

	float DistanceBetween(Transform objectA, Transform objectB) {
		return Vector3.Distance (objectA.position, objectB.position);
	}

	void PushPlayerAway() {
		Vector3 directionToRose = DirectionBetween (player, rose);
		goal.position = directionToRose * 2; 
	}

	void ChangeColor(Color color) {
		GetComponent<Renderer> ().material.color = color;
	}
}
