using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterPot : ToolBase
{
    [SerializeField]
    private Color waterColor;
    
    [Header("Grid")]
    [SerializeField]
    private Tilemap farmGroundTile;
    
    public override void Execute() 
    {
        if(!CropManager.Instance.IsPlanting()) { return; }
        SetTileColor(farmGroundTile, waterColor);
        CropManager.Instance.Water();
    }

    
    
}
