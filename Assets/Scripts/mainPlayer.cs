using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class mainPlayer : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D theRB;
	private Animator animator;

	public Transform intersectIndicator;
	public float intersectIndicatorRadius;
	public LayerMask whatsIsUnSafe;
	private bool isIntersect;
    private bool isJumping;
    private bool isAtacking;

    private Vector2 moveVec;

    void Start () {
		theRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
    }
		
	void Update () {
        moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));
		isIntersect = Physics2D.OverlapCircle (intersectIndicator.position, intersectIndicatorRadius, whatsIsUnSafe);
        isJumping = CrossPlatformInputManager.GetButton("JumpButton");
        isAtacking = CrossPlatformInputManager.GetButton("ShootButtton");

        fnMoveMainChapter();
        fnFireAnimations();

    }

    private void fnMoveMainChapter(){
        if (moveVec.x < 0)
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveVec.x > 0)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void fnFireAnimations() {
        if (isJumping){
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (isAtacking){
            animator.SetTrigger("Shoot");
        }

        if (isIntersect){
            //StartCoroutine(dieAnimation());

        }

        animator.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        animator.SetBool("Jump", isJumping);
    }

    IEnumerator dieAnimation(){
        Color beginColor = gameObject.GetComponent<Renderer>().material.color;
        for (int i = 0; i < 10; i++)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(15, 10, 17, 1);
            yield return new WaitForSeconds(0.1F);
            gameObject.GetComponent<Renderer>().material.color = beginColor;
        }
        theRB.MovePosition(new Vector2(-14.83f, -2.46f));
    }
}
