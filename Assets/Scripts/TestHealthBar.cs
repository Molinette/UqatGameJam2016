using UnityEngine;
using System.Collections;

public class TestHealthBar : MonoBehaviour {

	private float maxMotivation;
	public float currentMotivation;
	public GameObject bar;  

	// Use this for initialization
	void Start () {
		maxMotivation = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		bar.transform.localScale = new Vector2 (bar.transform.localScale.x, currentMotivation / maxMotivation);
	}
	public void AjouterMotivation(int motivation){
		if (motivation == 1) {
			currentMotivation = currentMotivation + 10;
			if (currentMotivation >= 100) {
				currentMotivation = 100;
			}
		} else if (motivation == 2) {
		} else {
			currentMotivation = currentMotivation - 10;
			if (currentMotivation <= 0) {
				currentMotivation = 0;
			}
		}
	}
}
