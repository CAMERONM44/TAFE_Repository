using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject torch;
    public Light light;
    public bool isOn;
    public float power = 1;

    // Update is called once per frame
    void Update()
    {
        if (isOn && power > 0)
        {
            power -= 0.01f * Time.deltaTime;
            light.intensity = Mathf.Clamp01(power);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            light.enabled = isOn;
        }
    }
}
