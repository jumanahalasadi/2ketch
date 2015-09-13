using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using Parse;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class getAvatar : MonoBehaviour {

	private bool gender_female;
	public Image background;
	public Sprite female;
	public Sprite male;
	public InputField username;
	public InputField password;
	public InputField email;
	public Text counterstring;
	private string username2;
	private string password2;
	private string email2;
	public GameObject signupinfo;


	// Use this for initialization
	void Start () {
	

	}
	
	void ChangeB(bool gender_female){
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Avatars");
		query.GetAsync ("iZzyJYdiMJ").ContinueWith (z => {
			
			ParseObject gamebeg = z.Result;
			
			gender_female = gamebeg.Get<bool> ("Gender");
			
			if(gender_female){
				Debug.Log ("Its a female");

			}
			else {
				Debug.Log ("its not");

			}
			
		});
		*/

		int number = int.Parse (counterstring.text); 
		number--;

		if (number % 2 == 0) {//even

			gender_female = true;

		} else {
			gender_female = false;
		}


		if (gender_female) {
			background.overrideSprite = female;
			background.sprite = female;
		} else if (gender_female == false) {
			background.overrideSprite = male;
			background.sprite = male;
		}
		



	}

	public void UploadPNG () {
		//We should only read the screen buffer after rendering is complete
		//yield WaitForEndOfFrame();
		
		// Create a texture the size of the screen, RGB24 format
		var width = Screen.width;
		var height = Screen.height;
		var tex = new Texture2D (width, height, TextureFormat.RGB24, false);
		// Read screen contents into the texture
		//StartCoroutine(HideGUI());
		tex.ReadPixels (new Rect (0, 0, width, height), 0, 0);

		tex.Apply ();
		

		// Encode texture into PNG
		var bytes = tex.EncodeToPNG();
		//bytes.
		
		ParseFile file2 = new ParseFile("myavatar.png", bytes);

		int number = int.Parse (counterstring.text); 
		number--;

	
		
		// other fields can be set just like with ParseObject
		//user["Gender"] = false;

		Debug.Log ("GONE TO DB");
		signupinfo.SetActive (true);
		username2 = username.text;
		password2 = password.text;
		email2 = email.text;


		var user = new ParseUser()
		{
			//Username = "my name",
			//Password = "mypass",
			//Email = "email@example.com"
			
			/*Username = "jumanahalasadi",
			Password = "unknown",
			Email = "jumanah222@hotmail.com",

*/

			Username = username2,
			Password = password2,
			Email = email2,

			
		};
		user ["Avatar"] = file2;
		user ["Gender"] = gender_female;
		user ["phone"] = "864";

		
		
		// other fields can be set just like with ParseObject
		//user["Gender"] = false;
		
		Task signUpTask = user.SignUpAsync();

		Debug.Log (signUpTask.Exception);

		if (signUpTask.IsCompleted) {
			Debug.Log ("ye");

		} else
			Debug.Log ("Lol");

		
		ParseUser.LogOut ();
		
	
		//Debug.Log ("GONE TO DB");


		/*
		Task saveTask = file2.SaveAsync();
		
		var game = new ParseObject("Avatars");
		//game["name"] = "Screenshotpp";
		game["Avatar"] = file2;
		
		Task saveTask2= game.SaveAsync();
		*/

		////////////////////////////////////////GOOGIIE
		/*var game = new ParseObject("Avatars");
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Avatars");
		query.GetAsync("iZzyJYdiMJ").ContinueWith( t => {
			
			game = t.Result;
		//Debug.Log ("Its inside");
			
			
			game["Avatar"] = file2;
			
		Task saveTask3= game.SaveAsync();

			
			
		});  */
		////////////////////////////GOOGIE




		//Application.LoadLevel (2);
		//ObjectToByteArray(tex);
		
		//Destroy (tex);
		
		
		
		
		// For testing purposes, also write to a file in the project folder
		//File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);
		
	}
	


}
