using UnityEngine;
using UnityEngine.UI;
using Parse;
using System.Collections;
using System.Threading.Tasks;

public class gettingGame : MonoBehaviour {

	public InputField gameinput;
	public Button next;
	public Text msg;
	private int turnsleft;
	public string gameID;
	private string player_host_e;
	private string player_client_o;


	// Use this for initialization
	void Start () {
		next.interactable = false;

		/*
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Game");
		query.GetAsync ("zsJmOYCsIQ").ContinueWith (z => {
			
			ParseObject gamebeg = z.Result;
			
			turnsleft = gamebeg.Get<int> ("TurnsLeft");


		});

*/
	

	}
	
	// Update is called once per frame
	void Update () {

		if (gameinput.text == "") {
			next.interactable = false;

		} else {
			next.interactable = true;
		}

	}


	public void decrementTurns(){



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



	
			if (ParseUser.CurrentUser.Username == player_host_e || ParseUser.CurrentUser.Username == player_client_o) {
				
				if (player_host_e == ParseUser.CurrentUser.Username) { // he is even
					
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

			else if (player_client_o == ParseUser.CurrentUser.Username) { // he is odd
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
		else if (ParseUser.CurrentUser.Username != player_host_e && ParseUser.CurrentUser.Username != player_client_o) { //hes not part of this game
			//next.interactable = false;
			msg.text = "Error: Try again!";
		}
		
		
		}


}
