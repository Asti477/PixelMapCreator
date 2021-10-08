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

    public void setUpBorder()
    {
        
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
