using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{

	//Audio&Visual
	public AudioSource Bite;
	public AudioSource Splash;
	SpriteRenderer sr;
	public Sprite sproutC;
	public Sprite sproutH;
	public Sprite sproutB;
	public Sprite sproutW;
	public Sprite IBloomC;
	public Sprite IBloomH;
	public Sprite IBloomB;
	public Sprite IBloomW;
	public Sprite MBloomC;
	public Sprite MBloomH;
	public Sprite MBloomB;
	public Sprite MBloomW;
	public Sprite OvergrowthC;
	public Sprite OvergrowthH;
	public Sprite OvergrowthB;
	public Sprite OvergrowthW;
	public Sprite IBloomCT;
	public Sprite IBloomHT;
	public Sprite IBloomBT;
	public Sprite IBloomWT;
	public Sprite MBloomCT;
	public Sprite MBloomHT;
	public Sprite MBloomBT;
	public Sprite MBloomWT;
	public Sprite OvergrowthCT;
	public Sprite OvergrowthHT;
	public Sprite OvergrowthBT;
	public Sprite OvergrowthWT;
	public Sprite IBloomCS;
	public Sprite IBloomHS;
	public Sprite IBloomBS;
	public Sprite IBloomWS;
	public Sprite MBloomCS;
	public Sprite MBloomHS;
	public Sprite MBloomBS;
	public Sprite MBloomWS;
	public Sprite OvergrowthCS;
	public Sprite OvergrowthHS;
	public Sprite OvergrowthBS;
	public Sprite OvergrowthWS;

	//Mechanical
	public Hearts Health;
	public GameObject Bud;
	Vector3 spawn;
	float timeUntrimmed = 0f;
	public float evoMulti = 1f;
	public int buds = 0;
	public bool thorns = false;
	public bool sap = false;
	public bool Content = true;
	public bool Hungry = false;
	public bool Bored = false;
	public bool Attack = false;
	public bool Sprout = true;
	public bool IBloom = false;
	public bool MBloom = false;
	public bool Overgrowth = false;
	public float AttackTimer = 0f;
	float EvolutionTimer = 0f;
	public float Hunger = 0f;
	public float Thirst = 0f;
	public float Boredom = 0f;
	public float Relationship = 50f;
	float budTimer = 0f;

	// Use this for initialization
	void Start ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
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
		} else if (Hunger < 50f) {
			Hungry = false;
		}
		if (Boredom > 50f) {
			Content = false;
			Bored = true;
			if (Relationship > -100) {
				Relationship -= 1f * Time.deltaTime;
			}
		} else if (Boredom < 50f) {
			Bored = false;
		}
		if ((Hunger < 50f) && (Boredom < 50f)) {
			Content = true;
			Bored = false;
			Hungry = false;
			Relationship += 0.5f * Time.deltaTime;
		}

		//Development
		if (Content == true) {
			EvolutionTimer += 1f * Time.deltaTime;
		}
		if (EvolutionTimer >= 300) {
			Overgrowth = true;
			evoMulti = 2f;
			MBloom = false;
		} else if (EvolutionTimer >= 200) {
			MBloom = true;
			evoMulti = 1.5f;
			IBloom = false;
		} else if (EvolutionTimer >= 150) {
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
			float spawnX = Random.Range (-0.2f, 0.2f);
			float spawnY = Random.Range (-1.4f, -1.2f);
			spawn.Set (spawnX, spawnY, 0f);
			GameObject newBud = Instantiate (Bud);
			newBud.transform.position = (spawn);
			budTimer = 0f;
			buds += 1;
		}

		if (buds > 0) {
			timeUntrimmed += 1f * Time.deltaTime;
		} else if (buds <= 0) {
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

		//Visuals
		if (Sprout == true) {
			if (Thirst >= 85) {
				sr.sprite = sproutW;
			} else if (Hungry == true) {
				sr.sprite = sproutH;
			} else if (Bored == true) {
				sr.sprite = sproutB;
			} else {
				sr.sprite = sproutC;
			}
		} else if (IBloom == true) {
			if (Thirst >= 85) {
				if (sap == true) {
					sr.sprite = IBloomWS;
				} else if (thorns == true) {
					sr.sprite = IBloomWT;
				} else {
					sr.sprite = IBloomW;
				}
			} else if (Hungry == true) {
				if (sap == true) {
					sr.sprite = IBloomHS;
				} else if (thorns == true) {
					sr.sprite = IBloomHT;
				} else {
					sr.sprite = IBloomH;
				}
			} else if (Bored == true) {
				if (sap == true) {
					sr.sprite = IBloomBS;
				} else if (thorns == true) {
					sr.sprite = IBloomBT;
				} else {
					sr.sprite = IBloomB;
				}
			} else {
				if (sap == true) {
					sr.sprite = IBloomCS;
				} else if (thorns == true) {
					sr.sprite = IBloomCT;
				} else {
					sr.sprite = IBloomC;
				}
			}
		} else if (MBloom == true) {
			if (Thirst >= 85) {
				if (sap == true) {
					sr.sprite = MBloomWS;
				} else if (thorns == true) {
					sr.sprite = MBloomWT;
				} else {
					sr.sprite = MBloomW;
				}
			} else if (Hungry == true) {
				if (sap == true) {
					sr.sprite = MBloomHS;
				} else if (thorns == true) {
					sr.sprite = MBloomHT;
				} else {
					sr.sprite = MBloomH;
				}
			} else if (Bored == true) {
				if (sap == true) {
					sr.sprite = MBloomBS;
				} else if (thorns == true) {
					sr.sprite = MBloomBT;
				} else {
					sr.sprite = MBloomB;
				}
			} else {
				if (sap == true) {
					sr.sprite = MBloomCS;
				} else if (thorns == true) {
					sr.sprite = MBloomCT;
				} else {
					sr.sprite = MBloomC;
				}
			}
		} else if (Overgrowth == true) {
			if (Thirst >= 85) {
				if (sap == true) {
					sr.sprite = OvergrowthWS;
				} else if (thorns == true) {
					sr.sprite = OvergrowthWT;
				} else {
					sr.sprite = OvergrowthW;
				}
			} else if (Hungry == true) {
				if (sap == true) {
					sr.sprite = OvergrowthHS;
				} else if (thorns == true) {
					sr.sprite = OvergrowthHT;
				} else {
					sr.sprite = OvergrowthH;
				}
			} else if (Bored == true) {
				if (sap == true) {
					sr.sprite = OvergrowthBS;
				} else if (thorns == true) {
					sr.sprite = OvergrowthBT;
				} else {
					sr.sprite = OvergrowthB;
				}
			} else {
				if (sap == true) {
					sr.sprite = OvergrowthCS;
				} else if (thorns == true) {
					sr.sprite = OvergrowthCT;
				} else {
					sr.sprite = OvergrowthC;
				}
			}
			
		}
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "PlantFood") {
			Bite.Play();
			Hunger -= 20f;
			Relationship -= 1f;
		}
		if (coll.gameObject.tag == "Meat") {
			Bite.Play ();
			Hunger -= 50f;
			Relationship += 5f;
		}
		if (coll.gameObject.tag == "You") {
			Splash.Play ();
			Hunger -= 80f;
			Relationship += 15f;
		}

		if (coll.gameObject.tag == "Water") {
			Splash.Play ();
			Thirst -= 25f;
			if (Thirst > 95) {
				Relationship -= 15;
			}
		}
	}
}
