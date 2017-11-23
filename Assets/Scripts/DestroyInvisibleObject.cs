using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvisibleObject : MonoBehaviour {

	void OnBecameInvisible()
	{
		Destroy (this.gameObject);
	}
}
