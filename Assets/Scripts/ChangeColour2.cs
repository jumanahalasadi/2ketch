using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ChangeColour2 : MonoBehaviour
{
	//Before we start, we need to STORE some variables that can be accessed in the editor, and can be used throughout the script.
	
	//Our first variable will be the texture displayed on the screen, so we can choose the colour from it
	public Texture2D colourTexture;

	public LineRenderer path;

	public Slider ink; 

	private bool mousedown = false;
	
	//Next, we want to STORE the Renderer of the cube in the scene, this way we can change the colour of the material on it
	//public Renderer colouredCube;
	
	//lastly we store a Rect that describes where our texture is going to be displayed on the screen.
	//manny//private Rect textureRect = new Rect (700, 1300, 350, 350); 


	//private Rect textureRect = new Rect (400, 800, 350, 350); 	//lena

	private Rect textureRect = new Rect (15, 50, Screen.width/5, Screen.height/2); 

	private Color defaultC = UnityEngine.Color.black;
	private Color guiColor;
	void start(){
		path.SetColors (Color.cyan, Color.cyan);
		var fill = (ink).GetComponentsInChildren<UnityEngine.UI.Image>()
			.FirstOrDefault(t => t.name == "Fill");	fill.color = defaultC;
		if (fill != null)
		{	
			fill.color = defaultC;
		}

	}

	//Now everything else is done within the OnGUI function.
	void OnGUI ()
	{

		//path.SetColors (Color.cyan, Color.cyan);

		//Simply just draw our texture in the position we gave it at the beginning
		GUI.color = guiColor;
		GUI.color = Color.white;

		//GUI.DrawTexture (textureRect, colourTexture); 

		if (Input.GetMouseButtonDown (0)) {
			//colourTexture.l
			mousedown= true;
		
		}

		if (Input.GetMouseButtonUp (0)) {
			mousedown = false;
		}

		if (mousedown) {

		} else {
			if(ink.value > 0){
			GUI.DrawTexture (textureRect, colourTexture); 
			}

		}
		
		//We want to check what event is happening during OnGUI. In this case we want to check if the mouse button has been released, so that we know if the user clicked on the texture or not
		if (Event.current.type == EventType.MouseUp) {
			
			//get the mouse position
			Vector2 mousePosition = Event.current.mousePosition;
			
			//if the mouse position is outside the texture being displayed on the screen, just exit out because we dont want to do anything.
			if (mousePosition.x > textureRect.xMax || mousePosition.x < textureRect.x || mousePosition.y > textureRect.yMax || mousePosition.y < textureRect.y) {
				return;
			}
			
			//if we made it here, we know that the mouse is somewhere on the texture. Since we know this, we need to figure out a way to get the colour of the texture, wherever the mouse currently is. In order to do this, we need to calculate the UV coordinates of the mouse on the texture
			float textureUPosition = (mousePosition.x - textureRect.x) / textureRect.width;
			float textureVPosition = 1.0f - ((mousePosition.y - textureRect.y) / textureRect.height);
			
			//Once we have the UV coordinates, we use a function called GetPixelBilinear on the texture. This will return the colour of the texture at the given UV coordinates. 
			Color textureColour = colourTexture.GetPixelBilinear (textureUPosition, textureVPosition);
			
			// and now that we have our colour, we just APPLY it to the cube's material
			//colouredCube.material.color = textureColour;

			//path.SetWidth(0.001f,0.002f);
			path.SetColors (textureColour, textureColour);
			//var fill = ink.GetComponentInChildren<UnityEngine.UI.Slider.print("Fill");
				//<UnityEngine.UI.Image>

			var fill = (ink).GetComponentsInChildren<UnityEngine.UI.Image>()
				.FirstOrDefault(t => t.name == "Fill");
			if (fill != null)
			{
			
				fill.color = textureColour;
			}



		}
	}
}