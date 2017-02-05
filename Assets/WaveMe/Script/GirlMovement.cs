using UnityEngine;
using System.Collections;

public class GirlMovement : MonoBehaviour {

	public float speed = 5f;

	public Transform crowd;

	Transform randomPerson;

	public float timeWaveBackInSecond = 2f;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.gray;
		randomPerson = GetRandomPersonInCrowd ();
		InvokeRepeating ("ChangeRandomPersonToFollow", 0, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		MoveTowardRandomPerson ();
	}

	public void AlsoWave(){
		StartCoroutine (WaveBack (timeWaveBackInSecond));
	}

	Transform GetRandomPersonInCrowd() {
		int numberOfPeople = crowd.childCount;
		int randomPersonIndex = Random.Range (0, numberOfPeople);

		Transform randomPerson = crowd.GetChild (randomPersonIndex).GetChild(0);
		return randomPerson;
	}

	void ChangeRandomPersonToFollow(){
		this.randomPerson = GetRandomPersonInCrowd();
	}

	void MoveTowardRandomPerson() {
		transform.position = Vector3.MoveTowards (transform.position, randomPerson.position, speed * Time.deltaTime);
	}

	IEnumerator WaveBack(float second) {
		GetComponent<Renderer> ().material.color = Color.red;
		yield return new WaitForSeconds (second);
		GetComponent<Renderer> ().material.color = Color.gray;
	}
}
