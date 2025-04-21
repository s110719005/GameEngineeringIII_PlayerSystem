using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropManager : MonoBehaviour
{
    public static CropManager Instance;
    [SerializeField] private Tilemap farmGroundTilemap;
    [SerializeField] private Tilemap cropTilemap;
    [SerializeField] private TileBase holeTileBase;
    private List<CropSpot> cropSpots = new List<CropSpot>();
    private Dictionary<Vector3Int, CropSpot> cropSpotsDict = new Dictionary<Vector3Int, CropSpot>();
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < cropSpots.Count; i++)
        {
            CropSpot cropSpot = cropSpots[i];
            if(cropSpot.isPlant && !cropSpot.canHarvest)
            {
                cropSpot.currentLifeTime += Time.deltaTime;
                if(cropSpot.currentLifeTime >= cropSpot.cropType.growingTime)
                {
                    cropSpot.currentStatus += 1;
                    cropTilemap.SetTileFlags(cropSpot.grid, TileFlags.None);
                    cropTilemap.SetTile(cropSpot.grid, cropSpot.cropType.growingTileBases[cropSpot.currentStatus]);
                    if(cropSpot.currentStatus >= cropSpot.cropType.growingTileBases.Length - 1)
                    {
                        cropSpot.canHarvest = true;
                    }
                    cropSpot.currentLifeTime = 0;
                }
            }
        }
    }

    public bool IsPlanting()
    {
        if(cropSpotsDict.TryGetValue(PlayerStateManager.Instance.CurrenSelection, out CropSpot cropSpot))
        {
            return true;
        }
        return false;
    }

    public void AddCropSpot()
    {
        Vector3Int currentSelection = PlayerStateManager.Instance.CurrenSelection;
        CropSpot cropSpot = new CropSpot
        {
            grid = currentSelection,
            cropType = null,
            currentStatus = 0,
            //canPlant = true,
            isPlant = false,
            canHarvest = false,
            currentLifeTime = 0
        };
        cropSpots.Add(cropSpot);
        cropSpotsDict.Add(currentSelection, cropSpot);
    }

    public void Harvest(Vector3Int currentSelection)
    {
        if(cropSpotsDict.TryGetValue(currentSelection, out CropSpot cropSpot))
        {
            if(!cropSpot.canHarvest) { return; }
            Harvest harvest = new Harvest();
            harvest.count = 1;
            harvest.sprite = cropSpot.cropType.harvestSprite;
            harvest.crop = cropSpot.cropType;
            InventoryManager.Instance.AddItem(harvest);
            cropTilemap.SetTileFlags(cropSpot.grid, TileFlags.None);
            cropTilemap.SetTile(cropSpot.grid, null);
            cropSpots.Remove(cropSpot);
            cropSpotsDict.Remove(currentSelection);
        }

    }

    public bool PlantCrop(Vector3Int currentSelection, CropType cropType)
    {
        Debug.Log("Try plant");
        if(cropSpotsDict.TryGetValue(currentSelection, out CropSpot cropSpot))
        {
            if(cropSpot.isPlant) { return false; }
            cropSpot.isPlant = true;
            cropSpot.cropType = cropType;
            cropTilemap.SetTileFlags(cropSpot.grid, TileFlags.None);
            cropTilemap.SetTile(cropSpot.grid, cropSpot.cropType.growingTileBases[0]);
            return true;
        }
        // if(cropTilemap.GetTile(currentSelection) == holeTileBase)
        // {
        //     cropTilemap.SetTileFlags(currentSelection, TileFlags.None);
        //     cropTilemap.SetTile(currentSelection, cropType.growingTileBases[0]);
        // }
        return false;
    }
}

[System.Serializable]
public class CropSpot
{
    public Vector3Int grid;
    public CropType cropType;
    public int currentStatus;
    public bool isPlant;
    public bool canHarvest;
    public float currentLifeTime;
}
