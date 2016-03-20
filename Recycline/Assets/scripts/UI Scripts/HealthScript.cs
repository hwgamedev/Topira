using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	private Text healthText;

	// Use this for initialization
	void Start () {
		healthText = GetComponent<Text>();
	}

	// Update is called once per frame
	void Update () {
		healthText.text = GameState.HEALTH.ToString();
	}
}
