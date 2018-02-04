using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour {

	[SerializeField]
	private int pixelsPerUnit = 15;

	private Transform parent;
	//private bool not_parented;
	private void Start()
	{
		parent = transform.parent;
		//not_parented = parent == null;
		RoundPosition ();
	}

	/// <summary>
	/// Snap the object to the pixel grid determined by the given pixelsPerUnit.
	/// Using the parent's world position, this moves to the nearest pixel grid location by 
	/// offseting this GameObject by the difference between the parent position and pixel grid.
	/// </summary>
	private void LateUpdate() 
	{
		RoundPosition ();
	}

	void RoundPosition(){
		if (parent) {
			Vector3 newLocalPosition = Vector3.zero;

			newLocalPosition.x = (Mathf.Round (parent.position.x * pixelsPerUnit) / pixelsPerUnit) - parent.position.x;
			newLocalPosition.y = (Mathf.Round (parent.position.y * pixelsPerUnit) / pixelsPerUnit) - parent.position.y;

			transform.localPosition = newLocalPosition;
		} else {
			Vector3 newGlobalPosition = new Vector3 ();
			newGlobalPosition.x = (Mathf.Round (transform.position.x * pixelsPerUnit) / pixelsPerUnit);
			newGlobalPosition.y = (Mathf.Round (transform.position.y * pixelsPerUnit) / pixelsPerUnit);

			transform.position = newGlobalPosition;

		}
	}
}
