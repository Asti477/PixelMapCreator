using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;

public class MapBorderManager : MonoBehaviour
{
    [SerializeField] GameObject TileManager;
    [SerializeField] Tilemap tmap;
    [SerializeField] Tilemap borderMap;
    [SerializeField] Tile[] borderTiles;

    int w;
    int h;

    void Awake()
    {
        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        w = dp.w;
        h = dp.h;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void drawBorder()
    {

    }
}
