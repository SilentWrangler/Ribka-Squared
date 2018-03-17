using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Creature {
	public float pointStopDistance;
	public float stayTime;
	float departTime;
	bool reached=false;
	public GameObject[] PatrolPoints;
	[SerializeField] int CurrentPatrolPoint;
	public float attackDelay=0.5f;
	public float attackLength=0.1f;
	float attackStart;
	float attackFinish;
	bool attacked = true;
	Direction facing;
	GameObject player;
	int mask = ~(1 << 8);
	public float pursuitTime;
	float pursuitEnd;

	new void Start(){
		base.Start ();
		if (direction ==180) {
			facing = Direction.Left;
		}
		if (direction == 0) {
			facing = Direction.Right;
		}
		PlayerWalk pw = FindObjectOfType<PlayerWalk> ();
		if (pw) {
			player = pw.gameObject;
		}
	}
	// Update is called once per frame
	void Update () {
		RaycastHit2D sighted = new RaycastHit2D();
		RaycastHit2D meleeTarget;
		switch (facing) {
		case Direction.Left:
			meleeTarget = Physics2D.Raycast (transform.position, Vector2.left, 0.4f, mask);
			break;
		case Direction.Right:
			meleeTarget = Physics2D.Raycast (transform.position, Vector2.right, 0.4f, mask);
			break;
		default:
			meleeTarget = new RaycastHit2D ();
			break;
			
		}
		if (!attacked && (attackFinish <= Time.time)) {
			
			anim.SetBool ("attacking", false);
			Fire (facing);
			attacked = true;
		}
		if (player != null) {
			sighted = Physics2D.Raycast (transform.position, player.transform.position - transform.position, Mathf.Infinity, mask);
			Debug.DrawRay (transform.position, player.transform.position - transform.position, Color.red);
		}
		if (sighted.collider != null) {
			//Debug.Log (sighted.collider.ToString ());
			if (sighted.collider.gameObject.CompareTag ("Player")) {
				if (((player.transform.position.x < transform.position.x) && (facing == Direction.Left)) || ((player.transform.position.x > transform.position.x) && (facing == Direction.Right))) {
					pursuitEnd = Time.time + pursuitTime;
				}
			}
		}
		if (pursuitEnd < Time.time) {
			if (!reached) {
				if (Mathf.Abs (PatrolPoints [CurrentPatrolPoint].transform.position.x - transform.position.x) < pointStopDistance) {
					Walk (0, facing);
					reached = true;
					departTime = Time.time + stayTime;
					anim.SetBool ("walking", false);
					return;
				}
				if (PatrolPoints [CurrentPatrolPoint].transform.position.x > transform.position.x) {
					facing = Direction.Right;
					Walk (speed, facing);
					anim.SetBool ("walking", true);
				}
				if (PatrolPoints [CurrentPatrolPoint].transform.position.x < transform.position.x) {
					Walk (speed, Direction.Left);
					facing = Direction.Left;
					anim.SetBool ("walking", true);
				}
			}
			if (reached) {
				if (departTime < Time.time) {
			
					CurrentPatrolPoint++;
					if (CurrentPatrolPoint >= PatrolPoints.Length) {
						CurrentPatrolPoint = 0;
					}
					reached = false;
				}
			}
		} else {
			if (meleeTarget.collider != null) {
				if (meleeTarget.collider.gameObject.CompareTag ("Player")) {
					Walk (0, facing);
					reached = true;
					departTime = Time.time + stayTime;
					anim.SetBool ("walking", false);
					if (attackStart < Time.time) {
						attackStart = attackDelay + Time.time;
						if (attacked) {
							attackFinish = attackStart + attackLength;
							attacked = false;
						}
						anim.SetBool ("attacking", true);
					}
				} else {
					Pursue ();
				}
			} else {
				Pursue ();
			}

		}
	}

	void Pursue(){
		if (player != null) {
			if (player.transform.position.x > transform.position.x) {
				facing = Direction.Right;
				Walk (speed, facing);
				anim.SetBool ("walking", true);
			}
			if (player.transform.position.x < transform.position.x) {
				Walk (speed, Direction.Left);
				facing = Direction.Left;
				anim.SetBool ("walking", true);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		Creature cr = coll.gameObject.GetComponent<Creature> ();
		if (cr) {
			if (transform.position.y > coll.transform.position.y + 0.8) {
				rb.AddForce (new Vector2 (Mathf.Sign (transform.position.x - coll.transform.position.x) * 10f, 10f));
				if (coll.gameObject.CompareTag ("Player")) {
					cr.Hurt ();
				}
			}
		}
	}
}
