using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : Interactable {
	public string SceneName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interact ()
	{
		PlayerPrefs.SetString ("LastLevel", SceneName);
		PlayerPrefs.DeleteKey ("PPX");
		PlayerPrefs.DeleteKey ("PPY");
		PlayerPrefs.DeleteKey ("LevelKey");
		SceneManager.LoadScene (SceneName);
	}
}
