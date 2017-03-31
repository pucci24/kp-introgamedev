using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
	//Visual
	SpriteRenderer sr;
	public Sprite ten;
	public Sprite nine;
	public Sprite eight;
	public Sprite seven;
	public Sprite six;
	public Sprite five;
	public Sprite four;
	public Sprite three;
	public Sprite two;
	public Sprite one;


	public Plant plant;
	public bool hit = false;
	public int health = 10;
	public int thornAdd = 1;

	// Use this for initialization
	void Start ()
	{
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (plant.thorns == true) {
			thornAdd = 2;
		}
		if (hit == true) {
			health -= 1*thornAdd;
			hit = false;
		}

		//Visual
		if (health >= 10) {
			sr.sprite = ten;
		} else if (health >= 9) {
			sr.sprite = nine;
		} else if (health >= 8) {
			sr.sprite = eight;
		} else if (health >= 7) {
			sr.sprite = seven;
		} else if (health >= 6) {
			sr.sprite = six;
		} else if (health >= 5) {
			sr.sprite = five;
		} else if (health >= 4) {
			sr.sprite = four;
		} else if (health >= 3) {
			sr.sprite = three;
		} else if (health >= 2) {
			sr.sprite = two;
		} else if (health >= 1) {
			sr.sprite = one;
		} else if (health <= 1) {
			//gameover
		}
	}
}
