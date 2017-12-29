using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jumpingVelocity = 5f;
	public float mouvingVelocity = 5f;

	private Rigidbody playerRigidbody;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput ();
	}

	void ProcessInput(){

		playerRigidbody.velocity = new Vector3 (
			0,
			playerRigidbody.velocity.y,
			0
		);

		if (Input.GetKey("right")) {
			playerRigidbody.velocity = new Vector3 (
				mouvingVelocity,
				playerRigidbody.velocity.y,
				playerRigidbody.velocity.z
			);
		}
		if (Input.GetKey("left")) {
			playerRigidbody.velocity = new Vector3 (
				-mouvingVelocity,
				playerRigidbody.velocity.y,
				playerRigidbody.velocity.z
			);
		}
		if (Input.GetKey("up")) {
			playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				playerRigidbody.velocity.y,
				mouvingVelocity
			);
		}
		if (Input.GetKey("down")) {
			playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				playerRigidbody.velocity.y,
				-mouvingVelocity
			);
		}
		if (Input.GetKeyDown("space") && canJump()) {
			playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				jumpingVelocity,
				playerRigidbody.velocity.z
			);
		}
	}

	bool canJump(){
		RaycastHit hit;
		return(Physics.Raycast (transform.position, Vector3.down, out hit, 1.01f));
	}
}
