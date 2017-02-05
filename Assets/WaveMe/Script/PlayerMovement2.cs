using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerMovement2 : MonoBehaviour {
	private Rigidbody rBody;
	public int LevelToGoTo;
	public float maxRespondTime;
	public float speed;
	public float heartBeatTime;
	public float minHearRate;
	public float maxHeartRate;
	public float maxDistBetweenTwo;
	public float slowMotionTime;
	public float normalSpeed;
	public float slowMotionSpeed;
	public float hearBeatToWave;
	public GameObject audioManager;
	public GameObject WaveFeedBack;
	private AudioSource heartBeatAudioSource;
	private GirlMovement girlMove;
	private GameObject girl;
	private GameObject heart;
	private Animator heartAnim;
	private bool canWave;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody> ();
		girl = GameObject.Find ("Rose");
		heart = GameObject.FindGameObjectWithTag ("Heart");
		heartAnim = heart.GetComponent<Animator> ();
		girlMove = girl.GetComponent<GirlMovement> ();
		StartCoroutine("HeartBeatFrequnecy");
		canWave = true;  
		WaveFeedBack.SetActive (false);
		AudioSource[] audioSources = audioManager.GetComponents<AudioSource> ();
		heartBeatAudioSource = audioSources [2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate(){
		if(Input.GetKeyDown(KeyCode.Space)&&canWave){
			float randomWaitTime = Random.Range (0, maxRespondTime);
			//Wave and cannot move
			if (DistBetween () < 3f) {
				girlMove.AlsoWave ();
				StartCoroutine("SlowMotion",slowMotionTime);
			}
//			RaycastHit[] hits;
//			hits = Physics.RaycastAll (transform.position, transform.forward, 100f);
//			for (int i = 0; i < hits.Length; i++) {
//				if (hits [i].transform.tag == "Rose") {
//					StartCoroutine("SlowMotion",slowMotionTime);
//				}
//			}
//			hits = Physics.RaycastAll (transform.position, Quaternion.AngleAxis(180, Vector3.up) * transform.forward, 100f);
//			for (int i = 0; i < hits.Length; i++) {
//				if (hits [i].transform.tag == "Rose") {
//					StartCoroutine("SlowMotion",slowMotionTime);
//				}
//			}
//			hits = Physics.RaycastAll (transform.position, transform.right, 100f);
//			for (int i = 0; i < hits.Length; i++) {
//				if (hits [i].transform.tag == "Rose") {
//					StartCoroutine("SlowMotion",slowMotionTime);
//				}
//			}
//			hits = Physics.RaycastAll (transform.position, Quaternion.AngleAxis(180, Vector3.up) * transform.right, 100f);
//			for (int i = 0; i < hits.Length; i++) {
//				if (hits [i].transform.tag == "Rose") {
//					StartCoroutine("SlowMotion",slowMotionTime);
//				}
//			}
			canWave = false;
			WaveFeedBack.SetActive (false);
		}

		//Movement Control
		float mouseInput = Input.GetAxis("Mouse X");
		Vector3 lookhere = new Vector3(0,mouseInput,0);
		transform.Rotate(lookhere);

		if (Input.GetKey (KeyCode.UpArrow)||Input.GetKey(KeyCode.W)) {
			//Back
			rBody.velocity = transform.forward*speed;
		}else if(Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S)){
			rBody.velocity = transform.forward*-speed;
		}else if(Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.A)){
			rBody.velocity = transform.right*-speed;
		}else if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D)){
			rBody.velocity = transform.right * speed;
		}

		ControlhearBeatTime ();
		//Debug.Log("Distance Between:  "+DistBetween());
		if (DistBetween () < 1.2f) {
			Debug.Log ("ReachEachOther Win");
		}
	}



	public float DistBetween(){
		return Vector3.Distance (transform.position,girl.transform.position);
	}

	// control the Time Frequency
	public void ControlhearBeatTime(){
		float dist;
		if (DistBetween() >= maxDistBetweenTwo) {
			dist = maxDistBetweenTwo;
		} else {
			dist = DistBetween ();
		}
		float r = Remap (dist/ maxDistBetweenTwo, 0, 1, minHearRate, maxHeartRate);
		heartBeatTime = r;

	}
	//ReMapValuefrom A range to another
	float Remap (float value, float from1, float to1, float from2, float to2) {
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

	IEnumerator WaveAndWait(float time) {
		Debug.Log("wave Hands by player");
		yield return new WaitForSeconds(time);
		girlMove.AlsoWave ();
	}

	IEnumerator SlowMotion(float time) {
		Debug.Log("wave Hands by player");
		girlMove.AlsoWave ();
		Time.timeScale = 0.2f;
		speed = slowMotionTime;
		yield return new WaitForSeconds(time);
		Time.timeScale = 1;
		speed = normalSpeed;
		SceneManager.LoadScene (LevelToGoTo, LoadSceneMode.Single);
	
	}

	IEnumerator HeartBeatFrequnecy() {
		float i = 0;
		while (true) {
			yield return new WaitForSeconds(heartBeatTime);

			heartAnim.SetTrigger ("HeartBeats");
			heartBeatAudioSource.Play ();

			i++;

			if (i >= hearBeatToWave) {
				canWave = true;
				WaveFeedBack.SetActive (true);
				i = 0;
			}

		}
		
	}
}
