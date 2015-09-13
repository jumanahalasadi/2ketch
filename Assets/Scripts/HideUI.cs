using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HideUI : MonoBehaviour {
	public Slider inkslider;
	private bool isMousePressed;
	//public Button slider;
	//public Slider slider;
	// Use this for initialization
	void Start () {
		isMousePressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			isMousePressed = true;
		}

		if (Input.GetMouseButtonUp (0)) {
			isMousePressed = false;
		}


		if (isMousePressed) {


			GetComponent<CanvasGroup> ().alpha = 0f;

	
		} else {
			GetComponent<CanvasGroup> ().alpha = 1;
		}

		if (inkslider.value <= 0) {
			GetComponent<CanvasGroup> ().alpha = 0f;

		}
	}
}
