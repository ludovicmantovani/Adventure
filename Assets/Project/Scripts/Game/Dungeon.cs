using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

	private int enemyCount;
	private Enemy[] enemies;

	// Use this for initialization
	void Start () {
		enemies = GetComponentsInChildren<Enemy> ();
		enemyCount = enemies.Length;
	}
	
	// Update is called once per frame
	void Update () {
		int currentEnemyCount = 0;
		foreach (Enemy enemy in enemies) {
			if (enemy != null) {
				currentEnemyCount++;
			}
		}
		Debug.Log(currentEnemyCount + " / " + enemyCount);
	}
}
