using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

	bool clicked = false;
	bool hovering = false;
	public GameObject origin;
	float dist;

	// Use this for initialization
	void Start () {
		BoxCollider2D Menu = origin.GetComponent( typeof(BoxCollider2D) ) as BoxCollider2D;
		//Component Menu = origin.GetComponent(BoxCollider2D);
	}

	// Update is called once per frame
	void Update () {
		dist = (origin.transform.position.x)-(gameObject.transform.position.x);
		if ((Input.mousePosition.x < -1) && (Input.mousePosition.x > -6) && (Input.mousePosition.y < 4.5) && (Input.mousePosition.y > 3.5)) {
			hovering = true;
		}
		if ((dist<0)&&(hovering==false)) {
			gameObject.transform.Translate (-0.1f, 0f, 0f);
		}
	}
		
	void OnMouseDown()
	{
		clicked = true;
	}
}