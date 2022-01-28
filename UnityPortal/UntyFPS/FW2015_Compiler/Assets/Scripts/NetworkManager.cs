using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	public GameObject standbyCamera;
	SpawnSpot[] spawnSpots;
	// Use this for initialization

	public bool offlineMode = false;

	void Start () {
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
		Connect ();
	}

	void Connect () {
		if(offlineMode){PhotonNetwork.offlineMode = true; OnJoinedLobby();}
		else
		{PhotonNetwork.ConnectUsingSettings("MultiFPS gjgjgj 001");}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		GUILayout.Label ( PhotonNetwork.connectionStateDetailed.ToString () );
	}

	void OnJoinedLobby () {

		PhotonNetwork.JoinRandomRoom(); //Try to join existing game.
	}

	void OnPhotonRandomJoinFailed () {  //There is no existing game.
		//Debug.Log ("Worked");
		PhotonNetwork.CreateRoom (null); //So... make the room.
	}

	void OnJoinedRoom () { 

		SpawnMyPlayer();
			
	}

	void SpawnMyPlayer () {

		SpawnSpot mySpawnSpot = spawnSpots[ Random.Range(0, spawnSpots.Length) ];
		GameObject myPlayerGO = (GameObject) PhotonNetwork.Instantiate("FPS_PF",mySpawnSpot.transform.position, mySpawnSpot.transform.rotation, 0);
		//standbyCamera.enabled = false;
		standbyCamera.SetActive(false);
		//Control own stuff only
		((MonoBehaviour)myPlayerGO.GetComponent("FPSInputController")).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("OrderAnimation")).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("CharacterMotor")).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled = true;
		((MonoBehaviour)myPlayerGO.GetComponent("PlayerShooting")).enabled = true;
		myPlayerGO.transform.FindChild("Main Camera").gameObject.SetActive (true);
	}
}
