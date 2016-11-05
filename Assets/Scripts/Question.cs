using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Question : MonoBehaviour {

	public GameObject[] tabBouton;
	public GameObject groupButtons;
	private Fenetre fenetre;

	// Use this for initialization
	void Start () {

		AfficherBoutonReponses ();

	}
	void AfficherBoutonReponses(){
		Shuffle ();

		for (int i = 0; i < tabBouton.Length; i++) {
			GameObject boutonReponse = (GameObject) GameObject.Instantiate (tabBouton [i], Vector2.zero, tabBouton [i].transform.rotation);
			boutonReponse.transform.parent = groupButtons.transform;
			boutonReponse.transform.localScale = new Vector3 (1, 1, 1);
			boutonReponse.GetComponent<BoutonReponse> ().SetFenetre(fenetre);
		}


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
