using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {
	void OnTriggerExit(Collider col){
		col.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		col.gameObject.GetComponent<Rigidbody>().transform.position = new Vector3(Random.Range(-500, 500), Random.Range(-500,500), Random.Range(-500, 500));
	}
}
