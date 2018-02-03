using UnityEngine;
using System.Collections;

public class PlayerWalk : MonoBehaviour
{

    public float speed;
    public float jump;
    public float jumpInterval = 1f;
    public GameObject door;

    float nexJump;
    Rigidbody2D rb;
    bool isTouchingFloor;
    float direction = 0;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && nexJump < Time.time)
        {
            nexJump = Time.time + jumpInterval;

            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            direction = 180;

            transform.localRotation = Quaternion.Euler(0, direction, 0);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            direction = 0;

            transform.localRotation = Quaternion.Euler(0, direction, 0);
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
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
