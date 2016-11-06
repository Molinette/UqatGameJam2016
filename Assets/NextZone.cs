using UnityEngine;
using System.Collections;

public class NextZone : MonoBehaviour {
	public GameObject trigger;
	public GameObject wall;
	private GameObject stage;
	private bool activated = false;
	public int challengeType = 0;

	// Use this for initialization
	void Start () {
		stage = GameObject.FindGameObjectWithTag ("Stage");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (!activated && other.CompareTag("Character")) {
			stage.GetComponent<Stage> ().NextZone ();
			activated = true;
			trigger.SetActive (false);
			wall.SetActive(true);
			if (challengeType == 0) {
				GameObject.FindGameObjectWithTag ("Stage").GetComponent<Stage> ().createQuest();
			} else {
				GameObject.FindGameObjectWithTag ("Stage").GetComponent<Stage> ().createChallenge();
			}
		}
	}
}
