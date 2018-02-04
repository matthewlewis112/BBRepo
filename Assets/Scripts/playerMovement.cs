using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 3000;
	private float moveX;	//moving on x-axis
	public bool isGrounded;
	public Color color;
	private int jumpCount;
	private double jumpBoost = 1.25;
	private double longJumpBoost = 2.0;
	private float weirdGravity = 3;
	private float normalGravity = 10;
	private bool changeNewMusic = true;

	void Start(){
		jumpCount = 0;
	}

	// Update is called once per frame
	void Update () {
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");

		if (gameObject.GetComponent<SpriteRenderer>().color != Color.white)
			playerMove ();
		else {
			if (changeNewMusic) {
				GameObject.FindGameObjectWithTag ("Music").GetComponent<AudioSource> ().Pause();
				GameObject.FindGameObjectWithTag ("Music2").GetComponent<AudioSource> ().Play();
				changeNewMusic = false;
			};
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = (float)-0.18;
		}
	}

	void playerMove()	{
		//controls

		moveX = Input.GetAxis ("Horizontal");
		if (gameObject.GetComponent<SpriteRenderer> ().color == Color.red) {
			if (Input.GetButtonDown ("Jump") && (isGrounded || jumpCount < 2)) {
				//player can jump if jump button is pressed and if grounded
				soundManager.playSound("Jump4");
				jump (true);
				jumpCount++;
				Debug.Log (jumpCount);
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = normalGravity;
			} else if (isGrounded){
				jumpCount = 0;
			}
		} else if (gameObject.GetComponent<SpriteRenderer>().color == Color.blue){
			if (Input.GetButtonDown ("Jump")) {
				gameObject.GetComponent<Rigidbody2D> ().gravityScale = -weirdGravity;
				weirdGravity *= -1;
			}
		} else if (Input.GetButtonDown ("Jump") && isGrounded) {
			jump (false);
			gameObject.GetComponent<Rigidbody2D> ().gravityScale = normalGravity;
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
		if (gameObject.GetComponent<SpriteRenderer>().color == Color.yellow && !isGrounded)
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * (int)(playerSpeed * longJumpBoost), gameObject.GetComponent<Rigidbody2D>().velocity.y);
		else
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	void jump(bool isBoosted)	{
		//jumping code

		int temp;
		if (isBoosted)
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * (int)(playerJumpPower * jumpBoost));
		else
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
		if (col.gameObject.tag == "deathTrigger") {
			SceneManager.LoadScene ("prototype1");
		}
		if (col.gameObject.tag == "Finish") {
			GameObject.FindGameObjectWithTag ("MainCamera").SetActive (false);
			GameObject.FindGameObjectWithTag ("EndScreen").SetActive (true);
		}
	}
}
