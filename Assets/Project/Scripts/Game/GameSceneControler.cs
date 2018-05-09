using System.Collections;
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
	public GameObject dungeonPanel;
	public Text dungeonInfoText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {
			// Check for player information
			for (int i = 0; i < hearts.Length; i++) {
				hearts [i].SetActive (i < player.health);
			}

			bombText.text = "Bomb: " + player.bombAmount;
			arrowText.text = "Arrow: " + player.arrowAmount;

			// Check for dungeon information
			Dungeon currentDungeon = player.CurrentDungeon;
			dungeonPanel.SetActive(currentDungeon != null);
			if (currentDungeon != null) {
				dungeonInfoText.text = "Enemies: " + currentDungeon.CurrentEnemyCount + "/" + currentDungeon.EnemyCount;
			}

		} else {
			for (int i = 0; i < hearts.Length; i++) {
				hearts [i].SetActive (false);
			}
		}
	}
}
