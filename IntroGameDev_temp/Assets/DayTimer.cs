using UnityEngine;
using System.Collections;

public class DayTimer : MonoBehaviour {
	public Hearts Health;
	int day=1;
	float timePassed=0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;
		if (timePassed >= 300f) {
			day += 1;
			timePassed = 0f;
			if (Health.health < 8) {
				Health.health += 2;
			} else if ((Health.health > 8)&&(Health.health < 10)) {
				Health.health += 1;
			}
		}
			
	}

	void OnGUI() {
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(270, 60, 100, 20), "Day: "+day);
	}
}
