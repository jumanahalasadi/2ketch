using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FBholder : MonoBehaviour {

//	public bool login_bool = false;

	// Use this for initialization
	void Awake()
	{
			FB.Init (SetInit, OnHideUnity);


			//DontDestroyOnLoad(this.gameObject);
		

	}
		
	
	private void SetInit()
	{
		Debug.Log ("FB init done.");

		//if user is already logged in..

		if (FB.IsLoggedIn) {
			DealWithFBMenu(true);
			Debug.Log ("FB Logged In");
			Application.LoadLevel("Home");
			//login_bool = true;
		} else {


			//if not logged in, it will call the login function
			//FBlogin ();//refer to function line 47

			DealWithFBMenu(false);
		}

	}


	private void OnHideUnity(bool isGameShown)

	{

		if (!isGameShown) {

			Time.timeScale = 0; //pause the game if fb is taking the attention
		}
		else{
			//resume game
			Time.timeScale = 1;

		}

	}


	public void FBlogin ()

	{
		FB.Login ("email", AuthCallback); 


	}

	void AuthCallback(FBResult result){ //is a callback, says if loggin worked or not

		if (FB.IsLoggedIn) {
			Debug.Log ("FB login worked!");
			DealWithFBMenu(true);

		} else {
			Debug.Log ("Fb login fail");
			DealWithFBMenu(false);
		}

	}


	void DealWithFBMenu(bool isLoggedIn){

		if (isLoggedIn) {
			Debug.Log ("FB login worked!");


			//get profile picture code
			


			//get username code

			//Application.LoadLevel("Home");
		} else {

			//Application.LoadLevel("introscreen");
		}


	}


}
