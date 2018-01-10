using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public int points = 0;
	public float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnCollisionEnter(Collision collision) {
		print ("collision enters");
		if (collision.gameObject.tag.Equals ("robot")) {
			movement m = collision.gameObject.GetComponent<movement> ();
			m.onPlatform = true;
			m.platform = this;
			m.timer = timer;
			m.timerMax = timer;
		}
	}

	void OnCollisionExit(Collision collision) {
		print ("collision exit");
		if (collision.gameObject.tag.Equals ("robot")) {
			movement m = collision.gameObject.GetComponent<movement> ();
			m.onPlatform = false;
			m = null;
		}
	}

}
