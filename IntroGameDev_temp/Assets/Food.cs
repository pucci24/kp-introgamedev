using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
	public ParticleSystem bloodSpur;

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
		if (coll.gameObject.tag == "Plant") {
			Destroy(gameObject);
			Vector3 position = new Vector3 (0f,-1f,0f);
			Instantiate (bloodSpur, position, Quaternion.identity);
			if (plant.sap == true) {
				Health.health -= 1;

			}
		}
	}

	void OnMouseDrag() {
		gameObject.transform.position = actualMousePosition;
	}
}