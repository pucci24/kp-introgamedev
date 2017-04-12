using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour 
{

	GameObject newFood;
	public AudioSource Cut;

	public Hearts Health;

	public GameObject plantfood;
	public GameObject meat;
	public GameObject you;

	Vector3 actualMousePosition;

	public GameObject plantFoodButton;
	public GameObject meatButton;
	public GameObject youButton;

	public float speed;

	private Vector2 initPlantFoodButtonPos;
	private Vector2 initMeatButtonPos;
	private Vector2 initYouButtonPos;

	private bool hover;
	public int meatSupplies=10;

	// Use this for initialization
	void Start () 
	{
		//initialize
		initPlantFoodButtonPos = plantFoodButton.GetComponent<RectTransform>().anchoredPosition;
		initMeatButtonPos = meatButton.GetComponent<RectTransform>().anchoredPosition;
		initYouButtonPos = youButton.GetComponent<RectTransform>().anchoredPosition;

		plantFoodButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-123f,plantFoodButton.GetComponent<RectTransform> ().anchoredPosition.y);
		meatButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-123f,meatButton.GetComponent<RectTransform> ().anchoredPosition.y);
		youButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-123f,youButton.GetComponent<RectTransform> ().anchoredPosition.y);
	}

	// Update is called once per frame
	void Update () 
	{


		actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		actualMousePosition.z = 0f;		//if over the menu bar, have all option buttons slide out

		if (newFood) 
		{
			if(Input.GetMouseButton (0))
			//assign the new water position with the mouse position
			newFood.transform.position = actualMousePosition;
		}

		if (hover) {




			if (plantFoodButton.GetComponent<RectTransform> ().anchoredPosition.x < initPlantFoodButtonPos.x) {
				plantFoodButton.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				plantFoodButton.GetComponent<RectTransform> ().anchoredPosition = initPlantFoodButtonPos;
			}
			if (meatButton.GetComponent<RectTransform> ().anchoredPosition.x < initMeatButtonPos.x) {
				meatButton.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				meatButton.GetComponent<RectTransform> ().anchoredPosition = initMeatButtonPos;
			}
			if (youButton.GetComponent<RectTransform> ().anchoredPosition.x < initYouButtonPos.x) {
				youButton.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				youButton.GetComponent<RectTransform> ().anchoredPosition = initYouButtonPos;
			}
		} else {
			if (plantFoodButton.GetComponent<RectTransform> ().anchoredPosition.x > -123f) {
				plantFoodButton.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				plantFoodButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-123f, plantFoodButton.GetComponent<RectTransform> ().anchoredPosition.y);
			}
			if (meatButton.GetComponent<RectTransform> ().anchoredPosition.x > -123f) {
				meatButton.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				meatButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-123f, meatButton.GetComponent<RectTransform> ().anchoredPosition.y);
			}
			if (youButton.GetComponent<RectTransform> ().anchoredPosition.x > -123f) {
				youButton.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				youButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-123f, youButton.GetComponent<RectTransform> ().anchoredPosition.y);
			}
		}

	}

	public void OnFeedEnter ()
	{
		hover = true;
	}

	public void OnFeedExit ()
	{
		hover = false;
	}

	public void OnPlantFoodButtonClick ()
	{
		newFood = Instantiate(plantfood);
		newFood.transform.position = actualMousePosition;

	}

	public void OnMeatButtonClick ()
	{
		if (meatSupplies > 0) {
			newFood = Instantiate (meat);
			newFood.transform.position = actualMousePosition;
			meatSupplies -= 1;
		}
	}

	public void OnYouButtonClick ()
	{
		newFood = Instantiate(you);
		newFood.transform.position = actualMousePosition;
		Health.health -= 1;
		Cut.Play ();
	}

	void OnGUI ()
	{
		GUI.contentColor = Color.black;
		GUI.Label (new Rect (Screen.width/15, Screen.height/8, 100, 20), "Meat: " + meatSupplies);
	}
}
