using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour {

	public string character;
	private bool correctKeyPressed;
	public Sprite sheepGreen;
	public Sprite sheepRed;
	private GameObject mainGame;
	private Transform characterObject;
	public int speed = 4;

	void Start () {
		correctKeyPressed = false;
		mainGame = GameObject.Find ("Game");
	}

	void Update () {
		transform.Translate(Vector3.right * Time.deltaTime * getSpeed(), Space.World);
	}

	int getSpeed() {
		return speed;
	}
		
	void OnTriggerStay2D(Collider2D other) {
		if (Input.inputString == character) {
			correctKeyPressed = true;
		}
	}
		
	void OnTriggerExit2D(Collider2D other) {
		SpriteRenderer renderer = GetComponent<SpriteRenderer>();
		KeepScore scoreKeeper = mainGame.GetComponent<KeepScore> ();

		if (correctKeyPressed == true) {
			renderer.sprite = sheepGreen;
			scoreKeeper.increaseScore ();

		} else {
			renderer.sprite = sheepRed;
			scoreKeeper.decreaseScore ();
		}
	}

	public void setCharacter(string randomChar) {
		character = randomChar;
		transform.GetChild(0).GetComponent<TextMesh> ().text = randomChar;
	}

	public void setSpeed(int newSpeed) {
		speed = newSpeed;
	}
		
}
