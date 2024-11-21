using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light light;         //the light component on the same game object this script is attached to
    public bool isOn;           //boolean referenced for enabling/disabling the light component
    public float power = 1;     //a float correlating to the instensity of the light, 1 = max intensity, 0 = no intensity

    // Update is called once per frame
    void Update()
    {
        //if the isOn boolean is true, and the power float is above 0, subtract 0.01 from the intensity float over real time using Time.deltaTime
        if (isOn && power > 0)
        {
            power -= 0.01f * Time.deltaTime;
            light.intensity = Mathf.Clamp01(power);
        }
        //when the F key is pressed, invert the isOn boolean and set whether the light is enabled to be equal to the isOn bool
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            light.enabled = isOn;
        }
    }
}
