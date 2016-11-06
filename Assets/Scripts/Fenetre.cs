using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class Fenetre : MonoBehaviour {

	public GameObject[] tabQuestion;
	private int currentQuestion = 0;
	private GameObject lastQuestion = null;
	private int cptQuestion = 0;
	public Animator wife;

	// Use this for initialization
	void Start (){
		ShuffleQuestion ();
		NextQuestion ();
		wife.SetBool ("isNeutral", true);
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
		if (currentQuestion == 6) {
			currentQuestion = 0;
			ShuffleQuestion ();
			SceneManager.LoadScene ("SceneMarc 1");
		}
	}
	public void ChangeExpression(int humeur){
		if (humeur == 1) {
			wife.SetBool ("isNeutral", false);
			wife.SetFloat ("angryOrHappy", 0.0f);

		} else if (humeur == 2) {
			wife.SetBool ("isNeutral", true);
		}else{
			wife.SetBool ("isNeutral", false);
			wife.SetFloat ("angryOrHappy", 1.0f);
		}
	}
}
