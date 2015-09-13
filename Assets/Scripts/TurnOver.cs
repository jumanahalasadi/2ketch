using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TurnOver : MonoBehaviour {


	public Slider slider;
	//public Animator control;
	//public Animator animation;
	//public Animation animation;
	///public animation

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (slider.value == 0f) {

			//Debug.Log ("hi");
			//animation.Play ("next");
			GetComponent<Animation>().Play("next");
			//control.
		}
	}
}
