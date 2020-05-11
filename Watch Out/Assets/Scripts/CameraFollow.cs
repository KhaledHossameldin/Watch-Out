using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    Vector3 offset;

    private void Start()
    {
        target = FindObjectOfType<MainCharacterHandler>().transform;
        offset = new Vector3(0, 0, -10);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.2f);
        transform.position = smoothedPosition;
    }
}
