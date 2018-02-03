using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : Movable {
	public float speed;
	public float jumpForce;
	public float jumpInterval = 1f;
	public Projectile projectile;
	public GameObject gun;
	[SerializeField]protected int HP=3;
	protected float nexJump;
	protected Rigidbody2D rb;
	protected bool isTouchingFloor;
	protected float direction = 0;
	protected Animator anim;
	// Use this for initialization
	protected void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		
	}
	

	protected void Jump (float force) {
		if (nexJump < Time.time) {
			nexJump = Time.time + jumpInterval;
			rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
		}
	}
	public enum Direction{
		Left,
		Right,
		Up,
		Down
	};
	protected void Walk(float speed, Direction dir){
		switch (dir) {
		case Direction.Left:
			direction = 180;
			transform.localRotation = Quaternion.Euler (0, direction, 0);
			speed =speed* -1f;
			break;
		case Direction.Right:
			direction = 0;
			transform.localRotation = Quaternion.Euler (0, direction, 0);
			break;
		}
		rb.velocity =new Vector2 (speed, rb.velocity.y);
	}

	public void Hurt(int dmg=1){
		HP -= dmg;
		if (HP < 1) {
			Die ();
		}
	}

	void Die(){
		GameObject.Destroy (this.gameObject);
	}

	protected void Fire(Direction dir,float force=300f){
		if (gun) {
			if (projectile) {
				GameObject prj;
				switch (dir){
				case Direction.Left:
					prj = GameObject.Instantiate (projectile.gameObject, gun.transform.position, Quaternion.Euler (0, 180, 0));
					prj.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-force, 0));
					break;
				case Direction.Right:
					prj = GameObject.Instantiate (projectile.gameObject , gun.transform.position, Quaternion.Euler (0, 0, 0));
					prj.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (force, 0));
					break;
				}
			}
		}
	}
}
