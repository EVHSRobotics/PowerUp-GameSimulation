using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class movement : NetworkBehaviour {

	public bool hasBlock = false;
	public bool onPlatform = false;
	public Switch platform;
	public float timer = 3;
	public float timerMax = 3;

	public GameObject cube;

	void Start() {	}

	void Update () {

		cube.SetActive (hasBlock);

		if (!onPlatform || platform == null) {
			timer = timerMax;
			cube.transform.position = this.transform.position;
		} else {
			cube.transform.Translate (0, Time.deltaTime, 0);
			timer -= Time.deltaTime;
			if (timer < 0) {
				hasBlock = false;
				platform.points++;
			}
		}

		if (!isLocalPlayer) {
			if (GetComponentInChildren<Camera> () != null) {
				Destroy (GetComponentInChildren<Camera> ().gameObject);
			}
			return;
		}
		

		var x = Input.GetAxis("Horizontal")*1.5f;
		var z = Input.GetAxis("Vertical")*0.15f;

		transform.Translate(0, 0, z);	
		transform.Rotate (new Vector3 (0, x, 0));



		
	}

	void OnCollisionEnter(Collision collision) {
		if (!hasBlock && collision.gameObject.tag.Equals ("power")) {
			hasBlock = true;
			Destroy (collision.gameObject);
		}
	}

	public override void OnStartLocalPlayer(){
		//GetComponent<MeshRenderer>().material.color = Color.red;
	}
}
