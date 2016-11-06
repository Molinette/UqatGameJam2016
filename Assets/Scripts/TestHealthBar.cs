using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestHealthBar : MonoBehaviour {

	private int maxMotivation;
	private int currentMotivation;
	public GameObject bar;  

	// Use this for initialization
	void Start () {
		
		maxMotivation = 100;
		if (PlayerPrefs.HasKey ("Motivation")) {
			currentMotivation = PlayerPrefs.GetInt ("Motivation", currentMotivation);
		} else {
			PlayerPrefs.SetInt ("Motivation", currentMotivation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			PlayerPrefs.SetInt ("Motivation", 100);
			currentMotivation = PlayerPrefs.GetInt ("Motivation");
		}
		bar.transform.localScale = new Vector2 (bar.transform.localScale.x, (float) currentMotivation / (float) maxMotivation);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("Respawn")){
			Debug.Log ("lol");
		}
	}
	public void AjouterMotivation(int motivation){
		if (motivation == 1) {
			currentMotivation = currentMotivation + 10;
			if (currentMotivation >= 100) {
				currentMotivation = 100;
			}
			//SaveMotivation ();
		} else if (motivation == 2) {
		} else {
			currentMotivation = currentMotivation - 10;
			if (currentMotivation <= 0) {
				currentMotivation = 0;
				//GameOver ();
			}

		}
		//SaveMotivation ();
	}

	public void SaveMotivation(){
		PlayerPrefs.SetInt ("Motivation", currentMotivation);
	}
	/*
	public void GameOver(){
		
	}*/
}