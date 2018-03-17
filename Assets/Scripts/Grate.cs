using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grate : Mechanism {


	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Disable ()
	{
		base.Disable ();
		anim.SetBool ("Closed", true);
	}
	public override void Enable ()
	{
		base.Enable ();
		anim.SetBool ("Closed", false);
	}

	public override void Toggle ()
	{
		base.Toggle ();
		anim.SetBool ("Closed", !on);
	}

}
