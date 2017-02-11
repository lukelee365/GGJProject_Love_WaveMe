using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets.Characters.FirstPerson{

public class FireABeam : MonoBehaviour {
		
		public Transform origin;
		public float forceScaler;
		public float upForceScaler;
		public float connectRange;
		public float minRangeToDrop;
		public LayerMask interactionLayer;
		private Vector3 desPoint;
		private Rigidbody playerRg;
		public GameObject Lightningpref;
		public Texture2D crosshairTexture;
		public float scaler;
		public GameObject otherHeart;
		GameObject hitPeople = null;
		RigidbodyFirstPersonController playerScript;
		Rect position;
		bool connected;
		// Use this for initialization
		void Start () {
			otherHeart.SetActive (false);
			position = new Rect( ( Screen.width - crosshairTexture.width*scaler ) / 2, ( Screen.height - crosshairTexture.height*scaler ) / 2, crosshairTexture.width*scaler, crosshairTexture.height*scaler );
			playerRg = GetComponentInParent<Rigidbody> ();
			playerScript = GetComponentInParent<RigidbodyFirstPersonController> ();
		}
		
		// Update is called once per frame
		void Update () {
			RaycastHit hit ;

			if (Input.GetButtonDown ("Fire1")) {
				if (Physics.Raycast (transform.position, transform.forward, out hit, connectRange,interactionLayer)&&!connected) {
					//print ("Found an object - distance: " + hit.collider.name + hit.distance);
					connected = true;
					desPoint = hit.point;
					if(hit.collider.tag=="People")
					hitPeople = hit.collider.gameObject;
				}

				//rg.AddForce(Camera.main.transform.forward*force);
			}
			if (Input.GetButtonUp ("Fire1")) {
				connected = false;
				otherHeart.SetActive (false);
				playerScript.advancedSettings.airControl = true;
				playerRg.useGravity = true;
				//Disable other people's heart
				if (hitPeople != null) {

					HeartBeat otherHeartScript = hitPeople.GetComponent<HeartBeat> ();
					otherHeartScript.heart = null;
				}
				hitPeople = null;
				//lRend.SetPosition (1, origin.position);
			}
			//hit to listen to other people's heart
			if(hitPeople!=null){
				otherHeart.SetActive (true);
				HeartBeat otherHeartScript = hitPeople.GetComponent<HeartBeat> ();
				otherHeartScript.heart = otherHeart;
				otherHeartScript.heartAnim = otherHeart.GetComponent<Animator> ();
			}
	
			if (connected) {// connect to something
				playerScript.advancedSettings.airControl = false;
				playerRg.useGravity = false;
				//lighting
				GameObject ligthing = Instantiate(Lightningpref,this.transform.position, Quaternion.identity);
				LineRenderer lRender = ligthing.GetComponent<LineRenderer> ();
			
				lRender.SetPosition(0, origin.position);
				lRender.SetPosition(1, desPoint);
	//			Lightning lRender = ligthing.GetComponent<Lightning> ();
	//			lRender.origin = transform.position;
	//			lRender.dest = desPoint;

				Vector3 forceDir = desPoint- transform.position;
				Vector3.Normalize (forceDir);
				//playerRg.velocity = forceDir*speed;
				playerRg.AddForce(forceDir*forceScaler,ForceMode.Acceleration);
				if (Vector3.Distance (desPoint, transform.position) < minRangeToDrop) {
						
						playerScript.advancedSettings.airControl = true;
						playerRg.useGravity = true;
						playerRg.Sleep ();
						playerRg.WakeUp ();
					if(!playerScript.Grounded){//add force to land when on air
						playerRg.AddForce(transform.up*upForceScaler,ForceMode.Impulse);
						playerRg.AddForce(transform.forward*upForceScaler,ForceMode.Impulse);

					}
						//playerRg.AddForce(transform.up*upForceScaler,ForceMode.Impulse);
						connected = false;
				}
			}


		}
		void  OnGUI (){
			RaycastHit hit ;
			if (Physics.Raycast (transform.position, transform.forward, out hit, connectRange,interactionLayer)&&!connected) {
				GUI.DrawTexture(position, crosshairTexture);	
			}
		}


	}

}
