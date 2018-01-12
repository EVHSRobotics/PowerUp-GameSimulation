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

	public GameObject cubeModel;

	void Start() {	}

	void Update () {

		cube.SetActive (hasBlock);

		if (!onPlatform || platform == null) {
			timer = timerMax;
			cube.transform.position = this.transform.position;
		} else if(hasBlock){
			cube.transform.Translate (0, Time.deltaTime, 0);
			timer -= Time.deltaTime;
			if (timer < 0) {
				hasBlock = false;
				platform.points++;
				platform.placeBlock (Instantiate (cubeModel));
			}
		}

		if (!isLocalPlayer) {
			if (GetComponentInChildren<Camera> () != null) {
				Destroy (GetComponentInChildren<Camera> ().gameObject);
			}
			return;
		}
		

		var x = Input.GetAxis("Horizontal")*2f;
		var y = Input.GetAxis("Vertical")*10f;

		//transform.Translate(0, 0, y);	
		

		Rigidbody body = this.GetComponent<Rigidbody> ();
		Vector3 vel = transform.InverseTransformVector (body.velocity);
		vel.z = y;
		body.velocity = transform.TransformVector(vel);
		transform.Rotate (new Vector3 (0, x, 0));

		transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
		//transform.position = new Vector3 (transform.position.x, -.5f, transform.position.z);
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
