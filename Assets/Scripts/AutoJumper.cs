using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AutoJumper : MonoBehaviour {
	public Creature jumper;
	public string[] tags;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		bool jump = false;
		foreach (string t in tags) {
			jump = other.CompareTag (t);
			if (jump) {
				jumper.SendMessage("Jump",jumper.jumpForce);
				return;
			}
		}
	}

}
