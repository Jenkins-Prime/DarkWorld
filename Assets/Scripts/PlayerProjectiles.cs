using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjectiles : MonoBehaviour {

	[Header("Where to Fire From?")]
	[SerializeField]
	private Transform projectileTransform;
	public bool canFire;
	private Animator anim;

	[SerializeField]
	private GameObject projectile;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();


			
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
				anim.SetTrigger ("Firing");
				Instantiate (projectile, projectileTransform.position, projectileTransform.rotation);
		}
	
	}
}
