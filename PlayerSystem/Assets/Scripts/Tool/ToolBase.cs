using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
