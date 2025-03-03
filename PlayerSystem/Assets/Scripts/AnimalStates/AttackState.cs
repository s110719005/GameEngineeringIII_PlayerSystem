using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AnimalState
{
    [SerializeField] GameObject attackUI;
    float currentTime;

    override public void OnEnter() 
    {
        base.OnEnter();
        attackUI.SetActive(true);
    }
    override public void OnUpdate() 
    {
        base.OnUpdate();
        currentTime += Time.deltaTime;
        if(currentTime > 2.5f)
        {
            currentTime = 0;
            animalStateManager.ChangeState(animalStateManager.FollowState);
        }
    }
    override public void OnExit() 
    {
        base.OnExit();
        attackUI.SetActive(false);
    }
}
