using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;

public class BorderTileManager : MonoBehaviour
{
    [SerializeField] Tilemap tmapBorder;
    [SerializeField] Tile border;
    [SerializeField] Tile ocean;
    [SerializeField] GameObject TileManager;

    int w;
    int h;

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
    void Awake()
    {
        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        w = dp.w;
        h = dp.h;

        setUpBorder();
    }
    void Update()
    {
        
    }
}
