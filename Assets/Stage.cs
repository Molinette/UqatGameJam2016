using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	private Vector3 nextPos;
	private bool movingNextPos = false;
	private float screenWidth;
	public CharacterMouvement characterMovement;
	public GameObject currentChallenge;
	public GameObject currentQuest;
	public GameObject[] quests;
	public GameObject[] challenges;

	// Use this for initialization
	void Start () {
		nextPos = transform.position;
		screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height * 2;

		currentQuest = (GameObject) GameObject.Instantiate(quests [0],transform.position,quests[0].transform.rotation);
		currentQuest.transform.position = Vector3.zero + new Vector3 (0, 0, 0);
		currentQuest.transform.parent = transform;

		currentChallenge = (GameObject) GameObject.Instantiate(challenges [0],transform.position,challenges[0].transform.rotation);
		currentChallenge.transform.position = Vector3.zero + new Vector3 (screenWidth, 0, 0);
		currentChallenge.transform.parent = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (movingNextPos) {
			transform.position = Vector3.MoveTowards (transform.position, nextPos, screenWidth * Time.deltaTime);
			if (transform.position == nextPos) {
				movingNextPos = false;
				characterMovement.StopMovingToNext ();
			}
		}
	}

	public void NextZone(){
		nextPos = nextPos - new Vector3 (screenWidth, 0, 0);
		movingNextPos = true;
	}

	public void createQuest(){
		int randomIndex = Random.Range(0,quests.Length);
		Destroy (currentQuest,2);
		currentQuest = (GameObject) GameObject.Instantiate(quests [randomIndex],transform.position,quests[randomIndex].transform.rotation);
		currentQuest.transform.position = Vector3.zero + new Vector3 (screenWidth*2, 0, 0);
		currentQuest.transform.parent = transform;
	}

	public void createChallenge(){
		int randomIndex = Random.Range(0,challenges.Length);
		Destroy (currentChallenge,2);
		currentChallenge = (GameObject) GameObject.Instantiate(challenges [randomIndex],transform.position,challenges[randomIndex].transform.rotation);
		currentChallenge.transform.position = Vector3.zero + new Vector3 (screenWidth*2, 0, 0);
		currentChallenge.transform.parent = transform;
	}
}
