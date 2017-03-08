using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

	public Hearts Health;
	public GameObject Bud;
	Vector3 spawn;
	float timeUntrimmed=0f;
	public float evoMulti=1f;
	public int buds=0;
	public bool thorns=false;
	public bool sap=false;
	public bool Content=true;
	public bool Hungry=false;
	public bool Bored=false;
	public bool Attack = false;
	public bool Sprout = true;
	public bool IBloom = false;
	public bool MBloom = false;
	public bool Overgrowth = false;
	public float AttackTimer=0f;
	float EvolutionTimer=0f;
	public float Hunger=0f;
	public float Thirst=0f;
	public float Boredom=0f;
	public float Relationship=50f;
	float budTimer=0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Needs
		if (Hunger < 100f) {
			Hunger += 2f * Time.deltaTime * evoMulti;
		}
		if (Thirst < 100f) {
			Thirst += 1f * Time.deltaTime * evoMulti;
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
		if (EvolutionTimer >= 9) {
			Overgrowth = true;
			evoMulti = 2f;
			MBloom = false;
		}
		else if (EvolutionTimer >= 6) {
			MBloom = true;
			evoMulti = 1.5f;
			IBloom = false;
		}
		else if (EvolutionTimer >= 3) {
			IBloom = true;
			evoMulti = 1.2f;
			Sprout = false;
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

		//Buds
		if (budTimer < 15f) {
			budTimer += 1f * Time.deltaTime;
		} else if (budTimer >= 15f) {
			float spawnX = Random.Range(-0.2f,0.2f);
			float spawnY = Random.Range(-1.4f,-1.2f);
			spawn.Set(spawnX,spawnY,0f);
			GameObject newBud = Instantiate(Bud);
			newBud.transform.position = (spawn);
			budTimer = 0f;
			buds+=1;
		}

		if (buds>0) {
			timeUntrimmed += 1f * Time.deltaTime;
		} else if (buds<=0) {
			timeUntrimmed = 0f;
		}

		if ((timeUntrimmed > 45) && thorns && sap) {
		} else if ((timeUntrimmed > 45) && thorns) {
			sap = true;
			timeUntrimmed = 0f;
		} else if (timeUntrimmed > 45) {
			thorns = true;
			timeUntrimmed = 0f;
		}
			
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "PlantFood") {
			Hunger-=10f;
			Relationship -= 1f;
		}
		if (coll.gameObject.tag == "Meat") {
			Hunger-=30f;
			Relationship += 5f;
		}
		if (coll.gameObject.tag == "You") {
			Hunger-=50f;
			Relationship += 15f;
		}

		if (coll.gameObject.tag == "Water") {
			Thirst-=25f;
			if (Thirst > 95) {
				Relationship -= 15;
			}
		}
	}
}
