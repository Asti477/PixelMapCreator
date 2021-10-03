using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class DrawPixel : MonoBehaviour
{
    [SerializeField] Tilemap tmap;
    [SerializeField] Tile tile_empty;
    [SerializeField] Tile tile_filled;
    [SerializeField] int w;
    [SerializeField] int h;

    Touch touch;

    void Awake()
    {

    }
     

    void clear()
    {
        Debug.Log("space");
        for(int x = 0; x < w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                tmap.SetTile(new Vector3Int(x, y, 0), tile_empty);
            }
        }
    }

    void paint()
    {
        Vector2 touchPos = touch.position;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        Vector3Int gridPos = tmap.WorldToCell(touchPos);

        tmap.SetTile(gridPos, tile_filled);
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
            clear();
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
                paint();
            if(touch.phase == TouchPhase.Moved)
                paint();
        }
            
    }
}
