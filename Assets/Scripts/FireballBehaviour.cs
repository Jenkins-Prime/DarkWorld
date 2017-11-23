using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour {

	[SerializeField]
	private Rigidbody2D rb2d;
	[SerializeField]
	private float speed;
	private PlayerController player;
	private int localscale = 1;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();
		if (player.transform.localScale.x < 0) 
		{
			speed = -speed;
			localscale = -localscale;

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		rb2d.velocity = new Vector3 (speed, 0, 0);
		transform.localScale = new Vector3 (localscale, 1, 1);

	}
		
}
