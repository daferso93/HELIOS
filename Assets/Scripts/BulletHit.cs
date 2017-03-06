using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour {

	public float weaponDamage;

	BulletControler myBullet;

	void Awake () {
		myBullet = GetComponentInParent<BulletControler> ();
	}

	void Update () {}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myBullet.removeForce();
			Destroy (gameObject);

			if (collider.tag == "Enemy") {
				EnemyHealth hurthEnemy = collider.gameObject.GetComponent<EnemyHealth> ();
				hurthEnemy.addDamage(weaponDamage);
			}
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		if (collider.gameObject.layer == LayerMask.NameToLayer ("Shootable")) {
			myBullet.removeForce();
			Destroy (gameObject);

			if (collider.tag == "Enemy") {
				EnemyHealth hurthEnemy = collider.gameObject.GetComponent<EnemyHealth> ();
				hurthEnemy.addDamage(weaponDamage);
			}
		}
	}
}
