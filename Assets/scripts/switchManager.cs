using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class switchManager : NetworkBehaviour {

	public  Switch leftSwitch, rightSwitch;

	// Use this for initialization
	void Start () {
		if (!isServer) {
			return;
		}
		if (Random.Range (0, 2) == 0) {
			print ("Red left");
			leftSwitch.isRed = true;
			rightSwitch.isRed = false;
		} else {
			print ("red right");
			leftSwitch.isRed = false;
			rightSwitch.isRed = true;
		}
		leftSwitch.updateScale ();
		rightSwitch.updateScale ();
	}

	// 0 -> tie, 1 -> red win, -1 -> blue win
	public int getWinner() {
		Switch redSwitch = (leftSwitch.isRed ? leftSwitch : rightSwitch);
		Switch blueSwitch = (!leftSwitch.isRed ? leftSwitch : rightSwitch);
		int winner = 0;
		if (redSwitch.points > blueSwitch.points) {
			winner = 1;
		} else if(redSwitch.points < blueSwitch.points) {
			winner = -1;
		}
		return winner;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
