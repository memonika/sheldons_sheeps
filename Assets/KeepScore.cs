using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {

	public GameObject scoreObject;
	public int currentScore;
	private Text scoreText;
	private SpawnSheeps spawner;

	void Start () {
		scoreText = scoreObject.GetComponent<Text> ();
		scoreText.text = "" + currentScore;
		spawner = GetComponentInParent<SpawnSheeps> ();
	}

	void Update () {
		scoreText.text = "" + currentScore;
	}

	public void increaseScore() {
		currentScore += 1;
		updateDifficulty ();
	}

	public void decreaseScore() {
		currentScore -= 1;
		updateDifficulty ();
	}

	void updateDifficulty() {
		if (currentScore <= 60) {
			spawner.setDifficulty (1);
		} else if (currentScore > 60 && currentScore < 80) {
			spawner.setDifficulty (2);
		} else {
			spawner.setDifficulty (3);
		}
	}
		
}
