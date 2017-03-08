using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour 
{
	public GameObject plantfood;
	public GameObject meat;

	Vector3 actualMousePosition;

	public GameObject plantFoodButton;
	public GameObject meatButton;
	public GameObject youButton;

	public float speed;

	private Vector2 initPlantFoodButtonPos;
	private Vector2 initMeatButtonPos;
	private Vector2 initYouButtonPos;

	private bool hover;

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
		actualMousePosition.z = 0f;

		//if over the menu bar, have all option buttons slide out
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
		GameObject newFood = Instantiate(plantfood);
		newFood.transform.position = actualMousePosition;

	}

	public void OnMeatButtonClick ()
	{
		GameObject newFood = Instantiate(meat);
		newFood.transform.position = actualMousePosition;

	}
}
