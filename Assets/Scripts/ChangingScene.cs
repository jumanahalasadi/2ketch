using UnityEngine;
using System.Collections;
using System.IO;
public class ChangingScene : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	public void SceneChange (string sceneToChangeTo) {
		//Application.CaptureScreenshot("ammar.png", 3);

		Application.CaptureScreenshot(Application.persistentDataPath + "/Screenshot.png", 1);


		Application.LoadLevel(sceneToChangeTo);
	}
}
