using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BouttonNext : MonoBehaviour {

	public Text textBoutton;

	public void ActionNext(){
		GameObject.Find("Fenetre").GetComponent<Fenetre>().NextQuestion();
	}
}
