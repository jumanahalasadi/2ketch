
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class linescript : MonoBehaviour {

	public GameObject particle;
	public LineRenderer line;
	public Slider sliderV;
//	Vector3 aPosition = new Vector3 (100,100,10);
//	Vector3 aPosition2 = new Vector3 (200,100,10);
	public static Vector3 mousePosition;
//	public Vector3[] name = new Vector3[2]; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {


		line.SetWidth (sliderV.value, sliderV.value);

	}
}