using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireABeam : MonoBehaviour {
	
	public Transform origin;
	public float speed;
	public float connectRange;
	public float minRangeToDrop;
	public LayerMask interactionLayer;
	private Vector3 desPoint;
	private Rigidbody playerRg;
	public GameObject Lightningpref;
	public Texture2D crosshairTexture;
	public float scaler;
	Rect position;
	bool connected;
	// Use this for initialization
	void Start () {
		position = new Rect( ( Screen.width - crosshairTexture.width*scaler ) / 2, ( Screen.height - crosshairTexture.height*scaler ) / 2, crosshairTexture.width*scaler, crosshairTexture.height*scaler );
		playerRg = GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit ;

		if (Input.GetButtonDown ("Fire1")) {
			if (Physics.Raycast (transform.position, transform.forward, out hit, connectRange,interactionLayer)&&!connected) {
				//print ("Found an object - distance: " + hit.collider.name + hit.distance);
				connected = true;
				desPoint = hit.point;
			}
			//rg.AddForce(Camera.main.transform.forward*force);
		}
		if (Input.GetButtonUp ("Fire1")) {
			connected = false;
			//lRend.SetPosition (1, origin.position);
		}
		if (connected) {
			
			GameObject ligthing = Instantiate(Lightningpref,this.transform.position, Quaternion.identity);
			LineRenderer lRender = ligthing.GetComponent<LineRenderer> ();
			lRender.SetPosition(0, origin.position);
			lRender.SetPosition(1, desPoint);
//			Lightning lRender = ligthing.GetComponent<Lightning> ();
//			lRender.origin = transform.position;
//			lRender.dest = desPoint;

			Vector3 forceDir = desPoint- transform.position;
			//playerRg.velocity = forceDir*speed;
			playerRg.AddForce(forceDir*speed,ForceMode.Impulse);
			if (Vector3.Distance (desPoint, transform.position) < minRangeToDrop) {
				connected = false;
				playerRg.AddForce(transform.up*2f,ForceMode.Impulse);
			
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
