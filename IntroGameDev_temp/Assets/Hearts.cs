﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour {
	public bool hit=false;
	public int health = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (hit == true) {
			health -= 1;
			hit = false;
		}
	}

	void OnGUI() {
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(270, 40, 100, 20), "Health: "+health);
	}
}
