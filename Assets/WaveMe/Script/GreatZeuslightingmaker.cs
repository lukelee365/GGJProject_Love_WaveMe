using UnityEngine;
using System.Collections;

public class GreatZeuslightingmaker : MonoBehaviour {

	public Lightning Lightningpref;


	IEnumerator Start () {

		while(true)
		{
		Instantiate(Lightningpref,this.transform.position, Quaternion.identity);
		yield return null;
		}
	                  }
                                                   }