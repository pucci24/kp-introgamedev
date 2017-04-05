using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trimmers : MonoBehaviour {
	public AudioSource Cut;
	public Plant plant;
	public Hearts Health;
	Vector3 actualMousePosition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		actualMousePosition.z = 0;

		if (transform.position.y <= -7) {
			Destroy (gameObject);
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bud") {
			Cut.Play ();
			Destroy(gameObject);
			Destroy (coll.gameObject);
			plant.buds -= 1;
			if (plant.sap == true) {
				Health.health -= 1;
			}
		}
	}

	void OnMouseDrag() {
		gameObject.transform.position = actualMousePosition;
	}
}
