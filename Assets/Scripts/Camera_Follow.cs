using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

	public float speed= 2f;
	public float maxXDiffModule;
	public float maxYDiffModule;
	public bool snap;
	GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag ("Player");
		Vector3 top_middle = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2f, Screen.height));
		float DYM = top_middle.y - transform.position.y;
		maxYDiffModule = DYM;
	}

	void LateUpdate () {
		if (player) {
			Vector2 diff = player.transform.position - transform.position;
			//Debug.Log (diff.ToString ());
			if (snap) {
				if (Mathf.Abs (diff.x) > maxXDiffModule) {
					Vector3 newPos = transform.position;
					newPos.x += Mathf.Sign (diff.x) * 2f * maxXDiffModule;
					transform.position = newPos;
				}
				if (Mathf.Abs (diff.y) > maxYDiffModule) {
					Vector3 newPos = transform.position;
					newPos.y += Mathf.Sign (diff.y) * 2f * maxYDiffModule;
					transform.position = newPos;
				}
			} else {
				if ((Mathf.Abs (diff.x) > maxXDiffModule) || (Mathf.Abs (diff.y) > maxYDiffModule)) {
					transform.position = transform.position + (Vector3)(diff.normalized * speed * Time.deltaTime);
				
				}
			}
		}
	}
}
