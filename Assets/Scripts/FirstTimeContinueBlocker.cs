using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FirstTimeContinueBlocker : MonoBehaviour {

	public Button contButton;
	// Use this for initialization
	void Start () {
		contButton.interactable=PlayerPrefs.HasKey ("LastLevel");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
