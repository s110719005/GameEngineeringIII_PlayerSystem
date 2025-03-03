using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : AnimalState
{
    [SerializeField] float chaseSpeed;
    float currentTime;
    override public void OnEnter() 
    {
        base.OnEnter();
    }
    override public void OnUpdate() 
    {
        base.OnUpdate();
        float distance = Mathf.Infinity;
        Vector3 velocity = Vector3.zero;
        foreach (var mice in animalStateManager.Mouse)
        {
            float miceDistance = Vector3.Distance(mice.transform.position, transform.parent.position);
            if(distance > miceDistance)
            {
                distance = miceDistance;
                velocity = (mice.transform.position - transform.parent.position).normalized;
            }
        }
        transform.parent.position += velocity * chaseSpeed * Time.deltaTime;
        currentTime += Time.deltaTime;
        if(currentTime > 2.5f)
        {
            currentTime = 0;
            //if close enough attack mice
            if(distance < 1f)
            {
                animalStateManager.ChangeState(animalStateManager.AttackState);
            }
            else
            {
                animalStateManager.ChangeState(animalStateManager.FollowState);
            }
            //else
        }
    }
    override public void OnExit() 
    {
        base.OnExit();
    }
}
