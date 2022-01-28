using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public float fireRate = 0.5f;
	float coolDown = 0;
	public float damage = 25f;

	// Update is called once per frame
	void Update () {

		if(coolDown > 0){coolDown -= Time.deltaTime;}
		//if(coolDown <= 0){Debug.Log ("Ready");}  //for testing
		if(Input.GetButton("Fire1")) //GetButtonDown is for single shot
		{
			//Shoot
			Shoot();
		}
	
	}

	void Shoot () {
		if(coolDown > 0){
			return;
		}

		//Debug shit here!!!

		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		Transform hitTransform;
		Vector3 hitPoint;

		hitTransform = FindClosestHitObject(ray, out hitPoint);

		if(hitTransform != null) {
			//hitInfo.point
			Debug.Log ("we hit" + hitTransform.collider.name);
			Health h = hitTransform.GetComponent<Health>();

			while(h == null && hitTransform.parent){
				hitTransform = hitTransform.parent;
				h = hitTransform.GetComponent<Health>();
			}
				//h.TakeDamage ( damage );

			//if(h != null) {
			//	h.TakeDamage ( damage )  <----- NO ;
			//}
			if(h != null) {
				h.TakeDamage( damage );
			}

		}
		//if( Physics.Raycast(ray, out hitInfo))   
		//{
		coolDown = fireRate;//}

		} //Shoot
		
		Transform FindClosestHitObject(Ray ray, out Vector3 hitPoint) {
			//Something
			RaycastHit[] hits = Physics.RaycastAll(ray);

			Transform closestHit = null;
			float distance = 0;
			hitPoint = Vector3.zero;

			foreach(RaycastHit hit in hits) 
			{
				if(hit.transform != this.transform && (closestHit == null || hit.distance < distance))
				{
					//We hit soemthing that is not us, or something.
					closestHit = hit.transform;
					distance = hit.distance;
					hitPoint = hit.point;
				}
			}

			//closest hit is either null or it is the closest thing we can hit.
			return closestHit;
		} //Other shit
} //w/e