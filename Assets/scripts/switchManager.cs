using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchManager : MonoBehaviour {

	public Switch  leftSwitch, rightSwitch;

	// Use this for initialization
	void Start () {
		if (Random.Range (0, 2) == 0) {
			print ("Red left");
			leftSwitch.isRed = true;
			rightSwitch.isRed = false;
		} else {
			print ("red right");
			leftSwitch.isRed = false;
			rightSwitch.isRed = true;
		}
		print ("loading");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
