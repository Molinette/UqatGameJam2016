using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Question : MonoBehaviour {

	private int[] tabBouton = {0,1,2};
	public GameObject prefabBoutton; 
	public GameObject groupButtons;
	private Fenetre fenetre;
	public Text textQuestionPrefab;
	public string textQuestion;
	public string textReponse1;
	public string textReponse2;
	public string textReponse3;

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
				boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textReponse1);
				boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(1);
			}else if( tabBouton[i] == 1){
				boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
				boutonReponse.transform.parent = groupButtons.transform;
				boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
				boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
				boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textReponse2);
				boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(2);
			}else{
				boutonReponse = (GameObject) GameObject.Instantiate (prefabBoutton, Vector2.zero, prefabBoutton.transform.rotation);
				boutonReponse.transform.parent = groupButtons.transform;
				boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
				boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
				boutonReponse.GetComponent<BoutonReponse> ().SetTextBoutton(textReponse3);
				boutonReponse.GetComponent<BoutonReponse> ().SetReponseBoutton(3);
			}
		}
	}
	void Shuffle(){
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
