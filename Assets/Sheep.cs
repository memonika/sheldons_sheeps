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

	void Start () {
		correctKeyPressed = false;
		mainGame = GameObject.Find ("Game");
//		characterObject = transform.GetChild(0);
//
//		Debug.Log (characterObject.GetComponent<TextMesh>());
	}

	void Update () {
		transform.Translate(Vector3.right * (Time.deltaTime * 4), Space.World);
	}
		
	void OnTriggerStay2D(Collider2D other) {
		if (Input.GetKey(character) || Input.GetKeyDown (character)) {
			correctKeyPressed = true;
		}
	}

	public void setCharacter(string randomChar) {
		character = randomChar;
		transform.GetChild(0).GetComponent<TextMesh> ().text = randomChar;
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
}
