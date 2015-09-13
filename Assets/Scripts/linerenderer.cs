using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class linerenderer : MonoBehaviour {

	public List<Vector3> thePath = new List<Vector3>();
	public List<LineRenderer> Lines = new List<LineRenderer>();
	RaycastHit myhit = new RaycastHit();
	Ray myray = new Ray();
	public LineRenderer lineRender;
	public string dtxt; 
	bool mousedown = false;
	int numberOfPoints = 0;
	public Camera cam;
	public LineRenderer line;
	public Slider sliderV;
	public Slider slider; 


	//
	/// For da bae - new way
	/// 
	/// 
	///

	public GameObject lineDrawPrefabs; //this is where we put the prefabs object

	private bool isMousePressed;
	private GameObject lineDrawPrefab;
	private LineRenderer lineRenderer;
	private List<Vector3> drawPoints = new List<Vector3>();


	///
	/// --end of new way
	///
	///

	// Use this for initialization
	void Start () {
		isMousePressed = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {
			//UNDO OR CLEAR

			//Delete the line renderers when right mouse down
			GameObject [] delete = GameObject.FindGameObjectsWithTag ("LineDraw");
			int deleteCount = delete.Length;

			for(int i= deleteCount - 1; i >= 0; i--){
				Destroy (delete[i]); 
			}

		}

		if (Input.GetMouseButtonDown (0)) {

			//MAKE NEW LINE RENDERER
			isMousePressed = true;
			lineDrawPrefab = GameObject.Instantiate (lineDrawPrefabs) as GameObject;
			lineRenderer = lineDrawPrefab.GetComponent<LineRenderer> ();
			lineRenderer.SetVertexCount (0);

		} else if (Input.GetMouseButtonUp (0)) {

			//let go of mouse
			isMousePressed = false;
			drawPoints.Clear ();
		
		}

		if (isMousePressed && slider.value>0) {

			//when mouse is pressed continue to add vertex to line renderer
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 1.0f;

			lineRenderer.SetWidth (sliderV.value, sliderV.value+0.05f);

			if(!drawPoints.Contains (mousePos))
			{
				drawPoints.Add (mousePos);
				lineRenderer.SetVertexCount (drawPoints.Count);
				lineRenderer.SetPosition (drawPoints.Count -1, mousePos);
			}


		

		}


		if (isMousePressed) {
			/*
			//public GameObject respawnPrefab;
			GameObject respawns;

			respawns = GameObject.FindGameObjectsWithTag("Disappear");
			
			foreach (GameObject respawn in respawns) {
				Color dropColor = respawn.renderer.material.color;
				dropColor.a = .1f;
				respawn.renderer.material.color = dropColor;

				respawn.renderer.material.color.a = 0.5f;
			}

			*/

			//GetComponent<CanvasGroup>().alpha = 0;
		}

/*
		dtxt = "";

		line.SetWidth (sliderV.value, sliderV.value);
		if (Input.GetKey (KeyCode.Mouse0) && slider.value > 0) {
			numberOfPoints++;
			lineRender.SetVertexCount (numberOfPoints);
			Vector3 mousePos = new Vector3 (0, 0, 0);
			mousePos = Input.mousePosition;
			mousePos.z = 1.0f;
			Vector3 worldPos = new Vector3 (0, 0, 0);
			worldPos = cam.ScreenToWorldPoint (mousePos);
			lineRender.SetPosition (numberOfPoints - 1, worldPos);
			Debug.Log (mousePos);
		
		} 

		else {
			//numberOfPoints = 0;
			//lineRender.SetVertextCount(0);
		}

*/

	}




}

