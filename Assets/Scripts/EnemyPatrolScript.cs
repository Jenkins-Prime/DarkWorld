using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour {

	[SerializeField]
	private float idleTime;
	private float initialIdleTime;
	[SerializeField]
	private float moveTime;
	private float initialMoveTime;
	private Rigidbody2D rb2d;
	[SerializeField]
	private Collider2D wallCheck; 
	private bool touching;
	[SerializeField]
	private LayerMask collidingLayer;
	private bool movingRight;
	[SerializeField]
	private float moveSpeed;
	private Animator anim;

	private bool isMoving;

	private bool isIdle;
	private bool notAtEdge;
	[SerializeField]
	private Collider2D edgeCheck;



	// Use this for initialization
	void Start () 
	{

		initialIdleTime = idleTime;
		initialMoveTime = moveTime;
		rb2d = GetComponent<Rigidbody2D> ();
		isIdle = true;
		movingRight = true;
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		touching = Physics2D.IsTouchingLayers (wallCheck, collidingLayer);

		if (touching) 
		{
			movingRight = !movingRight;
		}

			if (isIdle) {
				rb2d.velocity = new Vector3 (0, rb2d.velocity.y, 0);
				anim.SetBool ("Moving", false);
				idleTime -= Time.deltaTime;
				if (idleTime <= 0) {
					isMoving = true;
					idleTime = initialIdleTime;
					isIdle = false;
				}
			}

			if (isMoving) {
			
				if (movingRight) {
					transform.localScale = new Vector3 (1, 1, 1);
					anim.SetBool ("Moving", true);
					rb2d.velocity = new Vector3 (moveSpeed, rb2d.velocity.y, 0);
				} else {
					transform.localScale = new Vector3 (-1, 1, 1);
					anim.SetBool ("Moving", true);
					rb2d.velocity = new Vector3 (-moveSpeed, rb2d.velocity.y, 0);
				}

				moveTime -= Time.deltaTime;
				if (moveTime <= 0) {
					isIdle = true;
					moveTime = initialMoveTime;
					isMoving = false;
				}
			}


	}
}
