using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BoutonReponse : MonoBehaviour {
	
	private int bonneReponse;
	private TestHealthBar playerStatus;
	private Fenetre fenetre;
	private Question question;
	public Text textBoutton;

	// Use this for initialization
	void Start () {
		playerStatus = GameObject.Find ("MotivationBar").GetComponent<TestHealthBar> ();

	}
	public void buttonAction(){
		playerStatus.AjouterMotivation (bonneReponse);
		fenetre.ChangeExpression (bonneReponse);
		question.ShowResponse(bonneReponse);
	}

	public void SetFenetre(Fenetre fenetre){
		this.fenetre = fenetre;
	}
	public void SetQuestion(Question question){
		this.question = question;
	}
		
	public void SetTextBoutton (string textBouton){
		this.textBoutton.text = textBouton;
	}
	public void SetReponseBoutton (int bonneReponse){
		this.bonneReponse = bonneReponse;
	}

		
}
