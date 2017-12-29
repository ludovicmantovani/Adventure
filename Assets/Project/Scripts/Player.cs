using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
