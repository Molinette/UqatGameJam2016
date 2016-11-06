using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonReponse : MonoBehaviour {
	
	private int bonneReponse;
	private TestHealthBar playerStatus;
	private Fenetre fenetre;
	public Text textBoutton;

	// Use this for initialization
	void Start () {
		playerStatus = GameObject.Find ("MotivationBar").GetComponent<TestHealthBar> ();

	}
	public void buttonAction(){
		playerStatus.AjouterMotivation (bonneReponse);
		fenetre.NextQuestion ();
	}
	public void SetFenetre(Fenetre fenetre){
		this.fenetre = fenetre;
	}
		
	public void SetTextBoutton (string textBouton){
		this.textBoutton.text = textBouton;
	}
	public void SetReponseBoutton (int bonneReponse){
		this.bonneReponse = bonneReponse;
	}

		
}
