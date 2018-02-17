using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour {

	public float speed= 2f;
	public float maxXDiffModule;
	public float maxYDiffModule;

	GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag ("Player");
	}

	void LateUpdate () {
		if (player) {
			Vector2 diff = player.transform.position - transform.position;
			//Debug.Log (diff.ToString ());
			if ((Mathf.Abs(diff.x)>maxXDiffModule)||(Mathf.Abs(diff.y)>maxYDiffModule)) {
				transform.position = transform.position + (Vector3)(diff.normalized * speed * Time.deltaTime);
			}
		}
	}
}
