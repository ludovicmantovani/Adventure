using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {

	public GameObject target;
	public Vector3 offset = new Vector3 (0, 8, -3);
	public float focusSpeed = 3.5f;

	public GameObject temporaryTarget;
	public float temporaryFocusTime = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (temporaryTarget != null) {
			transform.position = Vector3.Lerp (transform.position, temporaryTarget.transform.position + offset, Time.deltaTime * focusSpeed);
		}
		else if (target != null) {
			if (target.GetComponent<Player> () != null) {
				Player player = target.GetComponent<Player> ();
				transform.position = Vector3.Lerp (transform.position, player.transform.position + offset, Time.deltaTime * focusSpeed);
				if (player.JustTeleported) {
					transform.position = player.transform.position + offset;
				}
			} else {
				transform.position = Vector3.Lerp (transform.position, target.transform.position + offset, Time.deltaTime * focusSpeed);
			}

		}
	}

	public void FocusOn(GameObject target)
	{
		temporaryTarget = target;
		StartCoroutine (FocusOnRoutine ());
	}

	private IEnumerator	FocusOnRoutine(){
		yield return new WaitForSeconds (temporaryFocusTime);
		temporaryTarget = null;
	}
}
