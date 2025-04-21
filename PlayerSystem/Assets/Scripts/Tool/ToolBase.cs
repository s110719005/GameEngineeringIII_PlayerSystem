using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolBase : MonoBehaviour
{
    public virtual void Execute() {}
    [SerializeField]
    private Sprite toolSprite;
    public Sprite ToolSprite => toolSprite;
    
    [SerializeField]
    private string toolActionName;
    public string ToolActionName => toolActionName;
    public void PlayToolAnimation() 
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetTileSprite(Tilemap tilemap, TileBase tileBase)
    {
        Vector3Int currentSelection = new Vector3Int(PlayerStateManager.Instance.SelectionGridX, PlayerStateManager.Instance.SelectionGridY - 1, 0);
        if(!tilemap.HasTile(currentSelection)) { return false; }
        tilemap.SetTileFlags(currentSelection, TileFlags.None);
        tilemap.SetTile(currentSelection, tileBase);
        return true;
    }

    public bool SetTileSprite(Tilemap tilemapCheck, Tilemap tilemapEdit, TileBase tileBase)
    {
        Vector3Int currentSelection = new Vector3Int(PlayerStateManager.Instance.SelectionGridX, PlayerStateManager.Instance.SelectionGridY - 1, 0);
        if(!tilemapCheck.HasTile(currentSelection)) { return false; }
        if(tilemapEdit.GetTile(currentSelection) == tileBase) { return false;}
        tilemapEdit.SetTileFlags(currentSelection, TileFlags.None);
        tilemapEdit.SetTile(currentSelection, tileBase);
        return true;
    }
    
    public void SetTileColor(Tilemap tilemap, Color color)
    {
        Vector3Int currentSelection = new Vector3Int(PlayerStateManager.Instance.SelectionGridX, PlayerStateManager.Instance.SelectionGridY - 1, 0);
        if(!tilemap.HasTile(currentSelection)) { return; }
        Debug.Log("SET COLOR");
        tilemap.SetTileFlags(currentSelection, TileFlags.None);
        tilemap.SetColor(currentSelection, color);
    }    
}
