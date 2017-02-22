using UnityEngine;
using System.Collections;

public class HoverButton : MonoBehaviour {

	bool hover = false;
	public GameObject Option1;
	public GameObject Option2;
	public GameObject Option3;
	float dist1;
	float dist2;
	float dist3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hover == true) {
			if (Option1.transform.position.x < -4) {
				Option1.transform.Translate (0.1f, 0f, 0f);
			}
			if (Option2.transform.position.x < -2.8) {
				Option2.transform.Translate (0.1f, 0f, 0f);
			}
			if (Option3.transform.position.x < -1.6) {
				Option3.transform.Translate (0.1f, 0f, 0f);
			}
		}
		else if (hover==false) {
			dist1 = transform.position.x - Option1.transform.position.x;
			dist2 = transform.position.x - Option2.transform.position.x;
			dist3 = transform.position.x - Option3.transform.position.x;
			if (dist1 < 0f) {
				Option1.transform.Translate (-0.1f, 0f, 0f);
			}
			if (dist2 < 0f) {
				Option2.transform.Translate (-0.1f, 0f, 0f);
			}
			if (dist3 < 0f) {
				Option3.transform.Translate (-0.1f, 0f, 0f);
			}
		}
	}


	public void OnMouseOver()
	{
		hover = true;
	}

	public void OnMouseExit()
	{
		hover = false;
	}
}
