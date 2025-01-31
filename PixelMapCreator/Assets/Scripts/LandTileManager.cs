using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;

public class LandTileManager : MonoBehaviour
{
    [SerializeField] Tilemap tmap;
    [SerializeField] Tile[] landTiles;
    [SerializeField] Slider brushSlider;
    [SerializeField] Tilemap borderMap;
    [SerializeField] Tile[] borderTiles;

    [SerializeField]internal int w;
    [SerializeField]internal int h;

    private Coroutine zoomCoroutine;

    Camera camera;
    Touch firstTouch;
    Touch secondTouch;
    Touch touch;
    
    float sizeAdd = 0f;
    float zoomSpeed = 0.03f;
    public float horizontalResolution = 1920f;
    float currentAspect;
    float cameraSize;

    void Awake()
    {
        camera = Camera.main;
        float n = 50f;
        currentAspect = (float) Screen.width / (float) Screen.height;
        cameraSize = horizontalResolution / currentAspect / (n);
        brushSlider.minValue = 0;
        brushSlider.maxValue = landTiles.Length - 1;
    }

    void changeCameraSize()
    {
        camera.orthographicSize = cameraSize + sizeAdd;
    }

    public void clear()
    {
        Debug.Log("clear");
        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                tmap.SetTile(new Vector3Int(x, y, 0), null);
                borderMap.SetTile(new Vector3Int(x, y, 0), null);
            }
        }
    }

    bool[][] getCircle(int n)
    {
        bool[][] circle;
        if(n == 1)
        {
            circle = new bool[][]{new bool[]{true}};
        }
        else if(n == 2)
        {
            circle = new bool[][]{new bool[]{false, true, false}, 
                                           new bool[]{true, true, true}, 
                                           new bool[]{false, true, false}};
        }
        else if(n == 3)
        {
            circle = new bool[][]{new bool[]{false, true, true, true, false}, 
                                  new bool[]{true, true, true, true, true}, 
                                  new bool[]{true, true, true, true, true},
                                  new bool[]{true, true, true, true, true},
                                  new bool[]{false, true, true, true, false}};
        }
        else if(n == 4)
        {
            circle = new bool[][]{new bool[]{false, false, true, true, true, false, false}, 
                                  new bool[]{false, true, true, true, true, true, true, false}, 
                                  new bool[]{true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true},
                                  new bool[]{false, true, true, true, true, true, true, false},
                                  new bool[]{false, false, true, true, true, false, false}};
        }
        else if(n == 5)
        {
            circle = new bool[][]{new bool[]{false, false, true, true, true, true, true, false, false}, 
                                  new bool[]{false, true, true, true, true, true, true, true, true, false}, 
                                  new bool[]{true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{false, true, true, true, true, true, true, true, true, false}, 
                                  new bool[]{false, false, true, true, true, true, true, false, false}};
        }
        else
        {
            circle = new bool[][]{new bool[]{false, false, false, false, true, true, true, false, false, false, false}, 
                                  new bool[]{false, false, true, true, true, true, true, true, true, false, false}, 
                                  new bool[]{false, true, true, true, true, true, true, true, true, true, false},
                                  new bool[]{false, true, true, true, true, true, true, true, true, true, false},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{true, true, true, true, true, true, true, true, true, true, true},
                                  new bool[]{false, true, true, true, true, true, true, true, true, true, false},
                                  new bool[]{false, true, true, true, true, true, true, true, true, true, false},
                                  new bool[]{false, false, true, true, true, true, true, true, true, false, false}, 
                                  new bool[]{false, false, false, false, true, true, true, false, false, false, false}};
        }

        return circle;
    }

    void paint(int size, int color)
    {
        Debug.Log((int)brushSlider.value);
        Vector2 touchPos = touch.position;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        Vector3Int gridPos = tmap.WorldToCell(touchPos);

        int x = gridPos.x;
        int y = gridPos.y;

        int n = size;

        bool[][] circle = getCircle(n + 1);

        BoundsInt sides = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for(int i = 0; i < circle.Length; i++)
        {
            for(int j = 0; j < circle.Length; j++)
            {
                if(circle[i][j] && x - n + i > 0 && x - n + i < w && y - n + j > 0 && y - n + j < h)
                {
                    tmap.SetTile(new Vector3Int(x - n + i, y - n + j, 0), landTiles[0]);

                    foreach(var b in sides.allPositionsWithin)
                    {
                        Vector3Int checkPos = new Vector3Int(x - n + i + b.x, y - n + j + b.y, 0);

                        if(b.x == 0 && b.y == 0) 
                        {
                            borderMap.SetTile(checkPos, null);
                            continue;
                        }

                        if(!tmap.HasTile(checkPos))
                        {
                            Debug.Log("check");
                            borderMap.SetTile(checkPos, borderTiles[color]);
                        }
                    }

                    continue;
                }
            }
        }
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

            if(distance > previousDistance + 2.5f && sizeAdd > -0.7 * cameraSize)
            {
                changeSizeAdd(-1);
                Debug.Log("prevDis: " + previousDistance);
                Debug.Log("dis: " + distance);
            }
            else if(distance + 2.5f < previousDistance && sizeAdd < 2.5 * cameraSize)
            {
                changeSizeAdd(1);
                Debug.Log("sizeAdd: " + sizeAdd);
            }

            previousDistance = distance;
            changeCameraSize();

            yield return null;
        }
    }

    void Update()
    {
        if(Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
                paint((int)brushSlider.value, 0);
            if(touch.phase == TouchPhase.Moved)
                paint((int)brushSlider.value, 0);
        }
        else if(Input.touchCount == 2)
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
}
