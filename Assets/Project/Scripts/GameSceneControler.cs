﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneControler : MonoBehaviour {

	[Header("Game")]
	public Player player;

	[Header("UI")]
	public GameObject[] hearts;
	public Text bombText;
	public Text arrowText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			for (int i = 0; i < hearts.Length; i++) {
				hearts [i].SetActive (i < player.health);
			}
			bombText.text = "Bomb: " + player.bombAmount;
			arrowText.text = "Arrow: " + player.arrowAmount;
		} else {
			for (int i = 0; i < hearts.Length; i++) {
				hearts [i].SetActive (false);
			}
		}
	}
}
