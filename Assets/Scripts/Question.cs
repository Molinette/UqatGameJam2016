using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Question : MonoBehaviour {

	private GameObject[] tabBouton = new GameObject[3];
	public GameObject prefabBoutton; 
	public GameObject groupButtons;
	private Fenetre fenetre;
	public Text textQuestionPrefab;
	public string textQuestion;
	public string textBonneReponse;
	public string textMauvaiseReponse;
	public string textMoyenneReponse;

	// Use this for initialization
	void Start () {
		AfficherBoutonReponses ();
		textQuestionPrefab.text = textQuestion;
	}
	void AfficherBoutonReponses(){
		GameObject boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
		boutonReponse.transform.parent = groupButtons.transform;
		boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
		boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
		boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textBonneReponse);
		boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(1);
		tabBouton [0] = boutonReponse;

		boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
		boutonReponse.transform.parent = groupButtons.transform;
		boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
		boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
		boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textMoyenneReponse);
		boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(2);
		tabBouton [1] = boutonReponse;

		boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
		boutonReponse.transform.parent = groupButtons.transform;
		boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
		boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
		boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textMauvaiseReponse);
		boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(3);
		tabBouton [2] = boutonReponse;
		Shuffle ();


	}
	void Shuffle(){
		List <GameObject> listTriee = new List<GameObject>{};

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
