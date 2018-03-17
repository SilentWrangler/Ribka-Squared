using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour {
	public Image img;
	PlayerWalk pw;
	public int DisplayAt;
	// Use this for initialization
	void Start () {
		pw = FindObjectOfType<PlayerWalk> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pw) {
			img.enabled = pw.GetHP () >= DisplayAt;
		} else {
			img.enabled = false;
		}
		
	}
}
