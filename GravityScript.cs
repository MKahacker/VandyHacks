using UnityEngine;
using System.Collections;

public class GravityScript : MonoBehaviour {

	public Rigidbody object1;
	public Rigidbody object2;
	public double gravConstant = 6.674*(10E-11);
	public float timeSpeed = 10;

	// Use this for initialization
	void Start () {
		object1 = object1.GetComponent<Rigidbody> ();
		object2 = object2.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		

		Time.timeScale = timeSpeed;

		float distance = Mathf.Sqrt (Mathf.Pow ((object1.position.x - object2.position.x), 2)
		                 + Mathf.Pow ((object1.position.y - object2.position.y), 2)
		                 + Mathf.Pow ((object1.position.z - object2.position.z), 2));
		float force = (float)((gravConstant * object1.mass * object2.mass) /
		              (Mathf.Pow (distance, 2)));

		object1.AddForce (-((object1.position - object2.position) * force));
		object2.AddForce (-((object2.position - object1.position) * force));
	}
}
