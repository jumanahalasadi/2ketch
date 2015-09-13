using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;


public class listofgames : MonoBehaviour {

	public Text textbox; 
	public string oid;
	public InputField inputfield;
	//public List<string> list = new List<string> ();

	//public List<List<string>> list = new List<List<string>>();
	public List<string> list = new List<string> ();

	public List<string> gameinfo = new List<string> ();
	public int size;
	private int count;
	private string theword;
	private int turnsleft;
	private string player_host_e;
	private string player_client_o;
	public Button prefab;
	public Button playButton; 
	public Text msg; 
	public InputField gameinput;
	public string gameID;
	public string username; 
	public Vector2 scrollPosition = Vector2.zero;
	
	GUIStyle buttonstyle;
	



	// Use this for initialization
	void Start () {
		//list.Add (new List<string>() );

		buttonstyle =  new GUIStyle();
		buttonstyle.fontSize = 18; 
		//buttonstyle.border = 
		GUI.color = Color.cyan;


	
		if (ParseUser.CurrentUser != null) {

			count = 0;
			var query1 = ParseObject.GetQuery ("Game")
			.WhereEqualTo ("player_host_e", ParseUser.CurrentUser.Username);
		
			var query2 = ParseObject.GetQuery ("Game")
			.WhereEqualTo ("player_client_o", ParseUser.CurrentUser.Username);



			query1.FindAsync ().ContinueWith (z => {

				
				IEnumerable<ParseObject> games = z.Result;
			
				foreach (ParseObject game in games) {

					Debug.Log ("GAMEEEE");
				
					//oid = oid + " " + game.ObjectId;

					//gameinfo.Clear ();
					count++;

					
					list.Add (game.ObjectId);
					//list.Add (getgameinfo(game.ObjectId));

				}
			
			
			
			});
			
			query2.FindAsync ().ContinueWith (z => {
			
				IEnumerable<ParseObject> games = z.Result;
			
				foreach (ParseObject game in games) {

					Debug.Log ("GAMEEEE");
						
					oid = oid + " " + game.ObjectId;
			

					list.Add (game.ObjectId);
					//list.Add (getgameinfo(game.ObjectId));
					//gameinfo.Clear ();
					count++;

				}
			
			
			
			});
	
		}


	

		//	j += Screen.height/9 ;
			
		//}x

		/*

		size = list.Count;
		
		for (int i = 0; i < size; i++) {
			
			Button newButton = Instantiate(prefab, new Vector3 (0,0,0), new Quaternion (0f,0f,0f,0f)) as Button; 
			newButton.transform.SetParent(GameObject.Find("Canvas").transform, false);
			var text = newButton.GetComponent<Text>();
			//			text.text = list[i] ;
			
			//newButton.transform.parent = GameObject.Find("Canvas").transform;
			newButton.transform.localPosition = new Vector3 (-200,100, 0);
			
		}
	*/
	
	}


	
	// Update is called once per frame
	void Update () {


		//textbox.text = oid;

	}

	void OnGUI(){

		GUI.backgroundColor = Color.cyan;

		int width = list.Count * (Screen.height/8);

		scrollPosition = GUI.BeginScrollView(new Rect(10, Screen.height/4, Screen.width-20, Screen.height/7), scrollPosition, new Rect(0, 0, width,Screen.height/9), Resources.Load ("New GUISkin"),  Resources.Load ("New GUISkin"));

//		GUI.HorizontalScrollbar = false;
		size = list.Count;
		for (int i = 0, j = 20; i <size; i++) {
			//Debug.Log ("im doin this");
			//getgameinfo(list[i]);
			//list[i];
/*
			if (GUI.Button (new Rect (j, Screen.height/3, Screen.height/10, Screen.height/10), list[i]	)) {

					inputfield.text = list[i];
					
				decrementTurns();
					

			}
			
*/	
			int order = i + 1;
			if (GUI.Button (new Rect (j, 0, Screen.height/10, Screen.height/10), "Game " + order 	)) {
				
				inputfield.text = list[i];

	
				decrementTurns();
				
				
			}




			j += Screen.height/9 ;


		}

		GUI.EndScrollView();



	
	}

	public string getgameinfo(string gameoid){

		string msg = "";
		//gameinfo.Clear ();
		
		ParseQuery<ParseObject> query3 = ParseObject.GetQuery ("Game");
		query3.GetAsync (gameoid).ContinueWith (f => {
			
			ParseObject specific_game = f.Result;
			player_host_e = specific_game.Get<string> ("player_host_e");
			player_client_o = specific_game.Get<string>("player_client_o"); 
			
			theword = specific_game.Get<string> ("Word");
			turnsleft = specific_game.Get<int> ("TurnsLeft");
		});
		/*


		if (player_host_e == ParseUser.CurrentUser.Username) { //he is even
			
			if (turnsleft % 2 == 0) {//even
				msg = "Your turn";
			}
			else
				msg = "Waiting";


		} else if (player_client_o == ParseUser.CurrentUser.Username) { //he is odd
				
			if (turnsleft % 2 != 0) {//even
				msg = "Your turn";
			}
			else
				msg = "Waiting";


		}


		gameinfo.Add (gameoid);
		
		gameinfo.Add (theword);
		
		gameinfo.Add (turnsleft + " ");

		gameinfo.Add (msg);

*/

		return theword;

	}

	public void refresh(){
		//list.Add (new List<string>() );





		oid = "";
		list.Clear ();
		//gameinfo.Clear ();

		count = 0;
		count = 0;
		var query1 = ParseObject.GetQuery("Game")
			.WhereEqualTo("player_host_e", ParseUser.CurrentUser.Username);
		
		var query2 =  ParseObject.GetQuery("Game")
			.WhereEqualTo("player_client_o", ParseUser.CurrentUser.Username);
		

		query1.FindAsync().ContinueWith (z => {
			
			
			IEnumerable<ParseObject> games = z.Result;
			
			foreach (ParseObject game in games){
				
				Debug.Log ("GAMEEEE");
				
				oid = oid + " " + game.ObjectId;
				
				//gameinfo.Clear ();
				count++;
				
				list.Add(game.ObjectId);
			}

			
		});
		
		query2.FindAsync().ContinueWith (z => {
			
			IEnumerable<ParseObject> games = z.Result;
			
			foreach (ParseObject game in games){
				
				Debug.Log ("GAMEEEE");
				
				oid = oid + " " + game.ObjectId;
				
				list.Add (game.ObjectId);
				//gameinfo.Clear ();
				count++;
				
			}
			
			
			
		});



		

	}


	public void decrementTurns(){
		
		username = ParseUser.CurrentUser.Username;
		
		//if (gameinput.text == "zsJmOYCsIQ") {
		//Debug.Log ("Correct");
		gameID = gameinput.text;
		
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Game");
		query.GetAsync (gameID).ContinueWith (z => {
			
			ParseObject game = z.Result;
			
			player_host_e = game.Get<string> ("player_host_e");
			player_client_o = game.Get<string>("player_client_o"); 
			turnsleft = game.Get<int> ("TurnsLeft");
			
		});


		
		
		
		
		if (player_host_e == username ||  player_client_o == username) {
			
			if (player_host_e == username ) { // he is even
				
				if (turnsleft > 0) {
					
					
					if (turnsleft % 2 == 0) {//even
						//next.interactable = true;
						
						Application.LoadLevel (1);
						msg.text = "Click Play!";
						
						
					} 
					else {
						msg.text = "Its not your turn yet!";
					}
					
					
				} 
				
				else if (turnsleft == 0){
					msg.text = "GAME OVER";
				}
				
				
			} 
			
			else if (player_client_o == username) { // he is odd
				if (turnsleft > 0) {
					
					if (turnsleft % 2 != 0) {
						//next.interactable = true;
						
						
						msg.text = "Click Play!";
						Application.LoadLevel (1);
						
						
					} 
					else {
						msg.text = "Its not your turn yet!";
					}
					
				} 
				else{
					msg.text = "GAME OVER";
				}
				
			}
			
			
		}
		else if (player_host_e != username && player_client_o != username) { //hes not part of this game
			//next.interactable = false;
			msg.text = "Parse is freezing: Try again!";
		}
		
		
	}


}
