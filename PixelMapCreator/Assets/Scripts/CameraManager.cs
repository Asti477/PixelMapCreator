using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    public float horizontalResolution = 1920;
    [SerializeField] GameObject TileManager;
    private Camera camera;

    float w;
    float h;
    
    private TouchControls controls;
    private Coroutine zoomCoroutine;
    void Awake()
    {
        controls = new TouchControls();
        camera = Camera.main;

        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        w = dp.w;
        h = dp.h;
        camera.transform.position = new Vector3(w/2, h/2, -10);
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
    void Update()
    {
        if(Input.touchCount == 2)
        {
            // touch = Input.GetTouch(0);

            // if(touch.phase == TouchPhase.Began)
            //     paint();
            // if(touch.phase == TouchPhase.Moved)
            //     paint();
        }
    }
    
    public void OnGUI ()
    {
        float n = 50f;

        if(w > h && w > 10)
            n = 3000/w;
        else if(w <= h && h > 10)
            n = 3000/h;

        float currentAspect = (float) Screen.width / (float) Screen.height;
        camera.orthographicSize = horizontalResolution / currentAspect / (n);
    }
}
