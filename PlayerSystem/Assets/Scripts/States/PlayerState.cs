using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerState : StateBase
{
    
    override public void OnEnter() 
    {

    }
    override public void OnUpdate() 
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            PlayerStateManager.Instance.ChangeState(PlayerStateManager.Instance.ToolState);
        }
    }
    override public void OnExit() 
    {
        
    }
}
