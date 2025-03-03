using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EatState : AnimalState
{
    [SerializeField] private Tilemap eatTilemap;
    override public void OnEnter() 
    {
        Debug.Log("ENTER EAT");
        base.OnEnter();
        Vector3Int currentSelection = new Vector3Int(animalStateManager.CurrentX, animalStateManager.CurrentY, 0);
        if(!eatTilemap.HasTile(currentSelection)) { return; }
        eatTilemap.SetTileFlags(currentSelection, TileFlags.None);
        eatTilemap.SetTile(currentSelection, null);
        Debug.Log("CHANGE TO WANDER");
        animalStateManager.ChangeState(animalStateManager.WanderState);
    }
    override public void OnUpdate() 
    {
        base.OnUpdate();
    }
    override public void OnExit() 
    {
        base.OnExit();
    }
}
