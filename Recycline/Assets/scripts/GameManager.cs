using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;             
	private LevelManager levelScript;     

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);
		levelScript = GetComponent<LevelManager>();
		InitGame();
	}

	void InitGame()
	{
		GameState.setGameState (GameState.GameStateType.Ready);
		levelScript.SetupScene ();
		levelScript.LoadScene ();

        //Instantiate(Resources.Load("Minion"));
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Game State Change

		//Game State Call
		switch (GameState.getGameState())
		{
			case GameState.GameStateType.Ready:
				UpdateReady(); 
				break;
			case GameState.GameStateType.Running:
				//Some Running Code
				UpdateRunning(); 
				break;
			case GameState.GameStateType.Win: 
				UpdateWin(); 
				break;
			case GameState.GameStateType.Fail:
				UpdateFail(); 
				break;
			default:
				Debug.Log("ERROR: Unknown game state: " + GameState.getGameState());
				break;
		}
	}

	void UpdateReady () {

	}

	void UpdateRunning () {

	}

	void UpdateWin () {

	}

	void UpdateFail () {

	}

}
