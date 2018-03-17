using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable {


	public Mechanism[] EnableOnChange;
	public Mechanism[] DisableOnChange;
	public Mechanism[] ToggleOnChange;
	public Sprite pulledSprite;
	Sprite buff;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void Interact ()
	{
		base.Interact ();
		buff = sr.sprite;
		sr.sprite = pulledSprite;
		pulledSprite = buff;
		foreach (Mechanism e in EnableOnChange){
			e.Enable();
		}
		foreach (Mechanism d in DisableOnChange) {
			d.Disable ();
		}
		foreach (Mechanism t in ToggleOnChange) {
			t.Toggle ();
		}
	}
 
}
