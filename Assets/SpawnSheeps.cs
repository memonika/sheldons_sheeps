using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnSheeps : MonoBehaviour {

	public Transform sheep;
	public float spawnGap;
	public int difficulty;
	private string easyPossibleCharacters = "asdfghjk";
	private string mediumPossibleCharacters = "abcdefghjkmnopqrstuvwxyz";
	private string hardPossibleCharacters = "abcdefghjkmnopqrtuvwxyzABCDEFGJKMNOPQRTUVWXYZ!§$%&/()=?";

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSheep", 1.0f, spawnGap);
	}

	// Update is called once per frame
	void Update () {}
		
	void SpawnSheep() {
		string randomChar = getRandomCharacter ();
		int sheepSpeed = getSheepSpeed ();

		Transform spawnedSheep = Instantiate(sheep, new Vector3(-10, -2.4f, 0), Quaternion.identity);
		Sheep newSheep = spawnedSheep.GetComponent<Sheep> ();

		newSheep.setCharacter (randomChar);
		newSheep.setSpeed (sheepSpeed);
	}
		
	string getRandomCharacter() {
		int randomCharacterIndex;

		if (difficulty == 1) {
			randomCharacterIndex = Random.Range (0, easyPossibleCharacters.Length);
			return "" + easyPossibleCharacters [randomCharacterIndex];
		}

		else if (difficulty == 2) {
			randomCharacterIndex = Random.Range (0, mediumPossibleCharacters.Length);
			return "" + mediumPossibleCharacters [randomCharacterIndex];
		}

		else {
			randomCharacterIndex = Random.Range (0, hardPossibleCharacters.Length);
			return "" + hardPossibleCharacters [randomCharacterIndex];
		}
	}

	int getSheepSpeed() {
		if (difficulty == 1) {
			return 4;
		}

		else if (difficulty == 2) {
			return 5;
		}

		else {
			return 6;
		}	
	}

	public void setDifficulty(int newDifficulty) {
		difficulty = newDifficulty;
	}

}
