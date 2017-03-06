using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class mainPlayer : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D theRB;
	private Animator animator;
    bool leftFacing = false;

	public float intersectIndicatorRadius;
	public LayerMask whatsIsUnSafe;
	private bool isIntersect;
    private bool isJumping;
    private bool isAtacking;

    private Vector2 moveVec;

    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;

    void Start () {
		theRB = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator> ();
    }
		
	void Update () {
        moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal"), CrossPlatformInputManager.GetAxis ("Vertical"));
		//isIntersect = Physics2D.OverlapCircle (intersectIndicator.position, intersectIndicatorRadius, whatsIsUnSafe);
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
            leftFacing = true;
        }
        else if (moveVec.x > 0)
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            leftFacing = false;
        }
    }

    private void fnFireAnimations() {
        if (isJumping){
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (isAtacking){
            animator.SetTrigger("Shoot");
            fireBulet();
        }

        animator.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        animator.SetBool("Jump", isJumping);
    }

    void fireBulet(){
        if (Time.time > nextFire){
            nextFire = Time.time + fireRate;

			if (!leftFacing) { Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,0))); }
			else if (leftFacing) { Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0,0,180f))); }
        }
    }
}
