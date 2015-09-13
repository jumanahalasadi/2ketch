using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using Parse;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

public class active : MonoBehaviour {

	public GameObject loggedin;
	public GameObject loggedout;


	void Update(){


		if (ParseUser.CurrentUser != null)
		{
			// do stuff with the user
			loggedin.SetActive (true);
			loggedout.SetActive (false);
			
		}
		else
		{
			// show the signup or login screen
			loggedin.SetActive (false);
			loggedout.SetActive (true);
		}
	}

	// Use this for initialization
	public void activate(){


		if (ParseUser.CurrentUser != null)
		{
			// do stuff with the user
			loggedin.SetActive (true);
			loggedout.SetActive (false);

		}
		else
		{
			// show the signup or login screen
			loggedin.SetActive (false);
			loggedout.SetActive (true);
		}


	

	}

	public void logout(){

		ParseUser.LogOut ();

		var currentUser = ParseUser.CurrentUser;
		loggedin.SetActive (false);
		loggedout.SetActive (true);
		
	}
}
