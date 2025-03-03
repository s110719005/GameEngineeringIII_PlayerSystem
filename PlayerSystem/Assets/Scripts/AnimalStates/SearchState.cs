using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SearchState : AnimalState
{
    [SerializeField] float minSerachDelay = 0.5f;
    [SerializeField] float maxSerachDelay = 2.0f;
    [SerializeField] private Tilemap searchedTilemap;
    float randomSerachDelay;
    float currentTime;
    override public void OnEnter() 
    {
        base.OnEnter();
        Debug.Log("ENTER SEARCH");
        currentTime = 0;
        randomSerachDelay = UnityEngine.Random.Range(minSerachDelay, maxSerachDelay);
    }
    override public void OnUpdate() 
    {
        base.OnUpdate();

        currentTime += Time.deltaTime;
        if(currentTime >= randomSerachDelay)
        {
            //TODO: search specific object
            //if found
            //change to eat
            //else
            Debug.Log("X: " + animalStateManager.CurrentX  + "Y: " + animalStateManager.CurrentY);
            if(searchedTilemap.HasTile(new Vector3Int(animalStateManager.CurrentX, animalStateManager.CurrentY, 0)))
            {
                Debug.Log("CHANGE TO EAT");
                animalStateManager.ChangeState(animalStateManager.EatState);
            }
            else
            {
                Debug.Log("CHANGE TO WANDER");
                animalStateManager.ChangeState(animalStateManager.WanderState);
            }
        }
    }
    override public void OnExit() 
    {
        base.OnExit();
        Debug.Log("LEAVE SEARCH");
    }
}
