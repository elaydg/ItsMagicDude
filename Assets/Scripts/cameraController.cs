using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = .02f; //pozition speed
    public float rLerp = .01f; //rotation speed
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
    }
}
 