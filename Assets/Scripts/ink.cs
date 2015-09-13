using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class ink : MonoBehaviour {

	public Slider slider; 
	public Vector2 pos = new Vector2(20, 40);
	public Vector2 size = new Vector2(20, 60);
	public float speed = 0.3f;

	// Use this for initialization
	void Start () {
		slider.value = 400f;
	}
	
	// Update is called once per frame
	void Update () {
		/*
		slider.value -= speed * Time.deltaTime;
		NOTE slider goes down with time
		*/
	
		if (Input.GetMouseButton (0) || Input.GetMouseButtonDown (0) || Input.GetMouseButtonUp(0)) {
			slider.value -= 1f;

			//slider.value -= speed * Time.deltaTime;

			//slider.value = Mathf.MoveTowards (slider.value, 0.0f, 10.0f);

		}	
	}
	

}
