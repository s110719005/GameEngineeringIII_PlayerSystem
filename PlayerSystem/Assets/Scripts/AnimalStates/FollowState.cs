using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FollowState : AnimalState
{
   
    [SerializeField] GameObject follower;
    [SerializeField] float followSpeed ;
    float currentTime;
    override public void OnEnter() 
    {
        base.OnEnter();
    }
    override public void OnUpdate() 
    {
        base.OnUpdate();
        float distance = Vector3.Distance(follower.transform.position, transform.parent.position);
        if(distance > 1f)
        {
            transform.parent.position += (follower.transform.position-transform.parent.position).normalized * followSpeed * Time.deltaTime;;
        }
        currentTime += Time.deltaTime;
        if(currentTime > 2.5f)
        {
            currentTime = 0;
            foreach (var mice in animalStateManager.Mouse)
            {
                float miceDistance = Vector3.Distance(mice.transform.position, transform.parent.position);
                if(distance > miceDistance)
                {
                    animalStateManager.ChangeState(animalStateManager.ChaseState);
                }
            }
        }
    }
    override public void OnExit() 
    {
        base.OnExit();
    }
}
