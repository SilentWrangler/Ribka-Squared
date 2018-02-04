using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerWalk : Creature
{

    
    public GameObject door;
	Direction prevDir= Direction.Right;
    

    void Update()
    {
		//Debug.Log (CrossPlatformInputManager.GetAxis("Horizontal"));
		if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
			Jump(jumpForce);
        }
        
		if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			Fire (prevDir);
		}
		if (CrossPlatformInputManager.GetAxis("Horizontal")<0)
        {
			Walk (speed, Direction.Left);
			prevDir = Direction.Left;
        }

		if (CrossPlatformInputManager.GetAxis("Horizontal")>0)
        {
			Walk (speed, Direction.Right);
			prevDir = Direction.Right;
        }

		if (CrossPlatformInputManager.GetAxis("Horizontal")!= 0)
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
