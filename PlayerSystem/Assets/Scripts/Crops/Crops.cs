using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
[CreateAssetMenu(fileName = "Crops", menuName = "Crops", order = 0)]
public class Crop : ScriptableObject 
{
    public string cropName;
    public Sprite seedSprite;
    public Sprite[] growingSprites;
    public Sprite harvestSprite;
    public Sprite shopSprite;
    public float growingTime;
    public int seedPrice;
    public int harvestPrice;

}

