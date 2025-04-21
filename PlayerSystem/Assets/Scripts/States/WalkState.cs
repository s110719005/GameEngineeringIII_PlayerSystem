using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : PlayerState
{
    [SerializeField]
    private float playerSpeed = 4;
    override public void OnEnter() 
    {
        base.OnEnter();
        //Debug.Log("ENTER: WALK");
        PlayerStateManager.Instance.SetAnimation("WalkDown");

    }
    override public void OnUpdate() 
    {
        base.OnUpdate();
        
        if(Input.GetKey(KeyCode.W))
        {
            PlayerStateManager.Instance.Player.transform.position += new Vector3(0, playerSpeed * Time.deltaTime, 0);
            PlayerStateManager.Instance.SetAnimation("WalkTop");
            PlayerStateManager.Instance.SetDirection(Direction.Top);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            PlayerStateManager.Instance.Player.transform.position -= new Vector3(playerSpeed * Time.deltaTime, 0, 0);
            PlayerStateManager.Instance.SetAnimation("WalkLeft");
            PlayerStateManager.Instance.SetDirection(Direction.Left);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            PlayerStateManager.Instance.Player.transform.position -= new Vector3(0, playerSpeed * Time.deltaTime, 0);
            PlayerStateManager.Instance.SetAnimation("WalkDown");
            PlayerStateManager.Instance.SetDirection(Direction.Down);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            PlayerStateManager.Instance.Player.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0, 0);
            PlayerStateManager.Instance.SetAnimation("WalkRight");
            PlayerStateManager.Instance.SetDirection(Direction.Right);
        }
        else
        {
            PlayerStateManager.Instance.ChangeState(PlayerStateManager.Instance.IdleState);
        }
    }
    override public void OnExit() 
    {

    }
}
