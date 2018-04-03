using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[Header("Visuals")]
	public GameObject model;
	public Animator playerAnimator;
	public float rotatingSpeed = 5f;

	[Header("Movement")]
	public float jumpingVelocity = 5f;
	public float movingVelocity = 5f;
	public float knockbacForce = 300f;

	[Header("Equipment")]
	public int health = 5;
	public Sword sword;
	public Bow bow;
	public GameObject quiver;
	public int arrowAmount = 15;
	public GameObject bombPrefab;
	public int bombAmount = 5;
	public float throwingSpeed = 200;

	private Rigidbody playerRigidbody;
	private Quaternion targetModelRotation;
	private float knockbackTimer;
	private bool justTeleported;
	private Vector3 originalPlayerAnimatorPosition;

	public bool JustTeleported{
		get{
			bool returnValue = justTeleported;
			justTeleported = false;
			return returnValue;
		}
	}

	// Use this for initialization
	void Start () {
		bow.gameObject.SetActive (false);
		quiver.gameObject.SetActive (false);
		sword.gameObject.SetActive (true);
		playerRigidbody = GetComponent<Rigidbody> ();
		targetModelRotation = Quaternion.Euler (0, 0, 0);
		originalPlayerAnimatorPosition = playerAnimator.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		model.transform.rotation = Quaternion.Lerp(model.transform.rotation, targetModelRotation, Time.deltaTime * rotatingSpeed);
		if (knockbackTimer > 0) {
			knockbackTimer -= Time.deltaTime;
		}
		else {
			ProcessInput ();	
		}
	}

	void LateUpdate(){
		playerAnimator.transform.localPosition = originalPlayerAnimatorPosition;
	}


	void ProcessInput(){
		bool isPlayerMoving = false;

		playerRigidbody.velocity = new Vector3 (
			0,
			playerRigidbody.velocity.y,
			0
		);

		playerAnimator.SetBool ("OnGround", CanJump ());

		if (Input.GetKey("right")) {
			playerRigidbody.velocity = new Vector3 (
				movingVelocity,
				playerRigidbody.velocity.y,
				playerRigidbody.velocity.z
			);
			targetModelRotation = Quaternion.Euler(0, 90, 0);
			isPlayerMoving = true;
		}
		if (Input.GetKey("left")) {
			playerRigidbody.velocity = new Vector3 (
				-movingVelocity,
				playerRigidbody.velocity.y,
				playerRigidbody.velocity.z
			);
			targetModelRotation = Quaternion.Euler(0, 270, 0);
			isPlayerMoving = true;
		}
		if (Input.GetKey("up")) {
			playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				playerRigidbody.velocity.y,
				movingVelocity
			);
			targetModelRotation = Quaternion.Euler(0, 0, 0);
			isPlayerMoving = true;
		}
		if (Input.GetKey("down")) {
			playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				playerRigidbody.velocity.y,
				-movingVelocity
			);
			targetModelRotation = Quaternion.Euler(0, 180, 0);
			isPlayerMoving = true;
		}

		playerAnimator.SetFloat ("Forward", isPlayerMoving ? 1f: 0f);

		if (Input.GetKeyDown("space") && CanJump()) {
			playerRigidbody.velocity = new Vector3 (
				playerRigidbody.velocity.x,
				jumpingVelocity,
				playerRigidbody.velocity.z
			);
		}
		if (Input.GetKeyDown("z")) {
			bow.gameObject.SetActive (false);
			quiver.gameObject.SetActive (false);
			sword.gameObject.SetActive (true);
			sword.Attack ();
		}
		if (Input.GetKeyDown("x")) {
			sword.gameObject.SetActive (false);
			bow.gameObject.SetActive (true);
			quiver.gameObject.SetActive (true);
			if (arrowAmount > 0) {
				bow.Attack ();
				arrowAmount--;
			}
		}
		if (Input.GetKeyDown("c")) {
			if (bombAmount > 0) {
				ThrowBomb ();
				bombAmount--;
			}
		}
	}

	private bool CanJump(){
		RaycastHit hit;
		return(Physics.Raycast (transform.position, Vector3.down, out hit, 1.31f));
	}

	private void ThrowBomb(){
		GameObject bombObject = Instantiate (bombPrefab);
		bombObject.transform.position = transform.position + model.transform.forward;
		Vector3 throwingDirection = (model.transform.forward + Vector3.up).normalized;
		bombObject.GetComponent<Rigidbody> ().AddForce (throwingDirection * throwingSpeed);
	}

	void OnTriggerEnter(Collider otherCollider){
		if (otherCollider.GetComponent<EnemyBullet>() != null) {
			Hit ((transform.position - otherCollider.transform.position).normalized);
			Destroy(otherCollider);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.GetComponent<Enemy>()) {
			Hit ((transform.position - collision.transform.position).normalized);
		}
	}

	private void Hit(Vector3 direction){
		Vector3 knockbacDirection = (direction + Vector3.up).normalized;
		playerRigidbody.AddForce (knockbacDirection * knockbacForce);
		knockbackTimer = 1f;

		health--;
		if (health <= 0) {
			Destroy (gameObject);
		}
	}

	public void Teleport(Vector3 target){
		transform.position = target;
		justTeleported = true;
	}
}
