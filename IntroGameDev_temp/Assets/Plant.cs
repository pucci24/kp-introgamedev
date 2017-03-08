using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

	public Hearts Health;
	public bool Content=true;
	public bool Hungry=false;
	public bool Bored=false;
	public bool Attack = false;
	public bool Bud = true;
	public bool IBloom = false;
	public bool MBloom = false;
	public bool Overgrowth = false;
	float AttackTimer=0f;
	float EvolutionTimer=0f;
	public float Hunger=0f;
	public float Thirst=0f;
	public float Boredom=0f;
	public float Relationship=50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Needs
		if (Hunger < 100f) {
			Hunger += 2f * Time.deltaTime;
		}
		if (Thirst < 100f) {
			Thirst += 1f * Time.deltaTime;
		}
		if (Boredom < 100f) {
			Boredom += 2f * Time.deltaTime;
		}

		//Status
		if (Hunger > 50f) {
			Content = false;
			Hungry = true;
			if (Relationship > -100) {
				Relationship -= 1f * Time.deltaTime;
			}
		}
		if (Boredom > 50f) {
			Content = false;
			Bored = true;
			if (Relationship > -100) {
				Relationship -= 1f * Time.deltaTime;
			}
		}
		if ((Hunger < 50f) && (Boredom < 50f)) {
			Content = true;
			Bored = false;
			Hungry = false;
			Relationship += 0.5f*Time.deltaTime;
		}

		//Development
		if (Content == true) {
			EvolutionTimer += 1f * Time.deltaTime;
		}
		if (EvolutionTimer >= 90) {
			Overgrowth = true;
			MBloom = false;
		}
		else if (EvolutionTimer >= 60) {
			MBloom = true;
			IBloom = false;
		}
		else if (EvolutionTimer >= 30) {
			IBloom = true;
			Bud = false;
		}
			

		//Attack
		if (Relationship < 50f) {
			AttackTimer += 1f * Time.deltaTime;
			if ((Relationship < 20f) && (AttackTimer >= 30f)) {
				Health.hit = true;
				AttackTimer = 0f;
			}
			if (AttackTimer >= 60f) {
				Health.hit = true;
				AttackTimer = 0f;
			}
		} else if (Relationship >= 50f) {
			AttackTimer = 0f;
		}
			
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "PlantFood") {
			Hunger-=4f;
			Relationship -= 1f;
		}
		if (coll.gameObject.tag == "Meat") {
			Hunger-=15f;
			Relationship += 5f;
		}
		if (coll.gameObject.tag == "You") {
			Hunger-=30f;
			Relationship += 15f;
		}
	}
}
