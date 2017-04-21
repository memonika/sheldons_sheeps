using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {

	public GameObject scoreObject;
	public int currentScore;
	private Text scoreText;

	void Start () {
		scoreText = scoreObject.GetComponent<Text> ();
		scoreText.text = "" + currentScore;
	}

	void Update () {
		scoreText.text = "" + currentScore;
	}

	public void increaseScore() {
		currentScore += 1;
	}

	public void decreaseScore() {
		currentScore -= 2;
	}
		
}
