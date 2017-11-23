using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyViaProjectile : MonoBehaviour {
	private Animator anim;
	[SerializeField]
	private GameObject dustPuff;
	private bool destroyed;
	[SerializeField]
	private bool hasLoot;
	[SerializeField]
	private GameObject loot;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Projectile") 
		{
			if (!destroyed) 
			{
				Instantiate (dustPuff, other.transform.position, other.transform.rotation);
				anim.SetBool ("Destroyed", true);
				if (hasLoot) 
				{
					Instantiate (loot, other.transform.position, other.transform.rotation);
				}
				Destroy (other.gameObject);
				destroyed = true;
			} 
			else 
			{
				return;
			}

		}
	}
}
