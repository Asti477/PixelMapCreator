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
    [SerializeField]internal int w;
    [SerializeField]internal int h;

    Touch touch;

    void Awake()
    {
        brushSlider.minValue = 0;
        brushSlider.maxValue = landTiles.Length - 1;
    }


    void clear()
    {
        Debug.Log("space");
        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                //tmap.SetTile(new Vector3Int(x, y, 0), tile_empty);
            }
        }
    }

    void paint()
    {
        Debug.Log((int)brushSlider.value);
        Vector2 touchPos = touch.position;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        Vector3Int gridPos = tmap.WorldToCell(touchPos);

        int n = (int)brushSlider.value;

        //if(gridPos.x < w - n + 1 && gridPos.x > n - 1 && gridPos.y > n - 1 && gridPos.y < h - n + 1)
        tmap.SetTile(gridPos, landTiles[n]);
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
            clear();
        if(Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
                paint();
            if(touch.phase == TouchPhase.Moved)
                paint();
        }
            
    }
}
