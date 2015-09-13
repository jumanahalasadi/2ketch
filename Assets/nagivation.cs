using UnityEngine;
using System.Collections;

public class nagivation : MonoBehaviour {
	public GameObject Home;
	public GameObject Newsfeed;
	public GameObject Explore;
	public GameObject Profile;

	
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void click_home(){

		Home.SetActive (true);
		Newsfeed.SetActive (false);
		Explore.SetActive (false);
		Profile.SetActive (false);

	}

	public void click_Newsfeed(){


		Newsfeed.SetActive (true);
		Explore.SetActive (false);
		Profile.SetActive (false);
		Home.SetActive (false);
	}
	public void click_Explore(){
		
		Newsfeed.SetActive (false);
		Explore.SetActive (true);
		Profile.SetActive (false);
		Home.SetActive (false);

	}
	public void click_Profile(){
		Newsfeed.SetActive (false);
		Explore.SetActive (false);
		Profile.SetActive (true);
		Home.SetActive (false);
		
	}
}
