using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Question : MonoBehaviour {

	private int[] tabBouton = {0,1,2};
	public GameObject prefabBoutton; 
	public GameObject groupButtons;
	public GameObject nextButton;
	private Fenetre fenetre;
	public Text textQuestionPrefab;
	public string textQuestion;
	public string textReponse1;
	public string textReponse2;
	public string textReponse3;
	public string textReplique1;
	public string textReplique2;
	public string textReplique3;

	// Use this for initialization
	void Start () {
		AfficherBoutonReponses ();
		textQuestionPrefab.text = textQuestion;
	}
	void AfficherBoutonReponses(){
		
		GameObject boutonReponse;
	
		Shuffle ();

		for (int i = 0; i < tabBouton.Length; i++) {
			if (tabBouton[i] == 0) {
				boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
				boutonReponse.transform.parent = groupButtons.transform;
				boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
				boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
				boutonReponse.GetComponent<BoutonReponse> ().SetQuestion(this);
				boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textReponse1);
				boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(1);
			}else if( tabBouton[i] == 1){
				boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
				boutonReponse.transform.parent = groupButtons.transform;
				boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
				boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
				boutonReponse.GetComponent<BoutonReponse> ().SetQuestion(this);
				boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textReponse2);
				boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(2);
			}else{
				boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
				boutonReponse.transform.parent = groupButtons.transform;
				boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
				boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
				boutonReponse.GetComponent<BoutonReponse> ().SetQuestion(this);
				boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textReponse3);
				boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(3);
			}
		}
	}
	public void ShowResponse(int bonneReponse){
		Transform[] enfantsQuestion = gameObject.GetComponentsInChildren<Transform> ();
		foreach (Transform enfantQuestion in enfantsQuestion) {
			if (enfantQuestion.gameObject.name == "Group Boutons") {
				Transform[] enfantsGroupBoutons = enfantQuestion.gameObject.GetComponentsInChildren<Transform> ();
				foreach (Transform enfantGroupBoutons in enfantsQuestion) {
					if (enfantGroupBoutons.gameObject.name != "Text" && enfantGroupBoutons.gameObject != gameObject && enfantGroupBoutons.gameObject.name != "Group Boutons") {
						print (enfantGroupBoutons.gameObject.name);
						Destroy (enfantGroupBoutons.gameObject);
					}
				}
			}
		}
		if (bonneReponse == 1) {
			textQuestionPrefab.text = textReplique1;
		} else if (bonneReponse == 2) {
			textQuestionPrefab.text = textReplique2;
		} else {
			textQuestionPrefab.text = textReplique3;
		}
		GameObject nextButtonIntance = (GameObject) GameObject.Instantiate (nextButton, Vector2.zero, nextButton.transform.rotation);
		nextButtonIntance.transform.parent = groupButtons.transform;
		nextButtonIntance.transform.localScale = new Vector3 (1, 1, 1);
	}
     public void Shuffle(){
		List <int> listTriee = new List<int>{};

		for (int i = 0; i < tabBouton.Length; i++) {
			listTriee.Add (tabBouton [i]);
		}

		for (int i = 0; i < tabBouton.Length; i++) {
			int randomIndex = Random.Range (0, listTriee.Count);
			tabBouton [i] = listTriee [randomIndex];
			listTriee.RemoveAt (randomIndex);
		}

	}
	public void SetFenetre(Fenetre fenetre){
		this.fenetre = fenetre;
	}

}
