using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    public static ToolManager Instance;
    private ToolBase currentTool;
    private int currentIndex = 0;
    [SerializeField]
    private Image toolUIImage;
    [SerializeField]
    private List<ToolBase> activateTool;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ChangeTool(activateTool[currentIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            currentIndex++;
            if(currentIndex >= activateTool.Count) { currentIndex = 0; }
            ChangeTool(activateTool[currentIndex]);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            currentIndex--;
            if(currentIndex < 0) { currentIndex = activateTool.Count - 1; }
            ChangeTool(activateTool[currentIndex]);
        }
        
    }

    public void ChangeTool(ToolBase newTool)
    {
        currentTool = newTool;
        toolUIImage.sprite = newTool.ToolSprite;
    }

    public string UseTool()
    {
        currentTool.Execute();
        return currentTool.ToolActionName;
    }
}
