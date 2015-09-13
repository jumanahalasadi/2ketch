using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using Parse;
using System.Threading.Tasks;
using System.Collections.Generic;
//using System.Collections.Generic.List<string>;
//using System.Collections.Generic.List;

public class randomgame : MonoBehaviour {

	public InputField friend_username;
	public List<string> list = new List<string> ();
	public int count2; 
	public int isValid; 
	public Text msg2;
	public Button plus;
	private string userinput;
	//public ArrayList list;
	// Use this for initialization
	void Start () {
		count2 = 0;
		plus.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		userinput = friend_username.text;

		if (friend_username.text == "") {
			plus.interactable = false;
		}
		else
			plus.interactable = true;

	}

	public void createGame(){

		ParseUser.Query.WhereEqualTo("username", userinput).CountAsync().ContinueWith(t =>
		                                                                              {
			isValid = t.Result;
			//Debug.Log("This many results: " + isValid);
		});

		if (isValid > 0) {


			ParseUser.Query.CountAsync ().ContinueWith (t =>
			{
				count2 = t.Result;
				Debug.Log ("This many results: " + count2);
			});

				
			




			ParseUser.Query
						.FindAsync ().ContinueWith (t =>
			{

				IEnumerable<ParseUser> allusers = t.Result;

				foreach (var user in allusers) {

					//list[count] = user.Get<string> ("objectId");
					Debug.Log (user.Get<string> ("objectId"));
							           
					list.Add (user.Get<string> ("objectId"));
									
								
				}



			});

			int randomz; 

			randomz = (int)Random.Range (0f, count2 - 1);

			//Debug.Log (randomz);
			string oid_random; 
			//oid_random = list.ElementAt (randomz);
			//oid_random = list[randomz];

			//Debug.Log ("&^%&^%&^%T&^%&%&Random id: " + oid_random);


			string[] words = new string[] {"Car", "Tree", "Dog", "Mona Lisa", "Computer", "Bagpack"};
			int randomindex_word = (int)Random.Range (0f, 5f);

			int[] turns = new int[] {10, 20, 30};
			int randomindex_turns = (int)Random.Range (0f, 2f);

			int turnschosen = turns [randomindex_turns];

			string wordchosen = words [randomindex_word];
			//Debug.Log (wordchosen);

			//////
			/// 
			///
			var game = new ParseObject ("Game");
			game ["name"] = "new game";
			game ["Word"] = wordchosen;
			game ["TurnsLeft"] = turnschosen;
			game ["player_host_e"] = ParseUser.CurrentUser.Username;
			game ["player_client_o"] = friend_username.text;
				

				
			Task saveTask2 = game.SaveAsync ();

			msg2.text = "New game created! Refresh! ";
		}
		else
			msg2.text = "Error:Try again.";

	}
}
