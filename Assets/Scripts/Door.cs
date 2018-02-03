using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject openDoor;

    public void OpenDoor()
    {
        Instantiate(openDoor, transform.position, transform.rotation);
    }
}
