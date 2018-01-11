using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class gameManager : NetworkBehaviour {

	public Switch[] switches = new Switch[6];

	[SyncVar]
	public int blueTeamScore;

	[SyncVar]
	public int redTeamScore;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
