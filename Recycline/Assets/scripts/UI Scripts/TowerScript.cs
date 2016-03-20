using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour {

	Button towerButton;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void towerClick()
	{
		// your code goes here
		print("Tower Button Clicked ");
		GameState.setObjectSelection (GameState.ObjectSelect.Tower);
	}

	public void rockClick()
	{
		// your code goes here
		print("Tower Button Clicked ");
		GameState.setObjectSelection (GameState.ObjectSelect.Rock);
	}

	public void noneClick()
	{
		// your code goes here
		print("Tower Button Clicked ");
		GameState.setObjectSelection (GameState.ObjectSelect.None);
	}
}
