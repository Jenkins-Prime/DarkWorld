using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurityField : MonoBehaviour {

	[SerializeField]
	private float radius;
	private CircleCollider2D coll;
	private Transform trans;
	private bool active;
	[SerializeField]
	private float maxRadius;

	// Use this for initialization
	void Start () {
		trans = GetComponent<SpriteRenderer> ().transform;
		coll = GetComponent<CircleCollider2D> ();

		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (active) 
		{

			coll.radius = radius;
			radius += Time.deltaTime;
			if (radius >= maxRadius) 
			{
				Destroy (gameObject);
			}
				
		}
	}

	void OnEnable()
	{
		active = true;
	}
}
