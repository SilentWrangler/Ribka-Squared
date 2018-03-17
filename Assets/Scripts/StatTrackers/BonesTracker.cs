using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BonesTracker : MonoBehaviour {

	PlayerWalk pw;
	public int RedAt;
	public Text txt;
	// Use this for initialization
	void Start () {
		pw = FindObjectOfType<PlayerWalk> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (pw) {
			txt.text = pw.bones.ToString ();
			if (pw.bones <= RedAt) {
				txt.color = Color.red;
			} else {
				txt.color = Color.white;
			}
		}
	}
}
