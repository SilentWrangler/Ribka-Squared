using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTracker : MonoBehaviour {

	public Image img;
	PlayerWalk pw;
	// Use this for initialization
	void Start () {
		pw = FindObjectOfType<PlayerWalk> ();
	}

	// Update is called once per frame
	void Update () {
		if (pw) {
			//button.interactable = pw.CanInteract;
			img.enabled=pw.HasKey;
		} else {
			//button.interactable = false;
			img.enabled=false;
		}
	}
}
