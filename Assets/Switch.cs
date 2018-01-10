using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public int points = 0;
	public movement m;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (m != null && m.hasBlock) {
			if (m.onPlatform) {
				m.timer -= Time.deltaTime;
				if (m.timer < 0) {
					m.hasBlock = false;
					points++;
				}
			}
		}
	}


	void OnCollisionEnter(Collision collision) {
		print ("collision enters");
		if (collision.gameObject.tag.Equals ("robot")) {
			m = collision.gameObject.GetComponent<movement> ();
			m.onPlatform = true;
		}
	}

	void OnCollisionExit(Collision collision) {
		print ("collision exit");
		if (collision.gameObject.tag.Equals ("robot")) {
			movement m = collision.gameObject.GetComponent<movement> ();
			m.onPlatform = false;
			m.timer = m.timerMax;
			m = null;
		}
	}

}
