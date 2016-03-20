using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour {

	private Text goldText;

	// Use this for initialization
	void Start () {
		goldText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		goldText.text = GameState.GOLD.ToString();
	}
}
