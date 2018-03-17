using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerWalk : Creature
{

    
    public GameObject door;
	Direction prevDir= Direction.Right;
	public float WalkTreshold = 0.3f;
	public bool HasKey;
	public bool CanInteract;
	public int bones;
	public int MaxBones;
	float prevAbs;
	new void Start(){
		base.Start ();
		HasKey = PlayerPrefs.HasKey ("LevelKey");
		Vector3 pos = transform.position;
		if(PlayerPrefs.HasKey("PPX")){
			pos.x = PlayerPrefs.GetFloat ("PPX");
		}
		if(PlayerPrefs.HasKey("PPY")){
			pos.y = PlayerPrefs.GetFloat ("PPY");
		}
		transform.position = pos;
	
	} 
    void Update()
    {
		
		if (CrossPlatformInputManager.GetAxis ("Horizontal") == 0) {
			prevAbs = 0;
		}
		//Debug.Log (CrossPlatformInputManager.GetAxis("Horizontal"));
		bool c = Mathf.Abs(CrossPlatformInputManager.GetAxis("Horizontal"))>=prevAbs;
		if (c) {
			prevAbs = Mathf.Abs(CrossPlatformInputManager.GetAxis ("Horizontal"));
		}
		if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
			Jump(jumpForce);
        }
        
		if (CrossPlatformInputManager.GetButtonDown ("Fire1")) {
			Fire (prevDir);
		}
		if (CrossPlatformInputManager.GetAxis("Horizontal")<-WalkTreshold&&c)
        {
			Walk (speed, Direction.Left);
			prevDir = Direction.Left;
        }

		if (CrossPlatformInputManager.GetAxis("Horizontal")>WalkTreshold&&c)
        {
			Walk (speed, Direction.Right);
			prevDir = Direction.Right;
        }

		if (CrossPlatformInputManager.GetAxis("Horizontal")!= 0&&c)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
			Walk (0, prevDir);
        }
    }

	new protected void Fire(Direction dir,float force = 300f){
		base.Fire (dir, force);
		bones--;
		if (bones < 0) {
			bones = MaxBones;
			Hurt ();
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            Destroy(other.gameObject);
			/*door.GetComponent<Door>().OpenDoor();
            door.SetActive(false);*/
			HasKey = true;
        }
    }

	private void OnTriggerStay2D(Collider2D other){
		Interactable i = other.gameObject.GetComponent<Interactable>();
		if (i) {
			
			if (i.RequiresKey) {
				if (HasKey) {
					CanInteract = true;
					if (CrossPlatformInputManager.GetButtonDown ("Fire2")) {
						i.Interact ();
					}
				} 
			}else {
				CanInteract = true;
				if (CrossPlatformInputManager.GetButtonDown ("Fire2")) {
					i.Interact ();
				}
			}
		}
	}
	private void OnTriggerExit2D(Collider2D other){
		Interactable i = other.gameObject.GetComponent<Interactable> ();
		if (i) {
			CanInteract = false;
		}
	}
}
