using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Switch : NetworkBehaviour{

	public int points = 0;
	public GameObject visualSwitch;
	public float timer;

	public float y;

	[SyncVar]
	public bool isRed;


	// Use this for initialization
	void Start () {

	}

	public void updateScale() {
		if (isRed) {
			print ("setting to red");
			GetComponent<MeshRenderer> ().material.color = Color.red;
		} else {
			GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
	}

	public void placeBlock(GameObject obj) {
		float y = visualSwitch.transform.position.y;
		float x = visualSwitch.transform.position.x;
		float z = visualSwitch.transform.position.z;
		Vector3 size = visualSwitch.GetComponent<BoxCollider> ().size;
		float halfWidth = size.x / 2f * 3 * visualSwitch.transform.localScale.x / 4f;
		float halfDepth = size.z / 2f * 3 * visualSwitch.transform.localScale.z / 4f;

		obj.transform.position = new Vector3 (x + Random.Range (-halfWidth, halfWidth), this.y , z + Random.Range (-halfDepth, halfDepth));

	}


	void OnTriggerEnter(Collider collision) {
		print ("collision enters");
		if (collision.gameObject.tag.Equals ("robot")) {
			movement m = collision.gameObject.GetComponent<movement> ();
			m.onPlatform = true;
			m.platform = this;
			m.timer = timer;
			m.timerMax = timer;
		}
	}

	void OnTriggerExit(Collider collision) {
		print ("collision exit");
		if (collision.gameObject.tag.Equals ("robot")) {
			movement m = collision.gameObject.GetComponent<movement> ();
			m.onPlatform = false;
			m = null;
		}
	}

}
