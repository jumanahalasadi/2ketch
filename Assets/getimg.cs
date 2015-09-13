using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class getimg : MonoBehaviour {

	
	public GameObject UIFBAvatar; 
	public GameObject UIFBUserName;

	//storing our profile information
	private Dictionary<string, string> profile = null; 
	// Use this for initialization
	void Awake () {
		FB.API (Util.GetPictureURL ("me", 128, 128), Facebook.HttpMethod.GET, DealWithProfilePicture);
		FB.API ("/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName); 

	}

	void DealWithProfilePicture(FBResult result){
		if (result.Error != null) {
			
			Debug.Log ("problem with getting profile picture");
			FB.API (Util.GetPictureURL ("me", 128, 128), Facebook.HttpMethod.GET, DealWithProfilePicture);
		
			return;
		}
		//if we actually get the picture
		
		Image UserAvatar = UIFBAvatar.GetComponent<Image> ();
		UserAvatar.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 (0, 0));
		
	}


	void DealWithUserName(FBResult result){

		if (result.Error != null) {
			
			Debug.Log ("problem with getting username");
			FB.API ("/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUserName); 

		
			return;
		}

		profile = Util.DeserializeJSONProfile (result.Text);

		Text UserMsg = UIFBUserName.GetComponent<Text> (); 

		UserMsg.text = profile ["first_name"];
	}

}
