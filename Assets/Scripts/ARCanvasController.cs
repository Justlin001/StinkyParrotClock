using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloInteractive.XR.HoloKit;

public class ARCanvasController : MonoBehaviour
{
    private Transform centerEyePose;

    // Start is called before the first frame update
    void Start()
    {
        var holokitCameraManager = FindObjectOfType<HoloKitCameraManager>();
        centerEyePose = holokitCameraManager.CenterEyePose;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = centerEyePose.position + centerEyePose.forward * 1f;
        transform.LookAt(centerEyePose.position);
    }
}
