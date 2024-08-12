using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }
    void Awake()
    {
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("Start");
    }
    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }
    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
    void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}