using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreFinal : MonoBehaviour {

	public Text princessAmountText;
	public string before;
	public string after;

	// Use this for initialization
	void Start () {
		
		princessAmountText.text = before + " " + PlayerPrefs.GetInt ("Princess") + " "+ after ;

	}
}
