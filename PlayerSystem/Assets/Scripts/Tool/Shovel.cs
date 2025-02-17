using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shovel : ToolBase
{
    [SerializeField]
    private Tilemap holeTilemap;
    [SerializeField]
    private TileBase holeTileBase;
    public override void Execute() 
    {
        SetTileSprite(holeTilemap, holeTileBase);
    }
}
