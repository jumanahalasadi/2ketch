using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dontdestroy : MonoBehaviour {

	public InputField userinput;
	public string oid;
	public Text component; 
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {

		component = this.GetComponent<Text> ();
		oid = userinput.text;
		component.text = oid;
	}
}
