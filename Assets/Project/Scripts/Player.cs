using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jumpingForce = 200f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput ();
	}

	void ProcessInput(){
		if (Input.GetKey("right")) {
			transform.position += Vector3.right * 5f * Time.deltaTime;
		}
		if (Input.GetKey("left")) {
			transform.position += Vector3.left * 5f * Time.deltaTime;
		}
		if (Input.GetKey("up")) {
			transform.position += Vector3.forward * 5f * Time.deltaTime;
		}
		if (Input.GetKey("down")) {
			transform.position += Vector3.back * 5f * Time.deltaTime;
		}
		if (Input.GetKeyDown("space") && canJump()) {
			GetComponent<Rigidbody>().AddForce(0, jumpingForce, 0);
		}
	}

	bool canJump(){
		RaycastHit hit;
		return(Physics.Raycast (transform.position, Vector3.down, out hit, 1.01f));
	}
}
