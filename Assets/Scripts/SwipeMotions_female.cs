using UnityEngine;
using System.Collections;

public class SwipeMotions_female : MonoBehaviour 
{
	
	public float minSwipeDistY;
	
	public float minSwipeDistX;
	
	private Vector2 startPos;

	public int counter = 0;
	

	void Start(){
	
	//target = GameObject.Find("female");
		counter = 0;
	
	}


	void Update()
	{
		/*

		if(Input.GetKeyDown("e")){

			Debug.Log("testing");
			//GetComponent<Animation>().Play("female.New Animation");
			//animation.Play ();
			//this.GetComponent<Animation>().Play("female");
			//female.AddComponent(typeof("female"));
			
			//target.animation.CrossFade("female_anim");

			//female.transform.position.y = 90;
			if(counter % 2 == 0) {
			transform.position += Vector3.left * 85;
			transform.position += Vector3.up * 30;
			transform.localScale += new Vector3(2.3F, 2.3F, 2.3F);
				counter++;
			}
			//male.transform.position += Vector3.left * 80;

		}

		if (Input.GetKeyDown ("p")) {
			if(!(counter % 2 == 0)) {
			transform.position += Vector3.left * -85;
			transform.position += Vector3.up * -30;
			transform.localScale += new Vector3(-2.3F, -2.3F, -2.3F);
				counter++;
			}
		}
		
		//#if UNITY_ANDROID
		if (Input.touchCount > 0) {
			
			Touch touch = Input.touches [0];
			
			
			
			switch (touch.phase) {
				
			case TouchPhase.Began:
				
				startPos = touch.position;
				
				break;
				
				
				
			case TouchPhase.Ended:
				
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				
				if (swipeDistVertical > minSwipeDistY) {
					
					float swipeValue = Mathf.Sign (touch.position.y - startPos.y);
					
					if (swipeValue > 0)//up swipe
						
						//Jump ();
						return;
					else if (swipeValue < 0)//down swipe
							
							//Shrink ();
						return;
							
				}
				
				float swipeDistHorizontal = (new Vector3 (touch.position.x, 0, 0) - new Vector3 (startPos.x, 0, 0)).magnitude;
				
				if (swipeDistHorizontal > minSwipeDistX) {
					
					float swipeValue = Mathf.Sign (touch.position.x - startPos.x);
					
					if (swipeValue > 0) {//right swipe
						
						//	if(counter % 2 == 0) {
						transform.position += Vector3.left * 85;
						transform.position += Vector3.up * 30;
						transform.localScale += new Vector3 (2.3F, 2.3F, 2.3F);
						counter++;

						//GetComponent<Animation>().Play("New Animation");
						
						//	}
					} else if (swipeValue < 0) {//left swipe
							
						//if(!(counter % 2 == 0)) {
						transform.position += Vector3.left * -85;
						transform.position += Vector3.up * -30;
						transform.localScale += new Vector3 (-2.3F, -2.3F, -2.3F);
						counter++;
						//	}

						return;	
					}

				}
					break;
				
			}
		}
		*/
	}
}