using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;

public class DrawPixel : MonoBehaviour
{
    [SerializeField] Tilemap tmapBorder;
    [SerializeField] Tilemap tmap;
    [SerializeField] Tilemap tmapOcean;
    [SerializeField] Tile[] landTiles;
    [SerializeField] Tile border;
    [SerializeField] Tile ocean;
    [SerializeField] Slider brushSlider;
    public int w;
    public int h;

    Touch touch;

    void Awake()
    {
        brushSlider.minValue = 0;
        brushSlider.maxValue = landTiles.Length - 1;

        
        setUpBorder();
        setUpOcean();
    }
     
    void setUpOcean()
    {
        for(int x = -w; x < 2 * w; x++)
        {
            for(int y = -h; y < w * h; y++)
            {
                tmapOcean.SetTile(new Vector3Int(x, y, 0), ocean);
            }
        }
    }

    void setUpBorder()
    {
        for(int x = -w; x < 2 * w; x++)
        {
            for(int y = -h; y < 0; y++)
            {
                tmapBorder.SetTile(new Vector3Int(x, y, 0), ocean);
            }
        }
        for(int x = -w; x < 2 * w; x++)
        {
            for(int y = h; y < 2 * h; y++)
            {
                tmapBorder.SetTile(new Vector3Int(x, y, 0), ocean);
            }
        }
        for(int x = -w; x < 0; x++)
        {
            for(int y = 0; y < h; y++)
            {
                tmapBorder.SetTile(new Vector3Int(x, y, 0), ocean);
            }
        }
        for(int x = w; x < 2 * w; x++)
        {
            for(int y = 0; y < h; y++)
            {
                tmapBorder.SetTile(new Vector3Int(x, y, 0), ocean);
            }
        }

        for(int x = 0; x < w + 1; x++)
        {
            tmapBorder.SetTile(new Vector3Int(x, 0, 0), border);
        }
        for(int x = 0; x < w + 1; x++)
        {
            tmapBorder.SetTile(new Vector3Int(x, h, 0), border);
        }
        for(int x = 0; x < h + 1; x++)
        {
            tmapBorder.SetTile(new Vector3Int(0, x, 0), border);
        }
        for(int x = 0; x < h + 1; x++)
        {
            tmapBorder.SetTile(new Vector3Int(w, x, 0), border);
        }
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
