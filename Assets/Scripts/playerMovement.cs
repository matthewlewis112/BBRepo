using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;	//moving on x-axis
	public bool isGrounded;

	// Update is called once per frame
	void Update () {
		playerMove ();
	}

	void playerMove()	{
		//controls
		moveX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true)	{
			//player can jump if jump button is pressed and if grounded
			jump ();
		}
		//animation
		//player direction
		if (moveX < 0.0f && facingRight == false) {	
			//flips player when moving towards a direction
			flipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) {
			flipPlayer ();
		}
		//physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void jump()	{
		//jumping code
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	void flipPlayer()	{	
		//function for flipping player
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D (Collision2D col)	{
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		}
	}
}
