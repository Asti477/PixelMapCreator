using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject TileManager;
    float zoomSpeed = 0.04f;
    private Camera camera;
    Touch firstTouch;
    Touch secondTouch;

    public float horizontalResolution = 1920f;
    float currentAspect;
    float cameraSize;

    float w;
    float h;
    int size = 3000;
    float sizeAdd = 0f;
    
    private TouchControls controls;
    private Coroutine zoomCoroutine;
    void Awake()
    {
        Debug.Log("camera size:" + cameraSize);

        controls = new TouchControls();
        camera = Camera.main;

        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        w = dp.w;
        h = dp.h;
        camera.transform.position = new Vector3(w/2, h/2, -10);
    }

    private void ZoomStart()
    {
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd()
    {
        StopCoroutine(zoomCoroutine);
    }

    private void changeSizeAdd(int sign)
    {
        sizeAdd += sign * zoomSpeed;
    }

    IEnumerator ZoomDetection()
    {
        float previousDistance = 0f, distance = 0f;

        while(true)
        {
            distance = Vector2.Distance(firstTouch.position, secondTouch.position);

            if(distance > previousDistance && sizeAdd > -0.7 * cameraSize)
            {
                changeSizeAdd(-1);
                Debug.Log("sizeAdd: " + sizeAdd);
            }
            else if(distance < previousDistance && sizeAdd < 2.5 * cameraSize)
            {
                changeSizeAdd(1);
                Debug.Log("sizeAdd: " + sizeAdd);
            }

            previousDistance = distance;
            yield return null;
        }
    }
    void Update()
    {
        if(Input.touchCount == 2)
        {
            firstTouch = Input.GetTouch(0);
            secondTouch = Input.GetTouch(1);

            if(firstTouch.phase == TouchPhase.Began)
                Debug.Log("hi");
            if(firstTouch.phase == TouchPhase.Moved || secondTouch.phase == TouchPhase.Moved)
                ZoomStart();
            if(firstTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Ended)
                ZoomEnd();
        }
            
    }
    
    public void OnGUI ()
    {
        float n = 50f;
    
        if(w > h && w > 10)
            n = (size/w);
        else if(w <= h && h > 10)
            n = (size/h);

        currentAspect = (float) Screen.width / (float) Screen.height;
        cameraSize = horizontalResolution / currentAspect / (n);
        camera.orthographicSize = cameraSize + sizeAdd;
    }
}
