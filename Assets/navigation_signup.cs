using UnityEngine;
using System.Collections;

public class navigation_signup : MonoBehaviour {

	public GameObject Step1;
	public GameObject Step2;
	public GameObject Step3;

	// Use this for initialization
	void Start () {
	
		Step1.SetActive (true);
		Step3.SetActive (false);
		Step2.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goToStep2(){
		Step1.SetActive (false);
		Step3.SetActive (false);
		Step2.SetActive (true);

	}


	public void goToStep3(){
		Step1.SetActive (false);
		Step3.SetActive (true);
		Step2.SetActive (false);

		
		
	}

	public void Done(){

		Application.LoadLevel ("Home");
	}
}
