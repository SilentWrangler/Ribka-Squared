using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable {

	public Dtype DoorType = Dtype.LevelPass;
    public GameObject openDoor;
	public string NextLevel;
	public GameObject destination;
	public override void Interact ()
	{
		OpenDoor ();
	}


    public void OpenDoor()
    {
		if (DoorType == Dtype.LevelPass) {
			LevelPass lp = Instantiate (openDoor, transform.position, transform.rotation).GetComponent<LevelPass> ();
			lp.SceneName = NextLevel;
		}if (DoorType == Dtype.Portal) {
			Portal p = Instantiate (openDoor, transform.position, transform.rotation).GetComponent<Portal> ();
			p.destination = destination;
		}
		gameObject.SetActive (false);
    }

	public enum Dtype{
		Portal,
		LevelPass
	}
}
