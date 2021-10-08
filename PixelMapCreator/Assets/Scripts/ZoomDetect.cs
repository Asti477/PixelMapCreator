using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomDetect : MonoBehaviour
{
    private TouchControls controls;
    private Coroutine zoomCoroutine;
    private Camera camera;
    void Awake()
    {
        controls = new TouchControls();
        camera = Camera.main;
    }
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Touch.SecondaryTouchContact.started += _ => ZoomEnd();
    }

    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);
    }

    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;

        while(true)
        {
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPos.ReadValue<Vector2>(),
            controls.Touch.SecondaryFingerPos.ReadValue<Vector2>());

            if(distance > previousDistance)
            {

            }
            else if(distance < previousDistance)
            {

            }

            previousDistance = distance;
        }
    }
}
