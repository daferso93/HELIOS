using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainPlayer : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public KeyCode left;
	public KeyCode right;
	public KeyCode jump;
	public KeyCode throwBall;

	private Rigidbody2D theRB;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (left)) {
			theRB.velocity = new Vector2 (-moveSpeed, theRB.velocity.y);
		} else if (Input.GetKey (right)) {
			theRB.velocity = new Vector2 (moveSpeed, theRB.velocity.y);
		} else {
			theRB.velocity = new Vector2 (0, theRB.velocity.y);
		}

		if (Input.GetKeyDown (jump)) {
			theRB.velocity = new Vector2 (theRB.velocity.x, jumpForce);
		}
	}
}
