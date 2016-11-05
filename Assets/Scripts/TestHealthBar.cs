using UnityEngine;
using System.Collections;

public class TestHealthBar : MonoBehaviour {

	private float maxDertermination;
	public float currentVie = 20f;
	public GameObject bar;  

	// Use this for initialization
	void Start () {
		maxDertermination = 100f;
	}
	
	// Update is called once per frame
	void Update () {
		bar.transform.localScale = new Vector2 (bar.transform.localScale.x, currentVie / maxDertermination);
	}
}
