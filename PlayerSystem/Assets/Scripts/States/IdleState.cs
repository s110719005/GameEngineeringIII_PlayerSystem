using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    override public void OnEnter() 
    {
        Debug.Log("ENTER: IDLE");
        base.OnEnter();
        switch(PlayerStateManager.Instance.CurrentDirection)
        {
            case Direction.Down:
                PlayerStateManager.Instance.SetAnimation("IdleDown");
                break;
            case Direction.Top:
                PlayerStateManager.Instance.SetAnimation("IdleTop");
                break;
            case Direction.Left:
                PlayerStateManager.Instance.SetAnimation("IdleLeft");
                break;
            case Direction.Right:
                PlayerStateManager.Instance.SetAnimation("IdleRight");
                break;
            default:
                PlayerStateManager.Instance.SetAnimation("IdleDown");
                break;
        }
    }
    override public void OnUpdate() 
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            PlayerStateManager.Instance.ChangeState(PlayerStateManager.Instance.WalkState);
        }
    }
    override public void OnExit() 
    {
        
    }
}
