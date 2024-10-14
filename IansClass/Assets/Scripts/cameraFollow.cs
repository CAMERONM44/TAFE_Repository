using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraLookPosition;
    [SerializeField] private Transform cameraFollowPosition;

    [SerializeField] private float cameraFollowSpeed;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraFollowPosition.position, cameraFollowSpeed * Time.deltaTime);

        transform.LookAt(cameraLookPosition);
    }
}
