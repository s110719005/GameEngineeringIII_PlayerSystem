using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



[System.Serializable]
[CreateAssetMenu(fileName = "Crops", menuName = "Crops", order = 0)]
public class CropType : ScriptableObject 
{
    public string cropName;
    public Sprite seedSprite;
    public TileBase[] growingTileBases;
    public Sprite harvestSprite;
    public Sprite shopSprite;
    public float growingTime;
    public int seedPrice;
    public int harvestPrice;
    public int unlockPrice;

}

