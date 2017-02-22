using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour 
{
	public GameObject water;

	Vector3 actualMousePosition;

	// Use this for initialization
	void Start () 
	{
		}

	// Update is called once per frame
	void Update () 
	{
		actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		actualMousePosition.z = 0;
	}

	public void OnWaterButtonClick ()
	{
		Debug.Log ("Water!");
		GameObject newWater = Instantiate(water);
		newWater.transform.position = actualMousePosition;

	}
}
