using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public Flashlight torch;        //references the Flashlight class to access the power float of objects using that script

    ///when the collider of the object this component is attached to touches another collider, check if that objects collider has the "Power" tag,
    //and if so, set the power of the flashlight to 1, and destroy the game object of the other collider.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            torch.power = 1;
            Destroy(other.gameObject);
        }
    }
}
