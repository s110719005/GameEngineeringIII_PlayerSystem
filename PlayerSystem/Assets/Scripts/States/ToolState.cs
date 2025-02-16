using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolState : PlayerState
{
    private bool isStart = false;
    override public void OnEnter() 
    {
        Debug.Log("ENTER: TOOL");
        base.OnEnter();
    }
    override public void OnUpdate() 
    {
        if(isStart) { return; }
        base.OnUpdate();
        string name;
        name = ToolManager.Instance.UseTool();
        Debug.Log("TOOL STATE: " + name);
        StartCoroutine(ToolDelay());
    }
    override public void OnExit() 
    {
        
    }

    private IEnumerator ToolDelay()
    {
        isStart = true;
        yield return new WaitForSeconds(1f);
        PlayerStateManager.Instance.ChangeState(PlayerStateManager.Instance.IdleState);
        isStart = false;
    }
}
