using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour 
{
	public GameObject water;

	Vector3 actualMousePosition;

	GameObject newWater;

	// Use this for initialization
	void Start () 
	{
		}

	// Update is called once per frame
	void Update () 
	{
		actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		actualMousePosition.z = 0;

		//if a new water has been instantiated
		if (newWater) 
		{
			//if mouse is being hold
			if (Input.GetMouseButton (0)) 
			{
				//assign the new water position with the mouse position
				newWater.transform.position = actualMousePosition;
			}
		}
	}


	public void trytry(){
		Debug.Log ("!!!!????");
		newWater.transform.position = newWater.transform.position;

	}

	public void OnWaterButtonClick ()
	{
		Debug.Log ("Water!");
		newWater = Instantiate(water);
		newWater.transform.position = actualMousePosition;

	}
}
