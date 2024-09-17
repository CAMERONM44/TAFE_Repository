using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{
    private CharacterController controller;
    //private Vector3 crouchScale = new Vector3(0.5f, 0.4f, 0.5f);
    //private Vector3 playerScale = new Vector3(0.5f, 1f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))

        {
            controller.height = controller.height/2;

            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.0f, transform.position.z);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            controller.height = controller.height * 2;
            //transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
