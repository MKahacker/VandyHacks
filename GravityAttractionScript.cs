using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractionScript : MonoBehaviour {

	List<Rigidbody> rigidBodyObjects; 
	public float gravityConstant;
	public float timeSpeed = 10;

	// Use this for initialization
	void Start () {

		rigidBodyObjects = new List<Rigidbody>();

	}

	// Update is called once per frame
	void FixedUpdate () {

		foreach (Collider collider in Physics.OverlapSphere(transform.position, 500)) {
			if (collider.GetComponent<Rigidbody> ()) {
				
				rigidBodyObjects.Add(collider.transform.GetComponent<Rigidbody> ());
			}
		}
		
		Time.timeScale = timeSpeed;
		Rigidbody RB1 = GameObject.Find(gameObject.name).GetComponent<Rigidbody>(); 

		Vector3 resultForce = Vector3.zero;
		foreach (Rigidbody RB2 in rigidBodyObjects) {

			if (RB1.name != RB2.name) {
				Vector3 forceDirection = RB1.transform.position - RB2.transform.position;
				resultForce += forceDirection.normalized * (gravityConstant * ((RB1.mass * RB2.mass) 
					/ (forceDirection.magnitude * forceDirection.magnitude)));
				RB1.AddForce (-resultForce);
			}
		}

		rigidBodyObjects.Clear();
	}
		
}



