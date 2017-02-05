// script to draw sight
using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

public Texture2D crosshairTexture;
	public float scaler;
Rect position;

void  Start (){
		position = new Rect( ( Screen.width - crosshairTexture.width*scaler ) / 2, ( Screen.height - crosshairTexture.height*scaler ) / 2, crosshairTexture.width*scaler, crosshairTexture.height*scaler );
}

void  OnGUI (){
	GUI.DrawTexture(position, crosshairTexture);	
}

}