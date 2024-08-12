using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out rb) == false)
        {
            Debug.Log(gameObject.name + " needs a RIgidbody component!");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementStep = new Vector3(horizontalInput, 0, verticalInput);

        rb.AddForce(movementStep * speed);
    }
}
