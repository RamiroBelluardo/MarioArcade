using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject playerPrefab;

	int enemyCount=0;
	float yPos = 0.214f;
	float xPos = -3.8f;
	float  xPosPlayer=-2.37737f;
	float yPosPlayer=0.07314181f;
	int playerCount = 0;
	 void Start() {
		
		InvokeRepeating ("spawnEnemy", 1f, 6f);
		}


	// Use this for initialization

	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void spawnEnemy() {
		if (playerCount < 1) {
			Instantiate (playerPrefab, new Vector3 (xPosPlayer, yPosPlayer, 0f), Quaternion.identity);
			playerCount = 1;
		}
		if (enemyCount < 3) {
			
			Instantiate (enemyPrefab, new Vector3 (xPos, yPos, 0f), Quaternion.identity);
			enemyCount++;
		}	

	}
	public void deleteEnemy() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");


		foreach (GameObject enemy in enemies) {

			Destroy (enemy);

		
		}
		StartCoroutine ("tiempo");

	}
	IEnumerator tiempo (){
		yield return new WaitForSeconds (1f);
		GameObject player= GameObject.FindGameObjectWithTag ("Player");
		enemyCount = 0;
		playerCount = 0;
		Destroy (player);

	}
}

	
