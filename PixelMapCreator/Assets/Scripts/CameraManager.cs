using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float horizontalResolution = 1920;
    [SerializeField] GameObject TileManager;
 
    void Awake()
    {
        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        float w = dp.w;
        float h = dp.h;
        transform.position = new Vector3(w/2, h/2, -10);
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
    
    void OnGUI ()
    {
        float currentAspect = (float) Screen.width / (float) Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / 50;
    }
}
