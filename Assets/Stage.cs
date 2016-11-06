using UnityEngine;
using System.Collections;

public class Stage : MonoBehaviour {
	private Vector3 nextPos;
	private bool movingNextPos = false;
	private float screenWidth;
	public CharacterMouvement characterMovement;

	// Use this for initialization
	void Start () {
		nextPos = transform.position;
		screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height * 2;
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
		if (Input.GetKeyDown (KeyCode.T)) {
			NextZone();
		}
	}

	public void NextZone(){
		nextPos = nextPos - new Vector3 (screenWidth, 0, 0);
		movingNextPos = true;
	}
}
