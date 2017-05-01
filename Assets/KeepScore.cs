using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepScore : MonoBehaviour {

	public GameObject scoreObject;
	public int currentScore;
	private Text scoreText;
	private SpawnSheeps spawner;
	public Text gameOverText;
	public Text restartText;
	private bool gameOver;	

	void Start () {
		scoreText = scoreObject.GetComponent<Text> ();
		scoreText.text = "" + currentScore;
		spawner = GetComponentInParent<SpawnSheeps> ();
		startGame ();
	}

	void Update () {
		scoreText.text = "" + currentScore;

		if (gameOver && !Input.inputString.Equals ("")) {	//restart game if any key pressed
			startGame ();
			spawner.reStart ();
		}
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
		if(currentScore <= 0){	
			spawner.stop ();
			gameOver = true;
			restartText.text = "Press any key to restart";
			gameOverText.text = "Game Over";
		}

		if(!gameOver){
			if (currentScore <= 60) {
				spawner.setDifficulty (1);
			} else if (currentScore > 60 && currentScore < 80) {
				spawner.setDifficulty (2);
			} else {
				spawner.setDifficulty (3);
			}
		}
	}

	public void startGame()
	{
		gameOver = false;
		restartText.text = "";
		gameOverText.text = "";
		currentScore = 20; 
	}
		
}
