﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour {

	private int maxMotivation;
	private int currentMotivation;
	public GameObject bar; 
	public Text chronoText;
	public Text princessText;
	public float maxWorkTime;
	public Transform respawn;
	private float timeLeft;
	private int nbPrincess;
	public GameObject dropTheCape;

	// Use this for initialization
	void Start () {

		maxMotivation = 100;
		if (PlayerPrefs.HasKey ("Motivation")) {
			currentMotivation = PlayerPrefs.GetInt ("Motivation", currentMotivation);
		} else {
			PlayerPrefs.SetInt ("Motivation", currentMotivation);
		}

		if (PlayerPrefs.HasKey ("Princess")) {
			nbPrincess = PlayerPrefs.GetInt ("Princess");
		} else {
			PlayerPrefs.SetInt ("Princess", nbPrincess);
		}
		timeLeft = maxWorkTime;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.SetInt ("Motivation", 100);
			currentMotivation = PlayerPrefs.GetInt ("Motivation");
		}
		bar.transform.localScale = new Vector2 (bar.transform.localScale.x, (float) currentMotivation / (float) maxMotivation);
		timeLeft -= Time.deltaTime;
		timeLeft = Mathf.Max(timeLeft,0);
		chronoText.text = (int)timeLeft + "s";
		princessText.text = nbPrincess + "";
		if (timeLeft <= 0 && GetComponent<CharacterMouvement>().GetIsGrounded()) {
			GameObject.Instantiate (dropTheCape, transform.position, dropTheCape.transform.rotation);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Respawn")){
			//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
			//Time.timeScale = 1;
			currentMotivation = currentMotivation - 20;
			if (currentMotivation <= 0) {
				currentMotivation = 0;
				GameOver ();
			}
			SaveMotivation ();
			transform.position = new Vector2 (respawn.transform.position.x, respawn.transform.position.y);
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
	public void AjouterMotivation(int motivation){
		if (motivation == 1) {
			currentMotivation = currentMotivation + 10;
			if (currentMotivation >= 100) {
				currentMotivation = 100;
			}
			SaveMotivation ();
		} else if (motivation == 2) {
		} else {
			currentMotivation = currentMotivation - 10;
			if (currentMotivation <= 0) {
				currentMotivation = 0;
				GameOver ();
			}
		}
		SaveMotivation ();
	}

	public void AjouterPrincess(){
		currentMotivation = currentMotivation + 10;
		if (currentMotivation >= 100) {
			currentMotivation = 100;
		}
		SaveMotivation ();
		nbPrincess++;
		PlayerPrefs.SetInt ("Princess", nbPrincess);
	}

	public void SaveMotivation(){
		PlayerPrefs.SetInt ("Motivation", currentMotivation);
	}

	public void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}
}