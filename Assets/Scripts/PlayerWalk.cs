using UnityEngine;
using System.Collections;

public class PlayerWalk : Creature
{

    
    public GameObject door;
	Direction prevDir= Direction.Right;
    

    void Update()
    {
		
        if (Input.GetButtonDown("Jump"))
        {
			Jump(jumpForce);
        }
        
		if (Input.GetButtonDown ("Fire1")) {
			Fire (prevDir);
		}
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
			Walk (speed, Direction.Left);
			prevDir = Direction.Left;
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
			Walk (speed, Direction.Right);
			prevDir = Direction.Right;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
			Walk (0, prevDir);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
            door.GetComponent<Door>().OpenDoor();
            door.SetActive(false);
        }
    }
}
