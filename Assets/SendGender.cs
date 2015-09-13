using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using Parse;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

public class SendGender : MonoBehaviour {

	public Image background;
	private int counter;
	public Sprite female;
	public Sprite male;
	public Text msg;
	public bool IsFemale;

	// Use this for initialization
	void Start () {
		counter = 1;

	}

	
	// Update is called once per frame
	void Update () {
		//odd is male
		//even is female
		if (Input.GetMouseButtonDown(0)) {
			counter++;
		}

		if (counter % 2 == 0) {//even
			background.sprite = female;
				IsFemale = true;
			//msg.text = "FEMALE";
			msg.text =  counter + "";
			//int number = int.Parse (msg.text); 
		//	Debug.Log (number);
		}
		else {
			background.sprite = male;
			IsFemale = false;
			//msg.text = "MALE";
			msg.text = counter + "";
			//int number = int.Parse (msg.text); 
			//Debug.Log (number);
		}


	}

	public void sendGenderToDB(){
		//string oid; 
		//oid = ParseUser.CurrentUser.ObjectId;
		//Debug.Log (oid);

		//ParseUser.CurrentUser ["Gender"] = IsFemale;

		
	
	}
}
