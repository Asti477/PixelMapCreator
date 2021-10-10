using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject TileManager;
    private Camera camera;

    public float horizontalResolution = 1920f;
    float currentAspect;
    float cameraSize;

    float w;
    float h;
    int size = 3000;
    
    void Awake()
    {
        camera = Camera.main;

        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        w = dp.w;
        h = dp.h;
        float n = 50f;
    
        if(w > h && w > 10)
            n = (size/w);
        else if(w <= h && h > 10)
            n = (size/h);

        currentAspect = (float) Screen.width / (float) Screen.height;
        cameraSize = horizontalResolution / currentAspect / (n);
        camera.orthographicSize = cameraSize;

        camera.transform.position = new Vector3(w/2, h/2, -10);
    }

    void Update()
    {
        
    }
}
