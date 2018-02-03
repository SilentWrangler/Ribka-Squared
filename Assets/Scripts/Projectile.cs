using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class Projectile : Movable {

	[SerializeField]bool NonGravitional=true;
	[SerializeField]float lifetime = 2f;
	[SerializeField]int Damage =1;
	[SerializeField]Targets target=Targets.Player;
	int layerToIgnore;
	public Rigidbody2D rb;

	enum Targets{
		Mobs,
		Player,
		Both
	};



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		GameObject.Destroy (this.gameObject, lifetime);
		if (NonGravitional) {
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		}
		switch (target) {
		case Targets.Mobs:
			layerToIgnore = 9;
			break;
		case Targets.Player:
			layerToIgnore = 8;
			break;
		}
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.layer == layerToIgnore) {
			Physics2D.IgnoreCollision (coll.collider, GetComponent<Collider2D> ());
		} else {
			Creature cr = coll.gameObject.GetComponent<Creature> ();
			if (cr) {
				cr.Hurt (Damage);
			}
			Destroy (this.gameObject);
		}
	}
}
