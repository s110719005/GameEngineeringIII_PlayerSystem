using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : AnimalState
{
    [SerializeField] float speed;
    int randomX;
    int randomY;
    Coroutine walkCoroutine;
    override public void OnEnter() 
    {
        base.OnEnter();
        Debug.Log("ENTER WANDER");
        randomX = UnityEngine.Random.Range(-3,3);
        randomY = UnityEngine.Random.Range(-3,3);
        if(randomX == 0) { randomX = 1;}
        if(randomY == 0) { randomY = 1;}
        if(walkCoroutine != null)
        {
            StopCoroutine(walkCoroutine);
        }
        walkCoroutine = StartCoroutine(WalkCouroutine());
    }
    override public void OnUpdate() 
    {
        base.OnUpdate();
        //grass check
    }
    override public void OnExit() 
    {
        base.OnExit();
        if(walkCoroutine != null)
        {
            StopCoroutine(walkCoroutine);
        }
    }

    private IEnumerator WalkCouroutine()
    {
        int max = 0;
        int goalX = (int)transform.parent.position.x + randomX;
        if(goalX > 11) { goalX = 11;}
        if(goalX < -11) { goalX = -11;}
        int goalY = (int)transform.parent.position.y + randomY;
        if(goalY > 6) { goalY = 6;}
        if(goalY < -6) { goalY = -6;}
        max = (Math.Abs(randomX) >= Math.Abs(randomY)) ? Math.Abs(randomX) : Math.Abs(randomY);
        for(float i = 0; i < max ; i += speed)
        {
            if(Math.Abs(transform.parent.position.x - goalX) > 0.1f)
            {
                transform.parent.position += new Vector3(speed * (randomX / Math.Abs(randomX)), 0);
            }
            if(Math.Abs(transform.parent.position.y - goalY) > 0.1f)
            {
                transform.parent.position += new Vector3(0, speed * (randomY / Math.Abs(randomY)));
            }
            yield return new WaitForSeconds(0.05f);
        }
        transform.parent.position = new Vector3(goalX, goalY);
        animalStateManager.ChangeState(animalStateManager.SearchState);
        yield return null;
    }
}
