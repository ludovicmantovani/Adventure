using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon : MonoBehaviour {

	private int enemyCount;
	private Enemy[] enemies;
	private int currentEnemyCount;

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
	}
	
	// Update is called once per frame
	void Update () {
		currentEnemyCount = 0;
		foreach (Enemy enemy in enemies) {
			if (enemy != null) {
				currentEnemyCount++;
			}
		}
	}
}
