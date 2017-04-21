using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnSheeps : MonoBehaviour {

	public Transform sheep;
	public float spawnGap;
	private string possibleCharacters = "abcdefghijklmnopqrstuvwxyz";
	private int numberOfPossibleCharacters;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSheep", 1.0f, spawnGap);
		numberOfPossibleCharacters = possibleCharacters.Length;
	}

	// Update is called once per frame
	void Update () {}
		
	void SpawnSheep() {
		int randomCharacterIndex = Random.Range (0, numberOfPossibleCharacters);
		string randomChar = "" + possibleCharacters [randomCharacterIndex];
		Transform spawnedSheep = Instantiate(sheep, new Vector3(-10, -2.4f, 0), Quaternion.identity);

		spawnedSheep.GetComponent<Sheep> ().setCharacter (randomChar);
	}
}
