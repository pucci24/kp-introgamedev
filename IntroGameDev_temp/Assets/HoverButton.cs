using UnityEngine;
using System.Collections;

public class HoverButton : MonoBehaviour {

	bool hover = false;
	public GameObject Option1;
	public GameObject Option2;
	public GameObject Option3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hover == true) {
			if (Option1.transform.position.x < -4.05) {
				Option1.transform.Translate (0.1f, 0f, 0f);
			} else if (Option1.transform.position.x >= -4.05) {
				hover = false;
			}
			if (Option2.transform.position.x < -2.85) {
				Option2.transform.Translate (0.1f, 0f, 0f);
			}
			else if (Option2.transform.position.x >= -2.85) {
				hover = false;
			}
			if (Option3.transform.position.x < -1.65) {
				Option3.transform.Translate (0.1f, 0f, 0f);
			}else if (Option3.transform.position.x >= -1.65) {
				hover = false;
			}
		}
	}


	void OnMouseEnter()
	{
		hover = true;
	}

}
