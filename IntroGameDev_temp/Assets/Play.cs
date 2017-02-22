using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour 
{
	public Hearts Health;

	//Peekaboo Variables
	bool PeekabooActive=false;
	int PlantAlert=0;
	bool PlayerLooking=true;
	float TimeClosed=0f;
	float TimePlantStage=0f;
	int random5=0;
	public GameObject Eyelid;

	Vector3 actualMousePosition;

	public GameObject PeekabooButton;
	public GameObject GuessButton;
	public GameObject DanceButton;

	public float speed;

	private Vector2 initPeekabooButtonPos;
	private Vector2 initGuessButtonPos;
	private Vector2 initDanceButtonPos;

	private bool hover;

	// Use this for initialization
	void Start () 
	{
		//initialize
		initPeekabooButtonPos = PeekabooButton.GetComponent<RectTransform>().anchoredPosition;
		initGuessButtonPos = GuessButton.GetComponent<RectTransform>().anchoredPosition;
		initDanceButtonPos = DanceButton.GetComponent<RectTransform>().anchoredPosition;

		PeekabooButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-123f,PeekabooButton.GetComponent<RectTransform> ().anchoredPosition.y);
		GuessButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-123f,GuessButton.GetComponent<RectTransform> ().anchoredPosition.y);
		DanceButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2(-123f,DanceButton.GetComponent<RectTransform> ().anchoredPosition.y);
	}

	// Update is called once per frame
	void Update () 
	{
		actualMousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		actualMousePosition.z = 0;

		//if over the menu bar, have all option buttons slide out
		if (hover) {
			if (PeekabooButton.GetComponent<RectTransform> ().anchoredPosition.x < initPeekabooButtonPos.x) {
				PeekabooButton.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				PeekabooButton.GetComponent<RectTransform> ().anchoredPosition = initPeekabooButtonPos;
			}
			if (GuessButton.GetComponent<RectTransform> ().anchoredPosition.x < initGuessButtonPos.x) {
				GuessButton.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				GuessButton.GetComponent<RectTransform> ().anchoredPosition = initGuessButtonPos;
			}
			if (DanceButton.GetComponent<RectTransform> ().anchoredPosition.x < initDanceButtonPos.x) {
				DanceButton.GetComponent<RectTransform> ().anchoredPosition += new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				DanceButton.GetComponent<RectTransform> ().anchoredPosition = initDanceButtonPos;
			}
		} else {
			if (PeekabooButton.GetComponent<RectTransform> ().anchoredPosition.x > -123f) {
				PeekabooButton.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				PeekabooButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-123f, PeekabooButton.GetComponent<RectTransform> ().anchoredPosition.y);
			}
			if (GuessButton.GetComponent<RectTransform> ().anchoredPosition.x > -123f) {
				GuessButton.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				GuessButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-123f, GuessButton.GetComponent<RectTransform> ().anchoredPosition.y);
			}
			if (DanceButton.GetComponent<RectTransform> ().anchoredPosition.x > -123f) {
				DanceButton.GetComponent<RectTransform> ().anchoredPosition -= new Vector2 (speed, 0f) * Time.deltaTime;
			} else {
				DanceButton.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-123f, DanceButton.GetComponent<RectTransform> ().anchoredPosition.y);
			}
		}

		//Minigames
		if (PeekabooActive == true) {
			random5 = Random.Range(0,5);
			//if(
				//PlantAlert = int(Random.value);
			if (Input.GetKeyDown(KeyCode.Space)) {
				Eyelid.SetActive (true);
				PlayerLooking=false;
				TimeClosed += 1f*Time.deltaTime;
				if (TimeClosed >= 6f) {
					Health.hit = true;
				}
			}
			else if (Input.GetKeyUp(KeyCode.Space)) {
				Eyelid.SetActive (false);
				PlayerLooking=true;
				TimeClosed=0f;
			}
		}
			

	}

	public void OnPlayEnter ()
	{
		hover = true;
	}

	public void OnPlayExit ()
	{
		hover = false;
	}

	public void OnPeekabooClick ()
	{
		Debug.Log ("Peekaboo!");
		PeekabooActive = true;

	}
}
