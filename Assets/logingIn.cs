using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Parse;

public class logingIn : MonoBehaviour {

	public InputField Username;
	public InputField Password;
	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		/*
		ParseUser.LogInAsync (Username.text, Password.text).ContinueWith (t =>
		                                                                  {
			if (t.IsFaulted || t.IsCanceled) {
				// The login failed. Check the error to see why.
				Debug.Log ("Not logged in");
			} else {
				// Login was successful.
				Debug.Log ("logged in");
			}
		});
		*/

	}

	public void LOGMEIN() {

		ParseUser.LogInAsync (Username.text, Password.text).ContinueWith (t =>
		                                                                  {
			if (t.IsFaulted || t.IsCanceled) {
				// The login failed. Check the error to see why.
				Debug.Log ("Not logged in");
			} else {
				// Login was successful.
				Debug.Log ("logged in");
			}
		});
	}



}
