using UnityEngine;
using System.Collections;

public class OrderAnimation : MonoBehaviour {

	public int walkMode = 0; //0 = not moving, 1 = moving forward
	public int shootMode = 0;

	// Update is called once per frame
	void Update () {

		//Send orders to animate
		if(Input.GetKey("w"))
		{
			//Order a walk
			transform.Find("DroneA_MeshPFnice").GetComponent<TryToAnimate>().WalkAnim();
			walkMode = 1;
		}
		else
		{
			walkMode = 0;
			transform.Find("DroneA_MeshPFnice").GetComponent<TryToAnimate>().IdleAnim();
		}
			
		if(Input.GetButton("Fire1"))
		{
			//Order a shoot
			transform.Find("DroneA_MeshPFnice").GetComponent<TryToAnimate>().ShootAnim();
			shootMode = 1;
		}
		else{shootMode = 0;}

	}

	public void WalkOn () {
		//Order a walk
		transform.Find("DroneA_MeshPFnice").GetComponent<TryToAnimate>().WalkAnim();
	}
}
