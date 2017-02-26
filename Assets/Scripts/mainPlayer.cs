using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class mainPlayer : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode throwBall;

	private Rigidbody2D theRB;
	private Animator animator;

	public Text testText;

	void Start () {
		theRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
		testText = GameObject.Find ("amount").GetComponent<Text> ();
	}
		
	void Update () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));

		//Validation for left & right action.
		if (moveVec.x < 0) {
			theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);
		} else if (moveVec.x > 0) {
			theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
		}

		//Validation for jump & attack action.
		bool isJumping = CrossPlatformInputManager.GetButton("JumpButton");
		bool isAtacking = CrossPlatformInputManager.GetButton("ShootButtton");

		if (isJumping) {
			theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
		}

		if (isAtacking) {
			animator.SetTrigger("Shoot");
		}

		//Set values for animation
		animator.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
		animator.SetBool ("Jump", isJumping);
	}
}
