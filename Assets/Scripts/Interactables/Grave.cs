using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grave : Interactable {

	public Sprite FirstDecay;
	public Sprite SecondDecay;
	public int MaxUses;
	int uses;
	PlayerWalk pw;
	// Use this for initialization
	void Start () {
		pw = FindObjectOfType<PlayerWalk> ();
		uses = MaxUses;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public override void Interact ()
	{
		base.Interact ();
		PlayerPrefs.SetFloat ("PPX", pw.transform.position.x);
		PlayerPrefs.SetFloat ("PPY", pw.transform.position.y);
		PlayerPrefs.SetInt ("LevelKey", 1);
		if (pw.GetHP () < 3) {
			pw.Hurt (-1);
			uses--;
		}
		pw.bones = pw.MaxBones;
		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		sr.sprite = FirstDecay;
		if (uses <= MaxUses / 2) {
			sr.sprite = SecondDecay;
		}
		if (uses == 0) {
			gameObject.SetActive (false);
		}
	}
}
