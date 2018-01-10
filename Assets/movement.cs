using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : NetworkBehaviour {

	public bool hasBlock = false;
	public bool onPlatform = false;
	public float timer = 3;
	public float timerMax = 3;
	
	// Update is called once per frame
	void Update () {

		if (!isLocalPlayer)
			return;
		

		var x = Input.GetAxis("Horizontal")*1.5f;
		var z = Input.GetAxis("Vertical")*0.1f;

		transform.Translate(0, 0, z);	
		transform.Rotate (new Vector3 (0, x, 0));

		if (hasBlock) {
			GetComponent<MeshRenderer> ().material.color = Color.magenta;
		} else {
			GetComponent<MeshRenderer>().material.color = Color.red;

		}

		if (!onPlatform) {
			timer = timerMax;
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (!hasBlock && collision.gameObject.tag.Equals ("power")) {
			hasBlock = true;
			Destroy (collision.gameObject);
		}
	}

	public override void OnStartLocalPlayer(){
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
}
