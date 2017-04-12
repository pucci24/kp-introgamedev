using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowViewControl : MonoBehaviour {
	public GameObject calender;
	DayTimer timer;
	public int indicator;
	// Use this for initialization
	public GameObject blue;
	public GameObject red;
	public GameObject black;


	void Start () {
		
		indicator = calender.GetComponent<DayTimer> ().timeIndicator;
		
	}
	
	// Update is called once per frame
	void Update () {
		indicator = calender.GetComponent<DayTimer> ().timeIndicator;

		if (indicator == 1) {
			blue.SetActive (true);
			red.SetActive (false);
			black.SetActive (false);

			}
		if (indicator == 2) {
			red.SetActive (true);
			blue.SetActive (false);
			black.SetActive (false);
		}
		if (indicator == 3) {
			black.SetActive(true);
			red.SetActive(false);
			blue.SetActive(false);
		}
		
	}
}
