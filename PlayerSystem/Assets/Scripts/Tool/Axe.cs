using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Axe : ToolBase
{
    [SerializeField]
    private Tilemap grassTilemap;
    public override void Execute() 
    {
        SetTileSprite(grassTilemap, null);
    }
}
