using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


	public enum GameState {Idle,Playing,Ended}
	public GameState gameState = GameState.Idle;
	public GameObject uiIddle;
	public GameObject uiEnd;
	public GameObject player;
	public GameObject enemy;
	public float timer = 0f;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		if (gameState == GameState.Idle && Input.GetMouseButtonDown (0)) {
			
			gameState = GameState.Playing;
		} else if (gameState == GameState.Playing) {
			

			uiIddle.SetActive (false);
			RespawnEnemy ();
					
		}else if (gameState == GameState.Ended) {
			uiEnd.SetActive (true);
			uiIddle.SetActive (false);

			if (Input.GetMouseButtonDown (0)) {
				gameState = GameState.Playing;
			}


		}
	}
		void End(){
		gameState = GameState.Ended;
	
		}

	public void RespawnEnemy(){
			
		}	
	}


