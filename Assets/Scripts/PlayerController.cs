using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Buttons{Left, Right, Up, Down, Jump, Shoot}
public class PlayerController : MonoBehaviour {


	private Rigidbody2D rb2d;
	private Animator anim;
	[Header("Movement Values")]
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float jumpHeight;

	[Header("Ground Detection")]
	[SerializeField]
	private bool grounded;
	[SerializeField]
	private LayerMask whatIsGround;
	private Collider2D coll;
	[Space]
	public bool canMove;
	[SerializeField]
	private bool isCrouching;
	[HideInInspector]
	public bool facingRight;



	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		coll = GetComponent<Collider2D> ();
	}


	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.IsTouchingLayers (coll, whatIsGround);
		if (grounded) 
		{
			AnimatePlayer ("Jumping", false);
		}

		if (canMove) 
		{

			if (Input.GetButtonUp ("Jump") && grounded) 
			{
				MovePlayer (Buttons.Jump);
			}

			if (Input.GetAxisRaw ("Horizontal") < 0) 
			{
				MovePlayer (Buttons.Left);
				AnimatePlayer ("Moving", true);
			}

			if (Input.GetAxisRaw ("Horizontal") > 0) 
			{
				MovePlayer (Buttons.Right);
				AnimatePlayer ("Moving", true);
			}

			if (Input.GetAxisRaw ("Vertical") < 0 && Input.GetAxisRaw ("Horizontal") == 0) {
				MovePlayer (Buttons.Down);
				AnimatePlayer ("Crouching", true);
				isCrouching = true;
				canMove = false;
			} 


			if (Input.GetAxisRaw ("Horizontal") == 0) 
			{
				rb2d.velocity = new Vector3 (0, rb2d.velocity.y, 0);
				AnimatePlayer ("Moving", false);
			}


			if (grounded) {
				AnimatePlayer ("Jumping", false);
			} else 
			{
				AnimatePlayer ("Jumping", true);
			}
		}

		if (isCrouching) 
		{
			if (Input.GetAxisRaw ("Vertical") == 0) 
			{
				AnimatePlayer ("Crouching", false);
				isCrouching = false;
				canMove = true;
			}


		}
	}

	void MovePlayer(Buttons action)
	{
		if (action == Buttons.Jump) 
		{
			rb2d.velocity = new Vector3 (rb2d.velocity.x, jumpHeight, 0);
		}

		if (action == Buttons.Left) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
			rb2d.velocity = new Vector3 (-moveSpeed, rb2d.velocity.y, 0);
			facingRight = false;
		}

		if (action == Buttons.Right) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
			rb2d.velocity = new Vector3 (moveSpeed, rb2d.velocity.y, 0);
			facingRight = true;
		}


	}

	public void AnimatePlayer(string animtype, bool animstate)
	{
		anim.SetBool (animtype, animstate);
	}

}
