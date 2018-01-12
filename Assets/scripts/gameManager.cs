using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class gameManager : NetworkBehaviour {

	public switchManager redSwitch, blueSwitch, scale;

	public float second = 1;

	[SyncVar]
	public int blueTeamScore;

	[SyncVar]
	public int redTeamScore;

	public Text score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		second -= Time.deltaTime;
		if (second < 0) {
			print ("updating");
			redTeamScore += (redSwitch.getWinner () ==  1 ? 1 : 0);
			blueTeamScore += (blueSwitch.getWinner () == -1 ? 1 : 0);

			if (scale.getWinner () == 1) {
				redTeamScore++;
			} else if (scale.getWinner () == -1) {
				blueTeamScore++;
			}
			score.text = "Score: Red: " + redTeamScore + " Blue: " + blueTeamScore;
			second += 1;
		} 
	}


}
