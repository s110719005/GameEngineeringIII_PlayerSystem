using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolState : PlayerState
{
    private bool isStart = false;
    override public void OnEnter() 
    {
        //Debug.Log("ENTER: TOOL");
        base.OnEnter();
        string animationName;
        animationName = ToolManager.Instance.UseTool();
        switch(PlayerStateManager.Instance.CurrentDirection)
        {
            case Direction.Down:
                PlayerStateManager.Instance.SetAnimation(animationName + "Down");
                break;
            case Direction.Top:
                PlayerStateManager.Instance.SetAnimation(animationName + "Top");
                break;
            case Direction.Left:
                PlayerStateManager.Instance.SetAnimation(animationName + "Left");
                break;
            case Direction.Right:
                PlayerStateManager.Instance.SetAnimation(animationName + "Right");
                break;
            default:
                PlayerStateManager.Instance.SetAnimation(animationName + "Down");
                break;
        }
    }
    override public void OnUpdate() 
    {
        if(isStart) { return; }
        base.OnUpdate();
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
