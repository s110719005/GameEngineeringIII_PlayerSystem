using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStateManager : MonoBehaviour
{
    private AnimalState currentAnimalState;
    public int CurrentX {get {return (int)transform.position.x; } }
    public int CurrentY {get {return (int)transform.position.y - 1; } }
    [SerializeField] private AnimalState initialState;
    [SerializeField] private AnimalState wanderState;
    public AnimalState WanderState => wanderState;
    [SerializeField] private AnimalState followState;
    public AnimalState FollowState => followState;
    [SerializeField] private AnimalState searchState;
    public AnimalState SearchState => searchState;
    [SerializeField] private AnimalState eatState;
    public AnimalState EatState => eatState;
    [SerializeField] private AnimalState chaseState;
    public AnimalState ChaseState => chaseState;
    [SerializeField] private AnimalState attackState;
    public AnimalState AttackState => attackState;
    // Start is called before the first frame update
    [SerializeField] private List<AnimalStateManager> mouse;
    public List<AnimalStateManager> Mouse => mouse;
    void Start()
    {
        currentAnimalState = initialState;
        currentAnimalState.OnEnter();
    }

    // Update is called once per frame
    public void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        currentAnimalState.OnUpdate();
    }

    public void ChangeState(AnimalState newState)
    {
        if(newState == null) { Debug.Log("NO STATE REFERENCE FOUND" + newState); return;}
        if(currentAnimalState == newState) { return; }
        currentAnimalState.OnExit();
        currentAnimalState = newState;
        currentAnimalState.OnEnter();
    }
}
