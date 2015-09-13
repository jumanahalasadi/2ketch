using UnityEngine;
using System.Collections;
using System.IO;
public class screenshot : MonoBehaviour {
	
	// Use this for initialization
	
	// Update is called once per frame
	public void SceneChange2 (string sceneToChangeTo) {
		//Application.CaptureScreenshot("ammar.png", 3);
		
		Application.CaptureScreenshot(Application.persistentDataPath + "/ammar.jpg", 1);
		
		
		Application.LoadLevel(sceneToChangeTo);
	}
}
