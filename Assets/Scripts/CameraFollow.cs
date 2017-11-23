using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	[SerializeField]
	private float xOffset;
	[SerializeField]
	private float yOffset;
	private PlayerController player;
	[SerializeField]
	private bool isFollowing;
	[SerializeField]
	private float cameraSpeed;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (isFollowing) 
		{
			transform.position = new Vector3 (player.transform.position.x + xOffset, player.transform.position.y + yOffset, -10);

			if (player.facingRight == true && xOffset != 1) {
				xOffset = Mathf.Lerp (xOffset, 1f, cameraSpeed);
			}
			if (player.facingRight == true && xOffset == 1) {
				xOffset = 1;
			}

			if (player.facingRight == false && xOffset != -1) {
				xOffset = Mathf.Lerp (xOffset, -1f, cameraSpeed);
			}
			if (player.facingRight == false && xOffset == -1) {
				xOffset = -1;
			}
			 
		}
	}
}
