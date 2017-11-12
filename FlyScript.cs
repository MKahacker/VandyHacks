using UnityEngine;
using System.Collections;

public class FlyScript : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private  Camera mainCam;
    public float speedIncBase;
    public float speedIncExp;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");
        //		Input.GetButton ("Fire1");
        //		Input.GetButton ("Fire2");
        float myMass = this.GetComponent<Rigidbody>().mass;
		rb.AddForce(mainCam.transform.forward * speed * Mathf.Exp(speedIncExp) * myMass * vertical);
		rb.AddForce (mainCam.transform.right * speed * Mathf.Exp(speedIncExp) * myMass * horizontal);
		rb.transform.forward = mainCam.transform.forward;
		//rb.transform.right = mainCam.transform.right;
	}
}
