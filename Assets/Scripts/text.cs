using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class text : MonoBehaviour {

	public Slider slider; 

	public Text inkleft; 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		inkleft.text = Mathf.Round((slider.value/4)) + "%"; 
	}
}
