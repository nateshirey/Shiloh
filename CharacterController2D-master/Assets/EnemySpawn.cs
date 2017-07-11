using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public int EnemyNumber = 4;
	public int EnemiesAlive = 0;
	public GameObject EnemyPrefab;

	// Use this for initialization
	void Start () {
		
	}

	void onTriggerEnter(Collider2D col)	{

		Debug.Log ("playe sdawsr");

		if (col.tag == "Player"){

			Debug.Log ("player");

			for (int i = 0; i <= EnemyNumber; i++) {

				GameObject newEnemy = Instantiate (EnemyPrefab);

			}
		}

	}

	// Update is called once per frame
	void Update () {

		Debug.Log ("plar");

		
	}
}
