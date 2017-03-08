using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour 
{
	public Hearts Health;
	public Plant Plant;

	//Peekaboo Variables
	bool PeekabooActive=false;
	bool PlayerLooking=true;
	bool PlantLooking=false;
	bool reset=false;
	float TimeSpotted=0f;
	float activeTimer=0f;
	float TimeClosed=0f;
	float random5=0f;
	float MinigameTime=15f;
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
		//Peekaboo Initializing
		random5=Random.Range(3f,5f);
		activeTimer = random5;


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
		if ((PeekabooActive == true)&&(MinigameTime > 0f)) {
				reset = false;
				MinigameTime -= 1f * Time.deltaTime;
				if (Plant.Boredom > 0f) {
					Plant.Boredom -= 3f * Time.deltaTime;
				}
				Debug.Log (PlantLooking);

				if ((PlantLooking == true) && (PlayerLooking == true)) {
					TimeSpotted += 1f * Time.deltaTime;
				}

				if (TimeSpotted >= 1f) {
					Health.hit = true;
					PeekabooActive = false;
				}

				if (activeTimer > 0f) {
					activeTimer -= 1f * Time.deltaTime;
				} else if (activeTimer <= 0f) {
					PlantLooking = !PlantLooking;
					activeTimer = random5;
				}

				if ((Input.GetKey (KeyCode.Space)) && (PeekabooActive == true)) {
					Eyelid.SetActive (true);
					PlayerLooking = false;
					TimeClosed += 1f * Time.deltaTime;
					if (TimeClosed >= 6f) {
						Health.hit = true;
						TimeClosed = 2f;
					}
				} else if ((Input.GetKeyUp (KeyCode.Space)) && (PeekabooActive == true)) {
					Eyelid.SetActive (false);
					PlayerLooking = true;
					TimeClosed = 0f;
				}
			}
		else if (PeekabooActive == false) {
			Debug.Log ("reset");
			PeekabooActive = false;
			PlantLooking = false;
			Eyelid.SetActive (false);
			PlayerLooking = true;
			TimeClosed = 0f;
			random5 = Random.Range (3f, 5f);
			activeTimer = random5;
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
		PeekabooActive = true;
		MinigameTime = 15f;

	}

	void OnGUI() {
		if (PeekabooActive == true) {
			GUI.contentColor = Color.black;
			GUI.Label (new Rect (110, 90, 150, 20), "Find a hiding SPACE!");
		}
	}
}

