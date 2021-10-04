using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEditor;

public class OceanTileManager : MonoBehaviour
{
    [SerializeField] Tilemap tmapOcean;
    [SerializeField] Tile ocean;
    [SerializeField] GameObject TileManager;

    int w;
    int h;

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

    void Awake()
    {
        LandTileManager dp = TileManager.GetComponent<LandTileManager>();
        w = dp.w;
        h = dp.h;

        setUpOcean();
    }
    void Update()
    {
        
    }
}
