using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WhosTurn : MonoBehaviour {

	public Slider slider; 
	public Text displaytext;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (slider.value == 0f) {
			displaytext.text = "YOUR TURN IS OVER!!";  
			displaytext.fontStyle = FontStyle.Bold;
		}

		else 
			displaytext.text = " ";  
	}
}
