using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public float weaponDamage;

	BulletControler myBullet;

	void Awake () {
		myBullet = GetComponentInParent<BulletControler> ();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myBullet.removeForce();
			Destroy (gameObject);
		}
	}

	void Update () {}
}
