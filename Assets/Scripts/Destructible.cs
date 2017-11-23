using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {

	[SerializeField]
	private GameObject lootDrop;
	private Animator anim;
	private Rigidbody2D rb2d;
	[SerializeField]
	private Vector3 lootJump;

	void Start()
	{
		anim = GetComponent<Animator> ();
		rb2d = GetComponent<Rigidbody2D> ();
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile") 
		{
			rb2d.gravityScale = 0;
			anim.SetBool ("Destroyed", true);
			Instantiate (lootDrop, transform.position, transform.rotation);
			Destroy (other.gameObject);

		}

	}
}
