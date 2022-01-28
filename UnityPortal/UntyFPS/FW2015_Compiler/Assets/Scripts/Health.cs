using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour { //Not good for networking!!!!!!!!!

	public float hitPoints = 100f;
	float currentHitPoints;

	// Use this for initialization
	void Start () {
		currentHitPoints = hitPoints;
	}
	
	// Update is called once per frame
	public void TakeDamage (float amt) {
		currentHitPoints -= amt;

		if(currentHitPoints <= 0)
		{Die();}
	}

	void Die () {
		Destroy(gameObject);
	}
}
