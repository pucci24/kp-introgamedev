using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour {

	public GameObject particlePrefab;
	public ParticleSystem activeParticles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (activeParticles != null) {
			if (activeParticles.isStopped) {
				Destroy (activeParticles.gameObject);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		//instantiate particle system and assign it to temporary variable p
		GameObject particleObj = Instantiate (particlePrefab.gameObject);
		ParticleSystem p = particleObj.GetComponent <ParticleSystem> () ;
		particleObj.transform.parent = collision.gameObject.transform;
		particleObj.transform.localPosition = Vector3.zero;

		//set particle system position equal to square's origin
		p.transform.position = Vector3.zero;
	}
}
