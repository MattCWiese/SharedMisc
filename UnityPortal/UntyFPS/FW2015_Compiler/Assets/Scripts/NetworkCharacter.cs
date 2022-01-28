using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {

	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;
	public int useThisMove = 0;

	//attempt
	public int walkMoGo = 0; //0 = not moving, 1 = moving forward
	public int shootMoGo = 0;

	//Here I need to maybe init some class?
	Animation anim; //??? just a wild guess
	public Transform getAnim; //???

	//float lastUpdateTime;

	// Use this for initialization
	void Start () {
		//Here, I need to get animation data from the mesh and store it.
		//anim = GetComponent<Animation>();
		//transform.FindChild("DroneA_MeshPFnice");
		anim = getAnim.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		//PhotonView photonView = GetComponent<PhotonView>();
		if( photonView.isMine ){
					//Do nuthin
			if(Input.GetKey("w")){walkMoGo = 1;}else{walkMoGo = 0;}
		}
		else{
			//if(Input.GetKey("w")){walkMoGo = 1;}else{walkMoGo = 0;}
			//if(Input.GetKey("Fire1")){shootMoGo = 1;}else{shootMoGo = 0;}
			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, 0.1f);
		}

		if(useThisMove == 1){anim.animation.Play("walk");}else{if(useThisMove == -1){anim.animation.Play("idle");}} //else won't work.

	}

	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
		if(stream.isWriting) {
			//This is our player, sent pos to network
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			//if(anim.animation.IsPlaying("walk")){walkMoGo = 1;}
			//stream.SendNext (anim.GetFloat("Speed")); //would need additional setup
			if(anim.animation.IsPlaying("walk")){stream.SendNext(useThisMove = 1);}else{stream.SendNext(useThisMove = -1);}
		}
		else{ //elses player, recive their pos
			realPosition = (Vector3)stream.ReceiveNext();
			realRotation = (Quaternion)stream.ReceiveNext();
			useThisMove = (int)stream.ReceiveNext();
			//anim.animation.IsPlaying("walk") = (bool)stream.ReceiveNext();
			//anim.SetFloat(*Speed*,(float) stream.ReceiveNext ());
		}
	}
}
