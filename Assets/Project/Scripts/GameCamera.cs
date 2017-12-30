using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

	public GameObject target;
	public Vector3 offset = new Vector3 (0, 8, -3);
	public float focusSpeed = 3.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, Time.deltaTime * focusSpeed);
	}
}
