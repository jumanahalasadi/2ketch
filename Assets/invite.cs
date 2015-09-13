using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class invite : MonoBehaviour {

	public void InviteFriends(){
		FB.AppRequest(
			message:"Come Play With Me lol", 
			title:"Invite your friends to join you!");

	}

}
