using UnityEngine;
using System.Collections;

public class BoutonReponse : MonoBehaviour {
	
	public float bonneReponse;
	private TestHealthBar playerStatus;
	private Fenetre fenetre;

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
		
}
