﻿using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

	bool clicked = false;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown()
	{
		clicked = true;
	}

	void OnMouseUp()
	{
		clicked = false;
	}
}