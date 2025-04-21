using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[System.Serializable]
public class Item
{
    public int count;
    public Sprite sprite;
    
}

[System.Serializable]
public class Seed : Item
{
    public CropType crop;
}

[System.Serializable]
public class Harvest : Item
{
    public CropType crop;
}
