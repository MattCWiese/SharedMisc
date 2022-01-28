using UnityEngine;
using System.Collections;

public class TryToAnimate : MonoBehaviour {
	
	public void WalkAnim () {
		animation.Play("walk");
	}

	public void ShootAnim () {
		animation.Play("shoot2");
	}

	public void IdleAnim () {
		animation.Play("idle");
	}

	// Update is called once per frame
	void Update () {
		//if(Input.GetButton("Fire1")){animation.Play(walk.clip.name);}
		//if(Input.GetKey("w")){animation.Play("walk");}
		//if(Input.GetButton("Fire1")){animation.Play("shoot2");}
	}
}
