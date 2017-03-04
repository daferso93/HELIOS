using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D theRB;

    public Transform intersectIndicator;
    public float intersectIndicatorRadius;
    public LayerMask whatsIsUnSafe;
    private bool isIntersect;
    float flipTime = 5f;
    float next = 0f;

    void Start () {
        theRB = GetComponent<Rigidbody2D>();        
    }

    private void FixedUpdate(){
        if (Time.time > next){
            if (Random.Range(4, 6) > 5) flipFacing();
            next = Time.time + flipTime;
        }
    }

    void flipFacing(){
        Debug.Log("Test");
    }
}
