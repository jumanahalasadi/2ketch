using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using Parse;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class UIController : MonoBehaviour {

	public string username;
	public string password;
	public string email;

	bool result = false;


	public void SetUsername(string value) {
		username = value;
		Debug.Log ("username variable now holds: "+username);
	}

	public void SetPassword(string value) {
		password = value;
		Debug.Log ("password variable now holds: "+password);
	}

	public void SetEmail(string value) {
		email = value;
		Debug.Log ("email variable now holds: "+email);
	}

	public void niggadough(string value){
	/*
		var user = new ParseUser()
		{
			//Username = "my name",
			//Password = "mypass",
			//Email = "email@example.com"

			Username = username,
			Password = password,
			Email = email,

		};


		// other fields can be set just like with ParseObject
		//user["Gender"] = false;
		
		Task signUpTask = user.SignUpAsync();
		Debug.Log ("GONE TO DB");


*/


		VerifyEmailAddress(email);

		if (result == true) {
			//DontDestroyOnLoad(gameObject);
			//Application.LoadLevel ("signup_2");
			/*
			ParseUser.LogInAsync(username, password).ContinueWith(t =>
			                                                      {
				if (t.IsFaulted || t.IsCanceled)
				{
					// The login failed. Check the error to see why.
					Debug.Log("Logged in too");
				}
				else
				{
					// Login was successful.
				}
			});

*/

		} else {

			Debug.Log ("Not a valid email address!: "+email);
		}

	}
	
	public void  VerifyEmailAddress (string address){
			string[] atCharacter;
			string[] dotCharacter;
			atCharacter = address.Split("@"[0]);
			if(atCharacter.Length == 2){
				dotCharacter = atCharacter[1].Split("."[0]);
				if(dotCharacter.Length >= 2){
					if(dotCharacter[dotCharacter.Length - 1].Length == 0){
						result = false;
					}
					else{
						result = true;
					}
				}
				else{
					result = false;
				}
			}
			else{
				result = false;
			}
		}

//	public void ConvertTexture2D(){
//		byte[] data = userImage.EncodeToPNG();
//		ParseFile file = new ParseFile("user.png", data);
//		Task saveTask = file.SaveAsync();
//		
//		ParseQuery<ParseObject> query = ParseObject.GetQuery("Players");
//		query.GetAsync(Constant.ParseID).ContinueWith(t =>
//		                                              {
//			PlayerData = t.Result;
//			UpdateOldUser(file);
//			
//		});
//	}

	public void  Start (){
		UploadPNG ();
		//Debug.Log ("start");
	}
	
	public void  UploadPNG (){

		Debug.Log ("start2");
		// We should only read the screen buffer after rendering is complete
		//yield return new WaitForEndOfFrame();
		
		// Create a texture the size of the screen, RGB24 format
		var width= Screen.width;
		var height= Screen.height;
		var tex= new Texture2D (width, height, TextureFormat.RGB24, false);
		// Read screen contents into the texture
		tex.ReadPixels ( new Rect(0, 0, width, height), 0, 0);
		tex.Apply ();
		



	//	var file = new ParseFile()
	//	{
			//Username = "my name",
			//Password = "mypass",
			//Email = "email@example.com"
			
//			Username = username,
//			Password = password,
//			Email = email

			//png = new ParseFile("thumb.png",tex.EncodeToPNG());
//			png = "hello"
			
	//	};

//		Task upfile = file.SaveAsync();

		//var obj = new ParseObject("TestObject");
		//obj["file"] = file;
		//await obj.SaveAsync();

		
		//Task signUpTask = file.SignUpAsync();



		Debug.Log ("finish");
		
	}

}
