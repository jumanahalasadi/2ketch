using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;


public class getprofileinfo : MonoBehaviour {

	public Image profilepic;
	public Text username;
	private string objectID;
	public Text hello;
	// Use this for initialization
	void Start () {

		//username.text = objectID;
	}
	
	// Update is called once per frame
	void Update () {
		hello.text = ParseUser.CurrentUser.Username;

	}

	public void display(){
		StartCoroutine(LoadFile());
		
		objectID = ParseUser.CurrentUser.ObjectId;
		username.text = ParseUser.CurrentUser.Username;

	}
	IEnumerator LoadFile()   //single method downloads file
	{
		Debug.Log("LoadFile()");

		string oid; 
		oid = ParseUser.CurrentUser.ObjectId;
		Debug.Log (oid);

		/*
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("User").WhereEqualTo("objectId", oid);
		

	


		var queryTask = query.FirstAsync();
		while (!queryTask.IsCompleted) yield return null;
		
		ParseObject obj = queryTask.Result;

*/	

		Parse.ParseQuery<Parse.ParseUser> query = ParseUser.Query.WhereEqualTo("objectId", oid);
		var queryTask = query.FirstAsync();
		while (!queryTask.IsCompleted) yield return null;
		
		ParseObject obj = queryTask.Result;


		//ParseUser obj = null;
		//ParseUser.Query.GetAsync ("2VPYKGrm1c").ContinueWith (t =>
			
		                                                  //  {



		//	 obj = t.Result;

		
				
		//});

		
		ParseFile pfile = obj.Get<ParseFile>("Avatar");
		Debug.Log (pfile.Url.AbsoluteUri);
		
		var imageRequest = new WWW(pfile.Url.AbsoluteUri);
		yield return imageRequest;      
		Debug.Log ("imageRequest " + imageRequest.text);
		
		Texture2D texture = imageRequest.texture;


		//snote 
		/*
		var width2 = Screen.width/2;
		var height2 = Screen.height/2;
		Sprite sprite = Sprite.Create(texture, new Rect(Screen.width/3,Screen.height/3, width2, height2), new Vector2(0f,0f)); 

*/
		var width2 = 373;
		var height2 = 663;
		
		
		Sprite sprite = Sprite.Create(texture, new Rect(0,0, width2, height2), new Vector2(0f,0f)); 


/*
		var width2 = 373/2;
		var height2 = 663/2;

		
		Sprite sprite = Sprite.Create(texture, new Rect(150,270, width2, height2), new Vector2(0f,0f)); 

*/
		profilepic.sprite = sprite; //no 7 up

  
	
	}
}
