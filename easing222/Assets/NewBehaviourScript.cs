using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Holoville.HOTween;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		HOTween.To(this.gameObject.GetComponent<RectTransform>(),
			3f, 
			new TweenParms()
			.Prop("anchoredPosition", 
				new Vector2(0f, 0f), 
				false) // Position tween (set as relative)

			.Ease(EaseType.EaseInExpo) // Ease
		);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
