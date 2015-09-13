using UnityEngine;
using UnityEngine.UI;
using Parse;
using System.Collections;
using System.Threading.Tasks;


public class getgameinfo : MonoBehaviour {
	public GameObject gameid;
	public string GAMEID;
	public Text component;

	public Text text_turns;
	public Text text_word;
	private string word;
		private int turnsLeft;
	// Use this for initialization
	void Start () {
		gameid = GameObject.Find("DONTDESTROY");
		
		component = gameid.GetComponent<Text> ();
		
		GAMEID = component.text;
		
		ParseQuery<ParseObject> query = ParseObject.GetQuery ("Game");
		query.GetAsync (GAMEID).ContinueWith (z => {
			
			ParseObject gamebeg = z.Result;
			
			turnsLeft = gamebeg.Get<int> ("TurnsLeft");
			word  = gamebeg.Get<string> ("Word");
			
			
			
		});


	}
	
	// Update is called once per frame
	void Update () {
		text_turns.text = turnsLeft +" turns left.";
		text_word.text = word;

	}

	public void getGameInfo(){

		

	}
}
