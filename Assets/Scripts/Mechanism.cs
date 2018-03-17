using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanism : MonoBehaviour {

	protected bool on;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Enable(){
		on = true;
	}

	public virtual void Disable(){
		on = false;
	}

	public virtual void Toggle(){
		on = !on;
	}

	public bool IsEnabled(){
		return on;
	}
}
