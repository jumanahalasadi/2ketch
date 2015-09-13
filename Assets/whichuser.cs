using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
//using System.Collections.IEnumberable;
using Parse;

public class whichuser : MonoBehaviour {
	/*
	public Toggle Lena;
	public Toggle Jam;
	public Toggle Ammar;
	public Toggle Tomiwa;
	public Toggle Manny;
	*/
	public Text username;
	public Text users;




//	private static List<ParseObject>allObjects;  
	
	// Use this for initialization
	
	void Start(){
		username.text = ParseUser.CurrentUser.Username;
	}
	
	void Update(){
//		username.text = "Hello " + ParseUser.CurrentUser.Username;

		/*var query = ParseObject.GetQuery("User").OrderBy("username").Limit(10);
		query.FindAsync().ContinueWith(t =>
		                               {
			IEnumerable<ParseObject> results = t.Result;
			foreach (var obj in results)
			{
				string username2 = obj.Get<string>("username");
				Debug.Log("Friend: " + username2);

			}
		});*/

	}

	
	public void loginuser() {
		/*
		
		
		if (Lena.isOn) {
			
			ParseUser.LogInAsync ("olena", "password").ContinueWith (t =>
			{
				if (t.IsFaulted || t.IsCanceled) {
					// The login failed. Check the error to see why.
				} else {
					// Login was successful.
					
					if (ParseUser.CurrentUser != null) {
						//Application.LoadLevel ("Canvas");
						Debug.Log ("Lena");
						//username.text = ParseUser.CurrentUser.Username;

					}
				}
			});


		}

		else if (Jam.isOn) {
			
			ParseUser.LogInAsync("jumanah", "password").ContinueWith(t =>
			                                                         {
				if (t.IsFaulted || t.IsCanceled)
				{
					// The login failed. Check the error to see why.
				}
				else
				{
					// Login was successful.
					
					if (ParseUser.CurrentUser != null)
					{

						//Application.LoadLevel ("Canvas");
						Debug.Log (ParseUser.CurrentUser.Username);
						//username.text = ParseUser.CurrentUser.Username;
						//username.text = "Hello " + ParseUser.CurrentUser.Username;
					}
				}
			});


		}
		
		

*/


	
}

	
	
	
}
