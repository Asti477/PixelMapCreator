using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class Paint : MonoBehaviour
{
    [SerializeField] Tilemap tmap;
    [SerializeField] Tile tile_empty;
    [SerializeField] Tile tile_filled;
    [SerializeField] int w;
    [SerializeField] int h;
    private float height;
    private float width;

    void Awake()
    {
        // height = Camera.main.orthographicSize * 2.0f;
        // width = height * Screen.width / Screen.height;

        Debug.Log("width: " + width + " height: " + height);
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
        Vector3 mousePos = Input.mousePosition;
        Debug.Log("x: " + mousePos.x + " y: " + mousePos.y);
        Vector3Int gridPos = tmap.WorldToCell(mousePos);

        tmap.SetTile(new Vector3Int(0, 0, 0), tile_filled);
        tmap.SetTile(new Vector3Int((int)((mousePos.x - 750) / 65), (int)((mousePos.y - 880) / 65), 0), tile_filled);
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
            clear();
        if(Input.GetMouseButton(0))
            paint();
    }
}
