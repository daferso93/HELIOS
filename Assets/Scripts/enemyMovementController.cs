using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {

    public float enemySpeed;
    Animator enemyAnimator;

    //facing
    public GameObject enemyGraphics;
    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 5f;
    float nextFlipChance = 0f;

    //attacking
    public float chargeTime;
    float startChargeTime;
    bool charcing;
    Rigidbody2D enemyRB;

	// Use this for initialization
	void Start () {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyRB = GetComponent<Rigidbody2D>();
	}

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player") {
            if (facingRight && collision.transform.position.x < transform.position.x){
                flipFacing();
            }
            else if (!facingRight && collision.transform.position.x > transform.position.x) {
                flipFacing();
            }
            canFlip = false;
            charcing = true;
            startChargeTime = Time.time + chargeTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision){
        if(collision.tag == "Player") {
            Handheld.Vibrate();
            if (startChargeTime <Time.time) {
                if (!facingRight) enemyRB.AddForce(new Vector2(-1, 0) * enemySpeed);
                else enemyRB.AddForce(new Vector2(1, 0) * enemySpeed);
                enemyAnimator.SetBool("Run", charcing);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player")
        {
            canFlip = true;
            charcing = false;
            enemyRB.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("Run", charcing);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Time.time > nextFlipChance) {
            if (Random.Range(0, 10) >= 5) flipFacing();
            nextFlipChance = Time.time + flipTime;
        }
	}

    void flipFacing() {
        if (!canFlip) return;
        float facingX = enemyGraphics.transform.localScale.x;
        facingX *= -1f;
        enemyGraphics.transform.localScale = new Vector3(facingX, enemyGraphics.transform.localScale.y, enemyGraphics.transform.localScale.x);
        facingRight = !facingRight;
    }
}
