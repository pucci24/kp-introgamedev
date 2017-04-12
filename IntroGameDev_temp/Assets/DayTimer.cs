using UnityEngine;
using System.Collections;

public class DayTimer : MonoBehaviour {
	public Hearts Health;
	int day=1;
	float timePassed=0f;

	public int timeIndicator=1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Day:"+timePassed);
		timePassed += Time.deltaTime;
		if (timePassed >= 30f) {
			day += 1;
			timePassed = 0f;
			if (Health.health < 8) {
				Health.health += 2;
			} else if ((Health.health > 8)&&(Health.health < 10)) {
				Health.health += 1;
			}
		}

		if (0f <= timePassed && timePassed < 10f)
			timeIndicator = 1;
		if (10f <= timePassed && timePassed < 20f)
			timeIndicator = 2;
		if (20f < timePassed && timePassed < 30f)
			timeIndicator = 3;
			
			
	}

	void OnGUI() {
		GUI.contentColor = Color.black;
		GUI.Label(new Rect(Screen.width*4/5, Screen.height/2, 100, 20),""+day);
	}
}
