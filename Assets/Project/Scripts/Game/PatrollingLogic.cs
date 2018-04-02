﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingLogic : MonoBehaviour {

	public GameObject model;
	public Vector3[] directions;
	public float timeToChange = 1f;
	public float movementSpeed = 5f;

	private int directionPointer;
	private float directionTimer;

	void Start () {
		directionPointer = 0;
		directionTimer = timeToChange;
	}
	
	// Update is called once per frame
	void Update () {
		directionTimer -= Time.deltaTime;
		if (directionTimer <= 0f) {
			directionTimer = timeToChange;
			directionPointer++;
			if (directionPointer >= directions.Length) {
				directionPointer = 0;
			}
		}

		model.transform.forward = directions[directionPointer];

		GetComponent<Rigidbody> ().velocity = new Vector3 (
			directions [directionPointer].x * movementSpeed,
			GetComponent<Rigidbody> ().velocity.y,
			directions [directionPointer].z * movementSpeed
		);
	}
}
