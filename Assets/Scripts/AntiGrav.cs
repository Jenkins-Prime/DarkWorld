using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGrav : MonoBehaviour 
{
	private float originalGravScale;



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Projectile") {
			originalGravScale = other.attachedRigidbody.gravityScale;
			other.attachedRigidbody.gravityScale = -2;
			if (enabled == false) {
				other.attachedRigidbody.gravityScale = originalGravScale;
			}
		}
		else 
		{
			return;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		other.attachedRigidbody.gravityScale = 1;
	}
		
}
