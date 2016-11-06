using UnityEngine;
using System.Collections;

public class Challenge : MonoBehaviour {
	public int nbFetchObjects;
	public int nbEnnemies;
	public GameObject wall;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void Remove(int element){
		if (element == 0) {
			nbFetchObjects--;
		} else {
			nbEnnemies--;
		}
		if (nbFetchObjects <= 0 & nbEnnemies <= 0) {
			wall.SetActive (false);
		}
	}

}
