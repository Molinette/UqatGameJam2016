﻿using UnityEngine;
using System.Collections;

public class FetchObjectDeposit : MonoBehaviour {
	public GameObject wall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Princess")) {
			wall.SetActive (false);
		}
	}
}
