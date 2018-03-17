using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHaldler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGame(){
		PlayerPrefs.SetString ("LastLevel", "Level1");
		SceneManager.LoadScene ("Level1");
	}

	public void Continue(){
		string ll = PlayerPrefs.GetString ("LastLevel");
		SceneManager.LoadScene (ll);
	}


}
