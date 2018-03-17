using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Interactable {

	public GameObject destination;
	PlayerWalk pw;
	// Use this for initialization
	void Start () {
		pw = FindObjectOfType<PlayerWalk> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interact ()
	{
		pw.transform.position = destination.transform.position;
	}
}
