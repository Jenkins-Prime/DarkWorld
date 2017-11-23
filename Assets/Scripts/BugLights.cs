using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugLights : MonoBehaviour {

	[SerializeField]
	private GameObject lampGlow;

	
	// Update is called once per frame
	void Update () {
		if (lampGlow.activeInHierarchy) {
			gameObject.SetActive (true);
		} else 
		{
			gameObject.SetActive (false);
		}
	}
}
