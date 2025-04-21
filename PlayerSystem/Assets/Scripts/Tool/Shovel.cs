using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Shovel : ToolBase
{
    [SerializeField]
    private Tilemap cropTilemap;
    [SerializeField]
    private Tilemap farmGroundTilemap;
    [SerializeField]
    private TileBase holeTileBase;
    public override void Execute() 
    {
        if(SetTileSprite(farmGroundTilemap, cropTilemap, holeTileBase))
        {
            CropManager.Instance.AddCropSpot();
        }
    }
}
