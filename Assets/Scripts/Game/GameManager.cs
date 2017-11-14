using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    


    [SerializeField]
	SpawnerManager enemySpawnerScript;

	public Canvas uiIddle;
	public Canvas uiEnd;
	public Canvas uiWin;

	public bool End;
	public bool Win;


	private void FixedUpdate()



	 	 {
			if (Input.GetMouseButtonDown (0)) {
				SetEnemySpawner (true);
				uiIddle.enabled = false;
				uiEnd.enabled = false;
				uiWin.enabled = false;
				End = false;
				Win = false;

			}
		if (End == true) {
			uiEnd.enabled = true;
			enemySpawnerScript.deleteEnemy ();
		

		}
		if (Win == true) {
			uiWin.enabled = true;
			enemySpawnerScript.deleteEnemy ();


		}
		}

	
    public void GameOver()
    {
		End = true;
		uiEnd.enabled = false;

    
	}
	public void Winner()
	{
		Win = true;
		uiWin.enabled = false;


	}

    public void Start()
	{	
		
		End = false;
		Win = false;

	}

	private void SetEnemySpawner(bool b){
		enemySpawnerScript.gameObject.SetActive(b);
	
	}




}
