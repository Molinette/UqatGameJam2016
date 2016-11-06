using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class dropTheCape : MonoBehaviour {
	public float maxTime = 4;
	private float timeLeft;

	// Use this for initialization
	void Start () {
		timeLeft = maxTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			SceneManager.LoadScene ("QuestionScene");
		}
	}
}
