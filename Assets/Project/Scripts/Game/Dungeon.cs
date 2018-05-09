using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

	private int enemyCount;
	private Enemy[] enemies;
	private int currentEnemyCount;
	private Treasure treasure;
	private bool isClear;


	public int EnemyCount{
		get{
			return enemyCount;
		}
	}

	public int CurrentEnemyCount{
		get{
			return currentEnemyCount;
		}
	}

	// Use this for initialization
	void Start () {
		enemies = GetComponentsInChildren<Enemy> ();
		enemyCount = enemies.Length;
		treasure = GetComponentInChildren<Treasure> ();
		treasure.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		currentEnemyCount = 0;
		foreach (Enemy enemy in enemies) {
			if (enemy != null) {
				currentEnemyCount++;
			}
		}
		if (isClear == false) {
			if (currentEnemyCount == 0) {
				treasure.gameObject.SetActive (true);
				isClear = true;
			}
		}
	}
}
