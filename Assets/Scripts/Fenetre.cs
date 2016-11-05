using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Fenetre : MonoBehaviour {

	public GameObject[] tabQuestion;
	private int currentQuestion = 0;
	private GameObject lastQuestion = null;

	// Use this for initialization
	void Start (){
		ShuffleQuestion ();
		NextQuestion ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void ShuffleQuestion(){
		List <GameObject> listTriee = new List<GameObject>{};

		for (int i = 0; i < tabQuestion.Length; i++) {
			listTriee.Add (tabQuestion [i]);
		}
		for (int i = 0; i < tabQuestion.Length; i++) {
			int randomIndex = Random.Range (0, listTriee.Count);
			tabQuestion [i] = listTriee [randomIndex];
			listTriee.RemoveAt (randomIndex);
		}
	}
	public void NextQuestion(){
		if (lastQuestion != null){
			Destroy (lastQuestion);
		}
		lastQuestion = (GameObject) GameObject.Instantiate (tabQuestion [currentQuestion], Vector2.zero, tabQuestion [currentQuestion].transform.rotation);
		lastQuestion.transform.parent = transform;
		lastQuestion.transform.localScale = new Vector3 (1, 1, 1);
		lastQuestion.GetComponent<RectTransform> ().offsetMin = new Vector2 (1, 1);
		lastQuestion.GetComponent<RectTransform> ().offsetMax = new Vector2 (-1, -1);
		lastQuestion.transform.localPosition = Vector3.zero;
		lastQuestion.GetComponent<Question> ().SetFenetre (this);
		currentQuestion++;
		if (currentQuestion >= tabQuestion.Length) {
			currentQuestion = 0;
			ShuffleQuestion ();
		}
	}
}
