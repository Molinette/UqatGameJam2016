using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {
	public Text textBoutton;

	public void Play(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("SceneMarc 2");
		Time.timeScale = 1;
	}

	public void GoBack(){
		SceneManager.LoadScene ("MenuGame");
	}
}
