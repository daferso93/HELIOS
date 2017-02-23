using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchBehaivor : MonoBehaviour {
	private	int width = Screen.width / 2;
	private int height = Screen.height / 2;

	Camera camera;

	void Update () {
		if (Input.GetMouseButton (0) || Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp (0)) {
			if (Input.GetMouseButton (0)) {


				if (Input.mousePosition.x < width && Input.mousePosition.y < height) {
					Debug.Log (Input.mousePosition.x);
				}

				//GameObject gameObject = GameObject.Find ("mainCharacter");	
				///gameObject.SendMessage ("test", SendMessageOptions.DontRequireReceiver);
			}
		}


		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Stationary) {

				if (touch.position.x < width && touch.position.y < height) {
					GameObject gameObject = GameObject.Find ("mainCharacter");	
					gameObject.SendMessage ("test", SendMessageOptions.DontRequireReceiver);
				}

				if (touch.position.x > width && touch.position.y < height) {
					GameObject gameObject = GameObject.Find ("mainCharacter");	
					gameObject.SendMessage ("test1", SendMessageOptions.DontRequireReceiver);
				}
			}
		}


	}
}
