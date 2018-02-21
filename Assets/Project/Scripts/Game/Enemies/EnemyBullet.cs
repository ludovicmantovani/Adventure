using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float speed = 10f;
	public float lifetime = 0.5f;

	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}

	void Update () {
		lifetime -= Time.deltaTime;
		if (lifetime <= 0) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter(Collider otherCollider){
		GameObject parentGO = null;
		if (otherCollider && otherCollider.transform && otherCollider.transform.parent) {
			parentGO = otherCollider.transform.parent.gameObject;
		}
		if (parentGO != null && parentGO.tag == "Wall") {
			Destroy (gameObject);
		}
	}
}
