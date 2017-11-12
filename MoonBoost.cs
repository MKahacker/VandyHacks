using UnityEngine;
using System.Collections;

public class MoonBoost : MonoBehaviour {

	private Rigidbody rb;
	public float launchForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.AddForce (0, launchForce, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
