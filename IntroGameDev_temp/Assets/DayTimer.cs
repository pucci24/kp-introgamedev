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
		Debug.Log ("Day:"+timePassed);
		timePassed += Time.deltaTime;
		if (timePassed >= 200f) {
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
		GUI.Label(new Rect(Screen.width*4/5, Screen.height/2, 100, 20),""+day);
	}
}
