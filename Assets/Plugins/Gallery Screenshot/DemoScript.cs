using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using Parse;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Runtime.Serialization.Formatters.Binary.BinaryFormatter;

public class DemoScript : MonoBehaviour {
	
	public Texture2D texture;
	bool savedScreenshot = false;
	bool savedExistingImage = false;
	bool hideGUI = false;
	public Slider inkslider;
	public Canvas canvas;
	public Image wegotthis;
	public GameObject done_g;
	public Button done;
	public GameObject gameid;
	public string GAMEID;
	public Text component;

	//public Sprite spritedoodle; 

	void Start ()
	{

		
		gameid = GameObject.Find("DONTDESTROY");
		
		component = gameid.GetComponent<Text> ();
		
		GAMEID = component.text;
		
		//Debug.Log ("The gameid" + GAMEID);


		done.interactable = false;

		StartCoroutine(LoadFile());
		//done_g.SetActive (false);



		// call backs
		ScreenshotManager.ScreenshotFinishedSaving += ScreenshotSaved;	
		ScreenshotManager.ImageFinishedSaving += ImageAssetSaved;
	
		//wegotthis.sprite = spritedoodle;

	}

	void Update (){
		if (inkslider.value == 0) {
			done.interactable = true;

		}
	
	

	}
	void OnGUI ()
	{
	

		// this if statement will remove the GUI buttons from
		// the screen for the screenshot
		if(!hideGUI)
		{
			if(inkslider.value < 1 ) {
			// option 1 - save a screenshot
				//if(GUILayout.Button ("OK", GUILayout.Width (150), GUILayout.Height(150)))
				{	
					// the most important line - this is how you grab a screenshot!
					StartCoroutine(ScreenshotManager.Save("MyScreenshot", "ScreenshotApp", true));
					HideGUI();


					UploadPNG ();

					
					ParseQuery<ParseObject> query1 = ParseObject.GetQuery ("Game");
					query1.GetAsync (GAMEID).ContinueWith (z => {
						
						ParseObject gamebeg = z.Result;
						
						gamebeg.Increment("TurnsLeft", -1);
						
						Task saveTask = gamebeg.SaveAsync();
						
					});


	
					Application.LoadLevel (0);

				}

			}
		}
	}
	
	void HideGUI ()
	{
		//done_g.SetActive (false);
		hideGUI = true;
		
		//yield return new WaitForEndOfFrame();
		
		//hideGUI = false;	
	}
	
	void ScreenshotSaved(string path)
	{
		Debug.Log ("screenshot finished saving to " + path);
		savedScreenshot = true;
	}
	
	void ImageAssetSaved(string path)
	{
		Debug.Log (texture.name + " finished saving to " + path);
		savedExistingImage = true;
	}

	private byte[]  ObjectToByteArray(Object obj){
		
		if (obj == null)
			return null;
		BinaryFormatter bf = new BinaryFormatter ();
		using (MemoryStream ms = new MemoryStream())
		{
			bf.Serialize (ms, obj);
			return ms.ToArray ();
			
		}
		
		
	}


	void UploadPNG () {
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

		ParseFile file2 = new ParseFile("myscreenshoto.png", bytes);
	
		Task saveTask = file2.SaveAsync();

		/*
		var game = new ParseObject("Game");
		game["name"] = "Screenshotpp";
		game["File"] = file2;
		
		Task saveTask2= game.SaveAsync();

*/



		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Game");
		query.GetAsync(GAMEID).ContinueWith( t => {
			
			ParseObject game = t.Result;
			Debug.Log ("Its inside");

			
			game["name"] = "Updated";
			game["File"] = file2;
			
			Task saveTask3= game.SaveAsync();
			


		});
		//Application.LoadLevel ("Home");
		Application.LoadLevel (0);
		//ObjectToByteArray(tex);

		//Destroy (tex);

	

	
		// For testing purposes, also write to a file in the project folder
		//File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

	}


	IEnumerator LoadFile()   //single method downloads file
	{
		gameid = GameObject.Find("DONTDESTROY");
		
		component = gameid.GetComponent<Text> ();
		
		GAMEID = component.text;
		Debug.Log("LoadFile()");
		
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Game").WhereEqualTo("objectId", GAMEID);

		
		var queryTask = query.FirstAsync();
		while (!queryTask.IsCompleted) yield return null;
		
		ParseObject obj = queryTask.Result;
		
		ParseFile pfile = obj.Get<ParseFile>("File" );
		Debug.Log (pfile.Url.AbsoluteUri);
		var imageRequest = new WWW(pfile.Url.AbsoluteUri);
		yield return imageRequest;      
		Debug.Log ("imageRequest " + imageRequest.text);

		Texture2D texture = imageRequest.texture;


		var width2 = Screen.width;
		var height2 = Screen.height;
		
		Sprite sprite = Sprite.Create(texture, new Rect(0,0, width2, height2), new Vector2(0f,0f)); 

		wegotthis.sprite = sprite; //no 7 up
	}
	
	
	
	
	
}